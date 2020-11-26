using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using MagicCommonLibrary;
using MagicGraphicLibrary;
using MagicServerLibrary;
using ZedGraph;


namespace MagicAddOn
{
    class cDisplayDataSodx : IDisposable
    {

        #region Enum
        /// <summary>List of event for data sample mode.</summary>
        public enum eDataSampleMode
        {
            /// <summary>Run</summary>
            eRun,
            /// <summary>Pause</summary>
            ePause,
        }
        /// <summary>List of event for thread Gui.</summary>
        public enum eEventThreadGui
        {
            /// <summary>Nothing To Do</summary>
            eNone,
            /// <summary>Data sample updating</summary>
            eUpdateDataSample,
            /// <summary>Update Run/Pause</summary>
            eUpdateRunPause,
            /// <summary>Initialize</summary>
            eInitialize,
            /// <summary>Initialize Axis</summary>
            eInitializeAxis,
        }

        /// <summary>Type event for application</summary>
        enum eEventThreadFifo
        {
            /// <summary>Nothing To Do</summary>
            eNone,
        }
        #endregion

        bool _disposed = false, _scaleMaxAuto = false;
        Mutex _mutex = null;
        cZedGraphic _graph = null;
        ClsCompass _compass = null;
        Button _buttonRunPause = null;
        CheckBox _checkBoxAutoScale = null;
        int _scale = 0;
        bool _blink = false;
        bool _isDataSample = false;
        ushort _saturationLevelIntensity = 0x4000;
        double[] _xAxisData = null;
        double _maxRefractiveIndex = 0;
        cDataSample _dataSample = null;
        cDataSample _guiDataSample = null;
        List<sSodxCommand> _sodxCommandList = null;
        List<sFilteredSignal> _filteredSignalList = null;
        List<cCurve> _curvesList = null;
        cGeneralSettings _generalSettings = null;
        eDataSampleMode _dataSampleMode = eDataSampleMode.eRun;
        sAxisGraphic _axisGraphic = new sAxisGraphic();
        #region Fifo
        /// <summary>Number of maximum buffer in event thread Gui</summary>
        private const int _maxNumberOfBufferInFifoEventThreadGui = 64;
        /// <summary>fifo Event Thread Gui </summary>
        private cQueueExt _fifoEventThreadGui = null;
        /// <summary>Number of maximum buffer in data sample fifo</summary>
        private const int _maxNumberOfBufferInFifoDataSample = 1024 * 32;
        /// <summary>fifo data sample </summary>
        private cQueueExt _fifoDataSample = null;
        #endregion
        #region Thread_Declaration
        cThreadProcess _threadGui = null;
        cThreadProcess _threadFifo = null;
        #endregion

