using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Xml.Serialization;
using System.Windows.Forms;
using MagicCommonLibrary;
using MagicServerLibrary;

namespace MagicAddOn
{
    //--------------------------------------------------------------------------------------
    public class cSaveFilteredData : IDisposable
    {
        bool _disposed = false;
        Mutex _mutex = null;
        cSelectingFilters _selectingFilters = null;
        int _scale = 0;
        ushort _saturationLevelIntensity = 0;

        public cSaveFilteredData(cSelectingFilters selectingFilters)
        {
            System.Guid guid = System.Guid.NewGuid();
            _mutex = new Mutex(false, guid.ToString("N"));
            _selectingFilters = selectingFilters;
        }
        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    CloseFiles();
                    // Free other state (managed objects).                    
                    if (_mutex != null)
                    {
                        _mutex.Dispose();
                        _mutex = null;
                    }
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
                }

                finally
                {
                    _mutex.ReleaseMutex();
                }
            }
        }
        #endregion
        #region SaturationLevelIntensity
        public ushort SaturationLevelIntensity
        {
            get { return (_saturationLevelIntensity); }
            set
            {
                try
                {
                    _mutex.WaitOne(-1);
                    _saturationLevelIntensity = value;
                }

                finally
                {
                    _mutex.ReleaseMutex();
                }
            }
        }
        #endregion
        #region OpenFiles
        public bool OpenFiles(string directory)
        {
            try
            {
                _mutex.WaitOne(-1);
                if (_selectingFilters != null)
                {
                    foreach (sSelectingFilter selectingFilter in _selectingFilters.List)
                    {
                        if ((selectingFilter.CheckBox != null) && (selectingFilter.CheckBox.Checked))
                        {
                            selectingFilter.OpenFile(directory);
                        }
                    }
                }
                return (true);
            }
            catch
            {
                return (false);
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
        #endregion
        #region WriteFile
        public bool WriteFile(sSignalData signalData, eSeparatorCharacter separator)
        {
            double[] arrDbl = null;

            char separatorChar = (separator == eSeparatorCharacter.Semicolon) ? ';' : ' ';
            if ((signalData != null) && (_selectingFilters != null))
            {
                string[] str = new string[signalData.PointCount];
                sSelectingFilter selectingFilter = _selectingFilters.IsSelected(signalData);
                if (selectingFilter != null)
                {
                    if (signalData.Signal == eSodxSignal.Altitude)
                    {
                        arrDbl = signalData.AltitudeToArrayDouble(_scale);
                        for (int idx = 0; idx < signalData.PointCount; idx++)
                        {
                            selectingFilter.WriteFile(string.Format("{0}{1}", (int)(arrDbl[idx] * 1000), separatorChar));
                        }
                    }
                    else if (signalData.Signal == eSodxSignal.Thickness)
                    {
                        arrDbl = signalData.ThicknessToArrayDouble(_scale);
                        for (int idx = 0; idx < signalData.PointCount; idx++)
                        {
                            selectingFilter.WriteFile(string.Format("{0}{1}", (int)(arrDbl[idx] * 1000), separatorChar));
                        }
                    }
                    else if ((signalData.Signal == eSodxSignal.Intensity_Level) || (signalData.Signal == eSodxSignal.Intensity_Raw))
                    {
                        arrDbl = (signalData.Signal == eSodxSignal.Intensity_Level) ? signalData.IntensityLevelToArrayDouble(SaturationLevelIntensity) : signalData.DataToArrayDouble;
                        for (int idx = 0; idx < signalData.PointCount; idx++)
                        {
                            selectingFilter.WriteFile(string.Format("{0}{1}", arrDbl[idx], separatorChar));
                        }
                    }
                    else if ((signalData.Signal == eSodxSignal.Roughness) || (signalData.Signal == eSodxSignal.Waviness))
                    {
                        arrDbl = signalData.DataToArrayDouble;
                        for (int idx = 0; idx < signalData.PointCount; idx++)
                        {
                            selectingFilter.WriteFile(string.Format("{0}{1}", arrDbl[idx], separatorChar));
                        }
                    }
                    else if (signalData.SignalType == eSodxSignalType.Global_Signals)
                    {
                        selectingFilter.WriteFile(string.Format("{0}{1}", signalData.DataToString, separatorChar));
                    }
                    selectingFilter.WriteLineFile("");
                    return (true);
                }
            }
            return (false);
        }
        #endregion
        #region CloseFiles
        public bool CloseFiles()
        {
            try
            {
                _mutex.WaitOne(-1);
                if (_selectingFilters != null)
                {
                    foreach (sSelectingFilter selectingFilter in _selectingFilters.List)
                    {
                        selectingFilter.CloseFile();
                    }
                }
                return (true);
            }
            catch
            {
                return (false);
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
        #endregion
    }
    //--------------------------------------------------------------------------------------
}