        public cDisplayDataSodx(cGeneralSettings generalSettings, cZedGraphic Graph, Button buttonRunPause, CheckBox checkBoxAutoScale)
        {
            System.Guid guid = System.Guid.NewGuid();
            _mutex = new Mutex(false, guid.ToString("N"));
            if (Graph != null)
            {
                _graph = Graph;
                if (generalSettings != null)
                {
                    _graph.PathImageFile = generalSettings.General.ImageDirectory;
                }
                _graph.ZoomEvent += new ZedGraphControl.ZoomEventHandler(_graph_ZoomEvent);
            }
            _buttonRunPause = buttonRunPause;
            _checkBoxAutoScale = checkBoxAutoScale;
            if (_buttonRunPause != null)
            {
                _buttonRunPause.Click += new EventHandler(_buttonRunPause_Click);
            }
            if (_checkBoxAutoScale != null)
            {
                _checkBoxAutoScale.CheckedChanged += new EventHandler(_checkBoxAutoScale_CheckedChanged);
            }
            _generalSettings = generalSettings;
            _curvesList = new List<cCurve>();
            #region Fifo_Initialize
            _fifoEventThreadGui = new cQueueExt(_maxNumberOfBufferInFifoEventThreadGui);
            _fifoEventThreadGui.IdName = "Fifo Event Thread Gui";
            _fifoDataSample = new cQueueExt(_maxNumberOfBufferInFifoDataSample);
            _fifoDataSample.IdName = "Fifo Data Sample";
            #endregion
            #region Thread_Initialize
            
            _threadGui = new cThreadProcess("cDisplayDataSodx.Guid", Enum.GetValues(typeof(eEventThreadGui)).Length);
            _threadGui.StartThread(new ThreadStart(ThreadGuiLoop));
            _threadFifo = new cThreadProcess("cDisplayDataSodx.Fifo", Enum.GetValues(typeof(eEventThreadFifo)).Length);
            _threadFifo.StartThread(new ThreadStart(ThreadFifoLoop));
            #endregion
        }
        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                    #region ThreadFifo
                    if (_threadFifo != null)
                    {
                        _threadFifo.StopThread(500);
                        _threadFifo.Dispose();
                        _threadFifo = null;
                    }
                    #endregion
                    #region ThreadGui
                    if (_threadGui != null)
                    {
                        _threadGui.StopThread(500);
                        _threadGui.Dispose();
                        _threadGui = null;
                    }
                    #endregion
                    #region Dipose_FifoEventThreadGui_Section
                    if (_fifoEventThreadGui != null)
                    {
                        _fifoEventThreadGui.Dispose();
                        _fifoEventThreadGui = null;
                    }
                    #endregion
                    #region CurveList
                    if (_curvesList != null)
                    {
                        for (int idx = 0; idx < _curvesList.Count; idx++)
                        {
                            cCurve curve = _curvesList[idx];
                            if (curve != null)
                            {
                                curve.Dispose();
                                curve = null;
                            }
                        }
                    }
                    #endregion
                    #region FifoDataSample
                    if (_fifoDataSample != null)
                    {
                        _fifoDataSample.Dispose();
                        _fifoDataSample = null;
                    }
                    #endregion
                    #region Mutex
                    if (_mutex != null)
                    {
                        _mutex.Dispose();
                        _mutex = null;
                    }
                    #endregion
                }
                // Free your own state (unmanaged objects).  
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Compass
        public ClsCompass Compass
        {
            get { return (_compass); }
            set { _compass = value; }
        }
        #endregion
        #region _checkBoxAutoScale_CheckedChanged
        private void _checkBoxAutoScale_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _mutex.WaitOne(-1);
                _scaleMaxAuto = _checkBoxAutoScale.Checked;
                if (_fifoEventThreadGui != null)
                {
                    lock (_fifoEventThreadGui)
                    {
                        _fifoEventThreadGui.Enqueue(eEventThreadGui.eInitialize);
                    }
                }
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
        #endregion
        #region _buttonRunPause_Click
        private void _buttonRunPause_Click(object sender, EventArgs e)
        {
            _dataSampleMode = (_dataSampleMode == eDataSampleMode.eRun) ? eDataSampleMode.ePause : eDataSampleMode.eRun;
            _threadGui.EventUserList[(int)eEventThreadGui.eUpdateRunPause].Set();
        }
        #endregion
        #region _graph_ZoomEvent
        private void _graph_ZoomEvent(ZedGraph.ZedGraphControl sender, ZedGraph.ZoomState oldState, ZedGraph.ZoomState newState)
        {
            if (_graph != null)
            {
                #region XAxis
                if (_graph.GraphPane.XAxis.Scale.Min < _graph.AxisReference.XAxisScaleMin)
                {
                    _axisGraphic.XAxisScaleMin = _graph.AxisReference.XAxisScaleMin;
                }
                else
                {
                    _axisGraphic.XAxisScaleMin = _graph.GraphPane.XAxis.Scale.Min;
                }
                if (_graph.GraphPane.XAxis.Scale.Max > _graph.AxisReference.XAxisScaleMax)
                {
                    _axisGraphic.XAxisScaleMax = _graph.AxisReference.XAxisScaleMax;
                }
                else
                {
                    _axisGraphic.XAxisScaleMax = _graph.GraphPane.XAxis.Scale.Max;
                }
                #endregion
                #region YAxis
                if (_graph.GraphPane.YAxis.Scale.Min < _graph.AxisReference.YAxisScaleMin)
                {
                    _axisGraphic.YAxisScaleMin = _graph.AxisReference.YAxisScaleMin;
                }
                else
                {
                    _axisGraphic.YAxisScaleMin = _graph.GraphPane.YAxis.Scale.Min;
                }
                if (_graph.GraphPane.YAxis.Scale.Max > _graph.AxisReference.YAxisScaleMax)
                {
                    _axisGraphic.YAxisScaleMax = _graph.AxisReference.YAxisScaleMax;
                }
                else
                {
                    _axisGraphic.YAxisScaleMax = _graph.GraphPane.YAxis.Scale.Max;
                }
                #endregion
                #region Y2Axis
                if (_graph.GraphPane.Y2Axis.Scale.Min < _graph.AxisReference.Y2AxisScaleMin)
                {
                    _axisGraphic.Y2AxisScaleMin = _graph.AxisReference.Y2AxisScaleMin;
                }
                else
                {
                    _axisGraphic.Y2AxisScaleMin = _graph.GraphPane.Y2Axis.Scale.Min;
                }
                if (_graph.GraphPane.Y2Axis.Scale.Max > _graph.AxisReference.Y2AxisScaleMax)
                {
                    _axisGraphic.Y2AxisScaleMax = _graph.AxisReference.Y2AxisScaleMax;
                }
                else
                {
                    _axisGraphic.Y2AxisScaleMax = _graph.GraphPane.Y2Axis.Scale.Max;
                }
                #endregion
                if (_fifoEventThreadGui != null)
                {
                    lock (_fifoEventThreadGui)
                    {
                        _fifoEventThreadGui.Enqueue(eEventThreadGui.eInitializeAxis);
                    }
                }
            }
        }
        #endregion     
        #region Threads
        #region ThreadGuiLoop
        /// <summary>This method is called when starting the thread.</summary> 
        public void ThreadGuiLoop()
        {

            try
            {
                const int timeoutDefaultValue = 40;
                int timeoutValue = timeoutDefaultValue;
                eEventThreadGui eventThreadGui = eEventThreadGui.eNone;

                while (!_threadGui.EventExitProcessThread.WaitOne(timeoutValue))
                {
                    #region FifoEventThreadGui
                    if (_fifoEventThreadGui != null)
                    {
                        lock (_fifoEventThreadGui)
                        {
                            if (_fifoEventThreadGui.Count > 0)
                            {
                                eventThreadGui = (eEventThreadGui)_fifoEventThreadGui.Dequeue();
                            }
                            else
                            {
                                eventThreadGui = eEventThreadGui.eNone;
                            }
                        }
                    }
                    #endregion
                    #region Update Data Sample
                    if ((_guiDataSample != null) && (_generalSettings != null) && (_generalSettings.General.ResourceLanguage != null) && (_threadGui.EventUserList[(int)eEventThreadGui.eUpdateDataSample].WaitOne(0)))
                    {
                        foreach (sSignalData signalData in _guiDataSample.SignalDataList)
                        {
                            double _minValue = 0;
                            if (signalData != null)
                            {
                                for (int idx = 0; idx < _curvesList.Count; idx++)
                                {
                                    cCurve curveSignal = _curvesList[idx];
                                    sFilteredSignal filteredSignal = (sFilteredSignal)curveSignal.Tag;
                                    if ((filteredSignal != null) && (signalData.Signal == filteredSignal.Signal) && (signalData.SignalType == filteredSignal.SignalType) && (signalData.ResultType == filteredSignal.ResultType) && (signalData.PeakNumber == filteredSignal.PeakNumber) && (signalData.CalculatedSignal == filteredSignal.CalculatedSignal))
                                    {
                                        double[] _tmpDoubleArray = null;
                                        if (signalData.Signal == eSodxSignal.Altitude)
                                        {
                                            _tmpDoubleArray = signalData.AltitudeToArrayDouble(Scale);
                                            for (int udx = 0; udx < _tmpDoubleArray.Length; udx++)
                                            {
                                                if (_tmpDoubleArray[udx] >= Scale)
                                                {
                                                    _tmpDoubleArray[udx] = double.NaN;
                                                }
                                            }
                                            if (Compass != null)
                                            {
                                                Compass.Tilt = (int)(_tmpDoubleArray[0] - _tmpDoubleArray[_tmpDoubleArray.LongLength - 1]);
                                            }
                                        }
                                        else if ((signalData.Signal == eSodxSignal.Intensity_Level) || (signalData.Signal == eSodxSignal.Intensity_Raw))
                                        {
                                            if (signalData.ResultType == eSodxResultType.Measured)
                                            {
                                                _tmpDoubleArray = (signalData.Signal == eSodxSignal.Intensity_Level) ? signalData.IntensityLevelToArrayDouble(SaturationLevelIntensity) : signalData.DataToArrayDouble;
                                            }
                                            else if (signalData.ResultType == eSodxResultType.Calculated)
                                            {
                                                _tmpDoubleArray = (signalData.Signal == eSodxSignal.Intensity_Level) ? signalData.IntensityLevelRawToArrayDouble() : signalData.DataToArrayDouble;
                                            }
                                            for (int udx = 0; udx < _tmpDoubleArray.Length; udx++)
                                            {
                                                if (_tmpDoubleArray[udx] == 0)
                                                {
                                                    _tmpDoubleArray[udx] = double.NaN;
                                                }
                                            }
                                        }
                                        else if (signalData.Signal == eSodxSignal.Thickness)
                                        {
                                            _tmpDoubleArray = signalData.ThicknessToArrayDouble(Scale);
                                            for (int udx = 0; udx < _tmpDoubleArray.Length; udx++)
                                            {
                                                if (_tmpDoubleArray[udx] >= _graph.AxisReference.YAxisScaleMax)
                                                {
                                                    _tmpDoubleArray[udx] = double.NaN;
                                                }
                                            }
                                        }
                                        else if ((signalData.Signal == eSodxSignal.Roughness) || (signalData.Signal == eSodxSignal.Waviness))
                                        {
                                            _tmpDoubleArray = signalData.DataToArrayDouble;
                                            _minValue = signalData.Min;
                                            if (_minValue < _graph.AxisReference.Y2AxisScaleMin)
                                            {
                                                _graph.AxisReference.Y2AxisScaleMin = _minValue;
                                            }
                                        }
                                        if ((_tmpDoubleArray != null) && (_xAxisData != null))
                                        {
                                            curveSignal.DataTwo = _tmpDoubleArray;
                                            curveSignal.DataOne = _xAxisData;
                                            curveSignal.FirstDataToShow = filteredSignal.FirstPoint;
                                            curveSignal.SizeOfDataToShow = filteredSignal.PointCount;
                                            curveSignal.IsVisible = true;
                                        }
                                    }
                                }
                            }
                        }
                        if (_graph != null)
                        {
                            _graph.Invoke(new Action(() =>
                            {
                                _graph.DisplayCurves();
                                _graph.AxisChange();
                                _graph.Invalidate();
                            }));
                        }
                    }
                    #endregion
                    
                    #region eUpdateRunPause
                    if (_threadGui.EventUserList[(int)eEventThreadGui.eUpdateRunPause].WaitOne(0))
                    {
                        if (_buttonRunPause != null)
                        {
                            switch (_dataSampleMode)
                            {
                                case eDataSampleMode.eRun:
                                    IntPtr IsHandleCreated = _buttonRunPause.Handle;
                                    _buttonRunPause.Invoke(new Action(() => { _buttonRunPause.Image = (_isDataSample) ? cResources.GetImagePlayOn : cResources.GetImagePlayOff; }));
                                    break;
                                case eDataSampleMode.ePause:
                                    _buttonRunPause.Invoke(new Action(() => { _buttonRunPause.Image = (_blink == false) ? cResources.GetImagePauseOff : cResources.GetImagePauseOn; }));
                                    break;
                            }
                        }
                    }
                    #endregion
                    #region eInitializeAxis
                    if (eventThreadGui == eEventThreadGui.eInitializeAxis)
                    {
                        if (_graph != null)
                        {
                            _graph.Invoke(new Action(() =>
                            {
                                SetAxisInformation(_axisGraphic);
                            }));
                        }
                    }
                    #endregion
                    #region eInitialize
                    if (eventThreadGui == eEventThreadGui.eInitialize)
                    {
                        if (_graph != null)
                        {
                            _graph.Invoke(new Action(() =>
                            {
                                #region Clear Curves
                                _graph.ClearCurves();
                                for (int idx = 0; idx < _curvesList.Count; idx++)
                                {
                                    cCurve curve = _curvesList[idx];
                                    if (curve != null)
                                    {
                                        curve.Dispose();
                                        curve = null;
                                    }
                                }
                                _curvesList.Clear();
                                #endregion
                                _graph.SetGraphicMargin(new cMargin(32, 18, 15, 46));
                                #region XAxis
                                _graph.GraphPane.XAxis.Title.FontSpec.Size = 10;
                                _graph.GraphPane.XAxis.Title.FontSpec.IsBold = false;
                                _graph.GraphPane.XAxis.Title.FontSpec.Border.IsVisible = false;
                                _graph.GraphPane.XAxis.Title.FontSpec.Fill.Type = ZedGraph.FillType.Solid;
                                _graph.GraphPane.XAxis.Title.FontSpec.Fill.IsVisible = false;
                                _graph.GraphPane.XAxis.Scale.Format = "0.###";
                                _graph.GraphPane.YAxis.Title.IsVisible = true;
                                _graph.GraphPane.XAxis.Title.Text = "?";
                                eSignalUnit XAxisUnit = eSignalUnit.eMicronMeter;
                                #endregion
                                #region YAxis
                                _graph.GraphPane.YAxis.Title.FontSpec.Size = 10;
                                _graph.GraphPane.YAxis.Title.FontSpec.IsBold = false;
                                _graph.GraphPane.YAxis.Title.FontSpec.Border.IsVisible = false;
                                _graph.GraphPane.YAxis.Title.FontSpec.Fill.Type = ZedGraph.FillType.Solid;
                                _graph.GraphPane.YAxis.Title.FontSpec.Fill.IsVisible = false;
                                _graph.GraphPane.YAxis.Scale.Format = "0.###";
                                _graph.GraphPane.YAxis.Title.IsVisible = true;
                                _graph.GraphPane.YAxis.IsVisible = false;
                                _graph.GraphPane.YAxis.Title.Text = "?";
                                _graph.GraphPane.YAxis.Scale.MaxAuto = _scaleMaxAuto;
                                _graph.GraphPane.YAxis.Scale.MinAuto = _scaleMaxAuto;
                                eSignalUnit YAxisUnit = eSignalUnit.eMicronMeter;
                                #endregion
                                #region Y2Axis
                                _graph.GraphPane.Y2Axis.Title.FontSpec.Size = 10;
                                _graph.GraphPane.Y2Axis.Title.FontSpec.IsBold = false;
                                _graph.GraphPane.Y2Axis.Title.FontSpec.Border.IsVisible = false;
                                _graph.GraphPane.Y2Axis.Title.FontSpec.Fill.Type = ZedGraph.FillType.Solid;
                                _graph.GraphPane.Y2Axis.Title.FontSpec.Fill.IsVisible = false;
                                _graph.GraphPane.Y2Axis.Scale.Format = "0.###";
                                _graph.GraphPane.Y2Axis.Title.IsVisible = true;
                                _graph.GraphPane.Y2Axis.IsVisible = false;
                                _graph.GraphPane.Y2Axis.Title.Text = "?";
                                _graph.GraphPane.Y2Axis.Scale.MaxAuto = _scaleMaxAuto;
                                _graph.GraphPane.Y2Axis.Scale.MinAuto = _scaleMaxAuto;
                                eSignalUnit Y2AxisUnit = eSignalUnit.eNone;
                                #endregion
                                #region Grid
                                _graph.GraphPane.YAxis.MajorGrid.Color = Color.DarkGray;
                                _graph.GraphPane.YAxis.MinorGrid.Color = Color.LightGray;
                                _graph.GraphPane.YAxis.MajorGrid.DashOn = 10;
                                _graph.GraphPane.YAxis.MajorGrid.DashOff = 5;
                                _graph.GraphPane.YAxis.MinorGrid.DashOn = 1;
                                _graph.GraphPane.YAxis.MinorGrid.DashOff = 2;
                                _graph.GraphPane.YAxis.MinorGrid.IsVisible = false;
                                _graph.GraphPane.YAxis.MajorGrid.IsVisible = false;
                                _graph.GraphPane.Y2Axis.MajorGrid.Color = Color.DarkGray;
                                _graph.GraphPane.Y2Axis.MinorGrid.Color = Color.LightGray;
                                _graph.GraphPane.Y2Axis.MajorGrid.DashOn = 10;
                                _graph.GraphPane.Y2Axis.MajorGrid.DashOff = 5;
                                _graph.GraphPane.Y2Axis.MinorGrid.DashOn = 1;
                                _graph.GraphPane.Y2Axis.MinorGrid.DashOff = 2;
                                _graph.GraphPane.Y2Axis.MinorGrid.IsVisible = false;
                                _graph.GraphPane.Y2Axis.MajorGrid.IsVisible = false;
                                #endregion
                                if ((_sodxCommandList != null) && (_curvesList != null))
                                {
                                    for (int idx = 0; idx < _sodxCommandList.Count; idx++)
                                    {
                                        sSodxCommand sodx = _sodxCommandList[idx];
                                        if (_filteredSignalList == null)
                                        {
                                            if ((sodx.SignalType == eSodxSignalType.Peak_Signals) && (sodx.CalculatedSignal == eSodxCalculatedSignal.Raw))
                                            {
                                                cCurve curve = cMagicGraphCurve.PrepareCurve(null, null, cRandomColor.IndexColor(idx), -1, -1, sodx.ToString());
                                                curve.Tag = new sFilteredSignal(sodx, _generalSettings.General.ResourceLanguage, null, curve.Color);
                                                if ((sodx.Signal == eSodxSignal.Altitude) || (sodx.Signal == eSodxSignal.Thickness))
                                                {
                                                    curve.YAxis = _graph.GraphPane.YAxis;
                                                    _graph.GraphPane.YAxis.IsVisible = true;
                                                    _graph.GraphPane.YAxis.MajorTic.IsOpposite = false;
                                                    _graph.GraphPane.YAxis.MinorTic.IsOpposite = false;
                                                    YAxisUnit = ((sFilteredSignal)curve.Tag).Unit;
                                                }
                                                else
                                                {
                                                    curve.Y2Axis = _graph.GraphPane.Y2Axis;
                                                    _graph.GraphPane.Y2Axis.IsVisible = true;
                                                    _graph.GraphPane.Y2Axis.MajorTic.IsOpposite = false;
                                                    _graph.GraphPane.Y2Axis.MinorTic.IsOpposite = false;
                                                    Y2AxisUnit = ((sFilteredSignal)curve.Tag).Unit;
                                                }
                                                _graph.AddCurve(curve);
                                                _curvesList.Add(curve);
                                            }
                                        }
                                        else
                                        {
                                            for (int udx = 0; udx < _filteredSignalList.Count; udx++)
                                            {
                                                sFilteredSignal filteredSignal = _filteredSignalList[udx];
                                                if ((filteredSignal.SignalType == sodx.SignalType) && (filteredSignal.CalculatedSignal == sodx.CalculatedSignal) && (filteredSignal.Signal == sodx.Signal))
                                                {
                                                    if ((sodx.SignalType == eSodxSignalType.Peak_Signals) && (sodx.CalculatedSignal == eSodxCalculatedSignal.Raw))
                                                    {
                                                        cCurve curve = cMagicGraphCurve.PrepareCurve(null, null, cRandomColor.IndexColor(idx), -1, -1, sodx.ToString());
                                                        curve.Tag = new sFilteredSignal(sodx, _generalSettings.General.ResourceLanguage, null, curve.Color);
                                                        if ((sodx.Signal == eSodxSignal.Altitude) || (sodx.Signal == eSodxSignal.Thickness))
                                                        {
                                                            curve.YAxis = _graph.GraphPane.YAxis;
                                                            _graph.GraphPane.YAxis.IsVisible = true;
                                                            _graph.GraphPane.YAxis.MajorTic.IsOpposite = false;
                                                            _graph.GraphPane.YAxis.MinorTic.IsOpposite = false;
                                                            YAxisUnit = ((sFilteredSignal)curve.Tag).Unit;
                                                        }
                                                        else
                                                        {
                                                            curve.Y2Axis = _graph.GraphPane.Y2Axis;
                                                            _graph.GraphPane.Y2Axis.IsVisible = true;
                                                            _graph.GraphPane.Y2Axis.MajorTic.IsOpposite = false;
                                                            _graph.GraphPane.Y2Axis.MinorTic.IsOpposite = false;
                                                            Y2AxisUnit = ((sFilteredSignal)curve.Tag).Unit;
                                                        }
                                                        _graph.AddCurve(curve);
                                                        _curvesList.Add(curve);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (_graph.GraphPane.YAxis.IsVisible)
                                    {
                                        _graph.GraphPane.YAxis.MinorGrid.IsVisible = true;
                                        _graph.GraphPane.YAxis.MajorGrid.IsVisible = true;
                                    }
                                    else if (_graph.GraphPane.Y2Axis.IsVisible)
                                    {
                                        _graph.GraphPane.Y2Axis.MinorGrid.IsVisible = true;
                                        _graph.GraphPane.Y2Axis.MajorGrid.IsVisible = true;
                                    }
                                    _graph.GraphPane.XAxis.Title.Text = _generalSettings.General.ResourceLanguage.GetString(cStringEnum.GetStringValue((eSignalUnit)XAxisUnit));
                                    _graph.GraphPane.YAxis.Title.Text = _generalSettings.General.ResourceLanguage.GetString(cStringEnum.GetStringValue((eSignalUnit)YAxisUnit));
                                    _graph.GraphPane.Y2Axis.Title.Text = _generalSettings.General.ResourceLanguage.GetString(cStringEnum.GetStringValue((eSignalUnit)Y2AxisUnit));
                                }
                                sAxisGraphic axisReference = _graph.AxisReference;
                                GetAxisInformations(ref _maxRefractiveIndex, ref axisReference);
                                SetAxisInformation(axisReference);
                            }));
                        }
                    }
                    #endregion
                    #region FifoEventThreadGui
                    if (_fifoEventThreadGui != null)
                    {
                        lock (_fifoEventThreadGui)
                        {
                            timeoutValue = (_fifoEventThreadGui.Count > 0) ? 0 : timeoutDefaultValue;
                        }
                    }
                    #endregion
                }
                _threadGui.EventExitProcessThreadDo.Set();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region ThreadFifoLoop
        /// <summary>This method is called when starting the thread.</summary> 
        public void ThreadFifoLoop()
        {
            try
            {
                const int timeoutDefaultValue = 10;
                const int timeoutDataSampleDefaultValue = 40;
                const int timeoutDataSamplePresentDefaultValue = 500;
                const int timeoutBlinkDefaultValue = 200;
                int timeoutDataSampleValue = timeoutDataSampleDefaultValue;
                int timeoutDataSamplePresentValue = timeoutDataSamplePresentDefaultValue;
                int timeoutBlinkValue = timeoutBlinkDefaultValue;

                while (!_threadFifo.EventExitProcessThread.WaitOne(timeoutDefaultValue))
                {
                    try
                    {
                        _mutex.WaitOne(-1);
                        #region Blink mode
                        if (_generalSettings != null)
                        {
                            if (_blink)
                            {
                                if (timeoutBlinkValue == 0)
                                {
                                    _blink = false;
                                    timeoutBlinkValue = timeoutBlinkDefaultValue;
                                    if (_threadGui != null)
                                    {
                                        _threadGui.EventUserList[(int)eEventThreadGui.eUpdateRunPause].Set();
                                    }
                                }
                                else
                                {
                                    timeoutBlinkValue -= timeoutDefaultValue;
                                }
                            }
                            else
                            {
                                if (timeoutBlinkValue == 0)
                                {
                                    _blink = true;
                                    timeoutBlinkValue = timeoutBlinkDefaultValue;
                                    if (_threadGui != null)
                                    {
                                        _threadGui.EventUserList[(int)eEventThreadGui.eUpdateRunPause].Set();
                                    }
                                }
                                else
                                {
                                    timeoutBlinkValue -= timeoutDefaultValue;
                                }
                            }
                        }
                        #endregion
                        #region FifoDataSample
                        if (_fifoDataSample != null)
                        {
                            lock (_fifoDataSample)
                            {
                                if (_fifoDataSample.Count > 0)
                                {
                                    //passage du mode absence de données au mode présence de données
                                    timeoutDataSamplePresentValue = timeoutDataSamplePresentDefaultValue;
                                    if (_isDataSample == false)
                                    {
                                        _isDataSample = true;
                                        if (_threadGui != null)
                                        {
                                            _threadGui.EventUserList[(int)eEventThreadGui.eUpdateRunPause].Set();
                                        }
                                    }
                                    while (_fifoDataSample.Count > 0)
                                    {
                                        _dataSample = (cDataSample)_fifoDataSample.Dequeue();
                                        timeoutDataSampleValue -= timeoutDefaultValue;
                                        if (timeoutDataSampleValue <= 0)
                                        {
                                            timeoutDataSampleValue = timeoutDataSampleDefaultValue;
                                            if (_dataSampleMode == eDataSampleMode.eRun)
                                            {
                                                _guiDataSample = _dataSample.Clone();
                                                _threadGui.EventUserList[(int)eEventThreadGui.eUpdateDataSample].Set();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    //absence de données prolongée ?
                                    if ((timeoutDataSamplePresentValue <= 0) && (_isDataSample))
                                    {
                                        _isDataSample = false;
                                        if (_threadGui != null)
                                        {
                                            _threadGui.EventUserList[(int)eEventThreadGui.eUpdateRunPause].Set();
                                        }
                                    }
                                    else
                                    {
                                        timeoutDataSamplePresentValue -= timeoutDefaultValue;
                                    }
                                }
                            }
                        }
                        #endregion                       
                    }
                    finally
                    {
                        _mutex.ReleaseMutex();
                    }
                }
                _threadFifo.EventExitProcessThreadDo.Set();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #endregion
        #region GetAxisInformations
        private void GetAxisInformations(ref double maxRefractiveIndex, ref sAxisGraphic axisConfiguration)
        {
            if ((_generalSettings != null) && (_sodxCommandList != null) && (_sodxCommandList.Count > 0))
            {
                maxRefractiveIndex = 0;
                axisConfiguration.Y2AxisScaleMax = 0;
                //recherche la répartition des types de signaux                
                lock (_sodxCommandList)
                {
                    for (int idx = 0; idx < _sodxCommandList.Count(); idx++)
                    {
                        sSodxCommand sodxCommand = _sodxCommandList[idx];
                        if (sodxCommand != null)
                        {
                            if (((sodxCommand.SignalType == eSodxSignalType.Peak_Signals) && (sodxCommand.ResultType == eSodxResultType.Measured)) || ((sodxCommand.ResultType == eSodxResultType.Calculated) && (sodxCommand.Signal == eSodxSignal.Thickness) && (sodxCommand.CalculatedSignal == eSodxCalculatedSignal.Raw)))
                            {
                                switch (sodxCommand.Signal)
                                {
                                    case eSodxSignal.Intensity_Level:
                                    case eSodxSignal.Intensity_Raw:
                                        break;
                                    case eSodxSignal.Thickness:
                                        switch (sodxCommand.PeakNumber)
                                        {
                                            case eSodxPeakNumber.Peak_1:
                                                maxRefractiveIndex = Math.Max(maxRefractiveIndex, _generalSettings.General.SodxCommand.Signal.RefractiveIndexTableThickness1.RefractiveIndexList[0].Value);
                                                break;
                                            case eSodxPeakNumber.Peak_2:
                                                maxRefractiveIndex = Math.Max(maxRefractiveIndex, _generalSettings.General.SodxCommand.Signal.RefractiveIndexTableThickness2.RefractiveIndexList[0].Value);
                                                break;
                                            case eSodxPeakNumber.Peak_3:
                                                maxRefractiveIndex = Math.Max(maxRefractiveIndex, _generalSettings.General.SodxCommand.Signal.RefractiveIndexTableThickness3.RefractiveIndexList[0].Value);
                                                break;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    maxRefractiveIndex = Math.Max(maxRefractiveIndex, 1);
                    if (_xAxisData != null)
                    {
                        axisConfiguration.XAxisScaleMax = _generalSettings.General.OpticalProbe.Pitch * (_generalSettings.General.Sensor.NumberOfFibers - 1); ;
                        axisConfiguration.XAxisScaleMin = 0;
                    }
                    else
                    {
                        axisConfiguration.XAxisScaleMax = (_generalSettings.General.Sensor.NumberOfFibers - 1);
                        axisConfiguration.XAxisScaleMin = 0;
                    }
                    axisConfiguration.YAxisScaleMin = 0;
                    axisConfiguration.YAxisScaleMax = Scale * maxRefractiveIndex;
                    axisConfiguration.Y2AxisScaleMin = 0;
                    if (_filteredSignalList != null)
                    {
                        foreach (sFilteredSignal filteredSignal in _filteredSignalList)
                        {
                            if (filteredSignal.Signal == eSodxSignal.Intensity_Level)
                            {
                                axisConfiguration.Y2AxisScaleMax = 100;
                            }
                            if (filteredSignal.Signal == eSodxSignal.Intensity_Raw)
                            {
                                axisConfiguration.Y2AxisScaleMax = 0x8000;
                            }
                        }
                    }
                    else
                    {
                        axisConfiguration.Y2AxisScaleMax = 100;
                    }
                }
            }
            else
            {
                maxRefractiveIndex = 1.0F;
            }
        }
        #endregion    
        #region SetAxisInformation
        private void SetAxisInformation(sAxisGraphic axisConfiguration)
        {
            _graph.GraphPane.XAxis.Scale.Min = axisConfiguration.XAxisScaleMin;
            _graph.GraphPane.XAxis.Scale.Max = axisConfiguration.XAxisScaleMax;
            _graph.GraphPane.YAxis.Scale.Min = axisConfiguration.YAxisScaleMin;
            _graph.GraphPane.YAxis.Scale.Max = axisConfiguration.YAxisScaleMax;
            _graph.GraphPane.Y2Axis.Scale.Min = axisConfiguration.Y2AxisScaleMin;
            _graph.GraphPane.Y2Axis.Scale.Max = axisConfiguration.Y2AxisScaleMax;
            _graph.GraphPane.YAxis.Scale.MinAuto = _scaleMaxAuto;
            _graph.GraphPane.YAxis.Scale.MaxAuto = _scaleMaxAuto;
            _graph.GraphPane.Y2Axis.Scale.MinAuto = _scaleMaxAuto;
            _graph.GraphPane.Y2Axis.Scale.MaxAuto = _scaleMaxAuto;
            _graph.IsEnableHZoom = (_scaleMaxAuto == false);
            _graph.IsEnableVZoom = (_scaleMaxAuto == false);
            _graph.AxisChange();
        }
        #endregion
        #region DataSample
        public cDataSample DataSample
        {
            set
            {
                if (_fifoDataSample != null)
                {
                    lock (_fifoDataSample)
                    {
                        _fifoDataSample.Enqueue(value);
                    }
                }
            }
        }
        #endregion    
        #region SaturationLevelIntensity
        public ushort SaturationLevelIntensity
        {
            get { return (_saturationLevelIntensity); }
            set { _saturationLevelIntensity = value; }
        }
        #endregion
        #region Scale
        public int Scale
        {
            get { return (_scale); }
            set
            {
                try
                {
                    _mutex.WaitOne(-1);
                    _scale = value;
                    if (_generalSettings.General.Sensor.NumberOfFibers <= 0)
                    {
                        throw new System.InvalidOperationException(string.Format("Number of fibers error."));
                    }
                    if ((_generalSettings == null) || (_generalSettings.OpticalProbesBase == null) || (_generalSettings.OpticalProbesBase.List.Count <= 0))
                    {
                        throw new System.InvalidOperationException(string.Format("Optical probes data base error."));
                    }
                    foreach (sOpticalProbe data in _generalSettings.OpticalProbesBase.List)
                    {
                        int margin_of_error = (int)Math.Round(data.Scale * 0.2);
                        if ((_scale - margin_of_error <= data.Scale) && (_scale + margin_of_error >= data.Scale))
                        {
                            _generalSettings.General.OpticalProbe = data;
                            _xAxisData = new double[_generalSettings.General.Sensor.NumberOfFibers];
                            for (int idx = 0; idx < _xAxisData.Length; idx++)
                            {
                                _xAxisData[idx] = (idx * data.Pitch);
                            }
                            break;
                        }
                    }
                    if (_xAxisData == null)
                    {
                        throw new System.InvalidOperationException(string.Format("Probe not referenced or marging error."));
                    }
                    if (_fifoEventThreadGui != null)
                    {
                        lock (_fifoEventThreadGui)
                        {
                            _fifoEventThreadGui.Enqueue(eEventThreadGui.eInitialize);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Error : {0}.{1} : {2}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _mutex.ReleaseMutex();
                }
            }
        }
        #endregion
        #region SetFilteredSignalList
        public void SetFilteredSignalList(List<sFilteredSignal> filteredSignalList)
        {
            try
            {
                _mutex.WaitOne(-1);
                _filteredSignalList = filteredSignalList;
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
        #endregion
        #region SetSodxCommandList
        public void SetSodxCommandList(List<sSodxCommand> sodxCommandList)
        {
            try
            {
                _mutex.WaitOne(-1);
                _sodxCommandList = sodxCommandList;
                if (_fifoEventThreadGui != null)
                {
                    lock (_fifoEventThreadGui)
                    {
                        _fifoEventThreadGui.Enqueue(eEventThreadGui.eInitialize);
                    }
                }
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
        #endregion
    }
}
