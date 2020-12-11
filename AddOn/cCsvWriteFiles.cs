using MagicCommonLibrary;
using MagicServerLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Velociraptor.AddOn
{
    #region cCsvWriteFiles
    public class cCsvWriteFiles : IDisposable
    {
        bool _disposed = false;
        //sProjectSettings _projectSettings = null;
        List<sCsvWriteFiles> _filelist = new List<sCsvWriteFiles>();
        bool _isOpen = false;
        
        public List<double> data1dlist = new List<double>();
        cProjectSettings _cprojectSettings = new cProjectSettings();   
        StreamWriter _streamWriter = null;
        #region Constructor
        public cCsvWriteFiles()
        {
            
        }
        #endregion
        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {

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

        #region Open
        public bool Open(cProjectSettings projectSettings, string directory, string fileName,  double NumberOfSamples, int ScanningMode, int DataDirection, int ZPos)
        {           
            Close();
            if (projectSettings != null)
            {
                #region write        
                sCsvWriteFiles _file = new sCsvWriteFiles(eSodxSignal.Altitude, eSodxPeakNumber.Peak_1);
                sCsvWriteFiles _fileposx = new sCsvWriteFiles(eSodxSignal.Global_Signal_Start_Position_X, eSodxPeakNumber.Unknow);
                sCsvWriteFiles _fileposy = new sCsvWriteFiles(eSodxSignal.Global_Signal_Start_Position_Y, eSodxPeakNumber.Unknow);
                sCsvWriteFiles _fileposz = new sCsvWriteFiles(eSodxSignal.Global_Signal_Start_Position_Z, eSodxPeakNumber.Unknow);
                sCsvWriteFiles _fileintensity = new sCsvWriteFiles(eSodxSignal.Intensity_Raw, eSodxPeakNumber.Peak_1);
                string csvFileName = Path.Combine(directory, fileName);
                if (_streamWriter != null)
                {
                    _streamWriter.Flush();
                    _streamWriter.Close();
                    _streamWriter = null;
                }
                _streamWriter = new StreamWriter(csvFileName);
                _streamWriter.Write(string.Format("{0}", NumberOfSamples));
                _streamWriter.WriteLine("");
                if (ScanningMode == 0)
                {
                    _streamWriter.Write(string.Format("5"));
                    _streamWriter.WriteLine("");     
                }
                else
                {
                    _streamWriter.Write(string.Format("1"));
                    _streamWriter.WriteLine("");  
                }
                _streamWriter.Write(string.Format("{0}", DataDirection));
                _streamWriter.WriteLine("");
                _streamWriter.Write(string.Format("{0}", ZPos));
                _streamWriter.WriteLine("");
                _filelist.Add(_fileposx);
                _filelist.Add(_fileposy);
                //_filelist.Add(_fileposz);
                _filelist.Add(_file);
                _filelist.Add(_fileintensity);
                #endregion

                _isOpen = true;
            }
            return (_isOpen);
        }
        #endregion
        #region Close
        public bool Close()
        {
            for (int idx = 0; idx < _filelist.Count; idx++)
            {
                sCsvWriteFiles _file = _filelist[idx];
                if (_streamWriter != null)
                {
                    _streamWriter.Flush();
                    _streamWriter.Close();
                    _streamWriter = null;
                }
                Dispose(true);
                GC.SuppressFinalize(this);
                _file = null;
            }
            _filelist.Clear();
            data1dlist.Clear();
            
            _isOpen = false;
            return (true);
        }
        #endregion
        #region Add
        public bool Add(cDataSample dataSample)
        {
            
            if ((dataSample != null) && (dataSample.SignalDataList != null)&&(_streamWriter!=null))
            {
                
                for (int idx = 0; idx < dataSample.SignalDataList.Count; idx++)
                {
                    sSignalData signalData = dataSample.SignalDataList[idx];
                    sSodxCommand sodxCommand = dataSample.SodxCommandList[idx];
                    signalData.DataType = eDataType.LongInt;
                    sodxCommand.DataType = eDataType.LongInt;

                    foreach (sCsvWriteFiles wFile in _filelist.ToArray())
                        {
                           if ((wFile.Signal == sodxCommand.Signal) && (wFile.PeakNumber == sodxCommand.PeakNumber))
                           {
                            
                            switch (sodxCommand.Signal)
                              {
                                case eSodxSignal.Global_Signal_Start_Position_X:                 
                                    if (_streamWriter != null) 
                                    {
                                        //_streamWriter.Write(string.Format("{0},", signalData.DataToDouble));
                                        data1dlist.Add( signalData.DataToDouble );
                                    }
                                    break;
                                case eSodxSignal.Global_Signal_Start_Position_Y:
                                    if (_streamWriter != null)
                                    {
                                        //_streamWriter.Write(string.Format("{0},", signalData.DataToDouble));
                                        data1dlist.Add( signalData.DataToDouble);
                                    }
                                    break;
                                //case eSodxSignal.Global_Signal_Start_Position_Z:
                                //    if (_streamWriter != null)
                                //    {
                                //        //_streamWriter.Write(string.Format("{0},", signalData.DataToDouble));
                                //        data1dlist.Add(signalData.DataToDouble);
                                //    }
                                //    break;
                                case eSodxSignal.Altitude:
                                    if ((_streamWriter != null) && (signalData.DataToArrayDouble != null) && (signalData.DataToArrayDouble.Length == 192))
                                    {

                                        for (int idy = 0; idy < signalData.DataToArrayDouble.Length; idy++)
                                        {
                                            if (Math.Round(signalData.AltitudeToArrayDouble(230)[idy]) == 230)
                                            {
                                                //_streamWriter.Write(string.Format("0,"));
                                                data1dlist.Add(0);
                                            }
                                            else
                                            {
                                                //_streamWriter.Write(string.Format("{0},", Math.Round(signalData.AltitudeToArrayDouble(230)[idy], 2, MidpointRounding.AwayFromZero)));
                                                data1dlist.Add(signalData.AltitudeToArrayDouble(230)[idy]);

                                            }
                                        }
                                        
                                        //if (Math.Round(signalData.AltitudeToArrayDouble(230)[signalData.DataToArrayDouble.Length - 1]) == 230)
                                        //{
                                        //    //_streamWriter.Write(string.Format("0,"));

                                        //    data1dlist.Add(0);

                                        //}
                                        //else
                                        //{
                                        //    //_streamWriter.Write(string.Format("{0},", Math.Round(signalData.AltitudeToArrayDouble(230)[signalData.DataToArrayDouble.Length - 1], 2, MidpointRounding.AwayFromZero)));
                                        //    data1dlist.Add(signalData.AltitudeToArrayDouble(230)[signalData.DataToArrayDouble.Length - 1]);          
                                        //}

                                    }
                                    break;
                                case eSodxSignal.Intensity_Raw:
                                    if ((_streamWriter != null))
                                    {

                                        for (int idy = 0; idy < signalData.DataToArrayDouble.Length; idy++)
                                        {
                                            //_streamWriter.Write(string.Format("{0},", signalData.DataToArrayDouble[idy]));
                                            data1dlist.Add(signalData.DataToArrayDouble[idy]);
                                        }
                                        //_streamWriter.Write(string.Format("{0}", signalData.DataToArrayDouble[signalData.DataToArrayDouble.Length - 1]));
                                        //_streamWriter.WriteLine();

                                    }
                                    break;
                            }
                               
                            }
                        }
                }
                
                return (true);
            }
            return (false);

        }
        #endregion
        #region IsOpen
        public bool IsOpen
        {
            get { return (_isOpen); }
        }
        #endregion
        #region WriteList
        public bool WriteList(cProjectSettings projectSettings,  int NumberOfSamples , int ScanningMode)
        {

           
                
                if (ScanningMode == 0)
                {
                if (data1dlist.Count < NumberOfSamples * 386)
                {
                    MessageBox.Show("請重掃!!");
                    return (false);
                }
                for (int n = 0; n < (data1dlist.Count) / 386; n++)
                    {
                        for (int i = 0; i < 386; i++)
                        {              
                            if (i == 385)
                            {
                                _streamWriter.Write(string.Format("{0}", data1dlist[i + n * 386]));
                            }
                            else
                            {
                                _streamWriter.Write(string.Format("{0},", data1dlist[i + n * 386]));
                            }
                        }
                        _streamWriter.WriteLine("");
                    }
                }
            if (ScanningMode == 1)
            {
                if (data1dlist.Count < NumberOfSamples * 386 * 5)
                {
                    MessageBox.Show("請重掃!!");
                    return (false);
                }
                //if (data1dlist.Count < NumberOfSamples * 387 * 5)
                //{
                //    MessageBox.Show("請重掃!!");
                //    return (false);
                //}
                //for (int n = 0; n < (data1dlist.Count) / 387 / 5; n++)
                //{
                //    _streamWriter.Write(string.Format("{0},", data1dlist[n * 387]));
                //    _streamWriter.Write(string.Format("{0},", data1dlist[1 + n * 387]));
                //    _streamWriter.Write(string.Format("{0},", data1dlist[2 + n * 387]));
                //    for (int i = 3; i < 387; i++)
                //    {
                //        _streamWriter.Write(string.Format("{0},", data1dlist[i + n * 387]));
                //        _streamWriter.Write(string.Format("{0},", data1dlist[i + (2 * NumberOfSamples - 1 - n) * 387]));
                //        _streamWriter.Write(string.Format("{0},", data1dlist[i + (2 * NumberOfSamples + n) * 387]));
                //        _streamWriter.Write(string.Format("{0},", data1dlist[i + (4 * NumberOfSamples - 1 - n) * 387]));

                //        if (i == 386)
                //        {
                //            _streamWriter.Write(string.Format("{0}", data1dlist[i + (4 * NumberOfSamples + n) * 387]));
                //        }
                //        else
                //        {
                //            _streamWriter.Write(string.Format("{0},", data1dlist[i + (4 * NumberOfSamples + n) * 387]));
                //        }
                //    }
                //    _streamWriter.WriteLine("");
                //}

                for (int n = 0; n < (data1dlist.Count) / 386 / 5; n++)
                {
                    _streamWriter.Write(string.Format("{0},", data1dlist[n * 386]));
                    _streamWriter.Write(string.Format("{0},", data1dlist[1 + n * 386]));
                    for (int i = 2; i < 386; i++)
                    {
                        _streamWriter.Write(string.Format("{0},", data1dlist[i + n * 386]));
                        _streamWriter.Write(string.Format("{0},", data1dlist[i + (2 * NumberOfSamples - 1 - n) * 386]));
                        _streamWriter.Write(string.Format("{0},", data1dlist[i + (2 * NumberOfSamples + n) * 386]));
                        _streamWriter.Write(string.Format("{0},", data1dlist[i + (4 * NumberOfSamples - 1 - n) * 386]));

                        if (i == 385)
                        {
                            _streamWriter.Write(string.Format("{0}", data1dlist[i + (4 * NumberOfSamples + n) * 386]));
                        }
                        else
                        {
                            _streamWriter.Write(string.Format("{0},", data1dlist[i + (4 * NumberOfSamples + n) * 386]));
                        }
                    }
                    _streamWriter.WriteLine("");
                }

                //for (int n = 0; n < (data1dlist.Count) / 386; n++)
                //{
                //    for (int i = 0; i < 386; i++)
                //    {
                //        if (i == 385)
                //        {
                //            _streamWriter.Write(string.Format("{0}", data1dlist[i + n * 386]));
                //        }
                //        else
                //        {
                //            _streamWriter.Write(string.Format("{0},", data1dlist[i + n * 386]));
                //        }
                //    }
                //    _streamWriter.WriteLine("");
                //}
                //for (int n = 0; n < (data1dlist.Count) / 387; n++)
                //{
                //    for (int i = 0; i < 387; i++)
                //    {
                //        if (i == 386)
                //        {
                //            _streamWriter.Write(string.Format("{0}", data1dlist[i + n * 387]));
                //        }
                //        else
                //        {
                //            _streamWriter.Write(string.Format("{0},", data1dlist[i + n * 387]));
                //        }
                //    }
                //    _streamWriter.WriteLine("");
                //}
                #region Recording = false
                _cprojectSettings.Project.Recording = false;
                #endregion
                _isOpen = true;
            }
            return (_isOpen);
        }
        #endregion

    }
    #endregion


    #region sCsvWriteFiles
    public class sCsvWriteFiles : IDisposable
    {
        #region eFileType
        public enum eFileType : byte
        {
            /// <summary>Csv</summary>
            [StringValue("Csv")]
            Csv = 0x00,
            /// <summary>Csv</summary>
            [StringValue("txt")]
            txt = 0x01,
            /// <summary>Csv</summary>
            [StringValue("data")]
            data = 0x02,
        }
        #endregion
        bool _disposed = false;

        StreamWriter _streamWriter = null;
        eSodxSignal _signal = eSodxSignal.Unknow;
        eSodxPeakNumber _peakNumber = eSodxPeakNumber.Unknow;
        
        #region Constructor
        public sCsvWriteFiles(eSodxSignal signal, eSodxPeakNumber peakNumber)
        {
            _signal = signal;
            _peakNumber = peakNumber;
            
        }
        #endregion
        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {

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
        #region Open
        public bool Open(string filename, eFileType fileType, cProjectSettings projectSettings)
        {
            #region Csv
            if (fileType == eFileType.Csv)
            {
                string csvFileName = Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename)) + ".csv";
                Close();
                _streamWriter = new StreamWriter(csvFileName);
                _streamWriter.Write(string.Format("{0}", projectSettings.Project.NumberOfSamples));
                _streamWriter.WriteLine("");
                return (true);
            }
            #endregion
            #region Txt
            if (fileType == eFileType.txt)
            {
                string csvFileName = Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename)) + ".txt";
                Close();
                _streamWriter = new StreamWriter(csvFileName);
                _streamWriter.Write(string.Format("{0}", projectSettings.Project.NumberOfSamples));
                _streamWriter.WriteLine("");
                return (true);
            }
            #endregion
            #region Data
            if (fileType == eFileType.data)
            {
                string csvFileName = Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename)) + ".data";
                Close();
                _streamWriter = new StreamWriter(csvFileName);
                _streamWriter.Write(string.Format("{0}", projectSettings.Project.NumberOfSamples));
                _streamWriter.WriteLine("");
                return (true);
            }
            #endregion
            return (false);
        }
        #endregion
        #region Close
        public bool Close()
        {
            if (_streamWriter != null)
            {
                _streamWriter.Flush();
                _streamWriter.Close();
                _streamWriter = null;
            }
            return (true);
        }
        #endregion
        #region WriteShortArray
        public bool WriteShortArray(short[] value)
        {
            if ((_streamWriter != null) && (value != null) && (value.Length > 0))
            {
                for (int idx = 0; idx < value.Length; idx++)
                {
                    _streamWriter.Write(string.Format("{0};", value[idx]));
                }
                _streamWriter.WriteLine();
            }
            return (true);
        }
        #endregion
        #region WriteDoubleArray
        public bool WriteDoubleArray(double[] value)
        {
            if ((_streamWriter != null) && (value != null) && (value.Length > 0))
            {
                for (int idx = 0; idx < value.Length-1; idx++)
                {
                    _streamWriter.Write(string.Format("{0},", value[idx]));
                }
                _streamWriter.Write(string.Format("{0}", value[value.Length - 1]));
                _streamWriter.WriteLine();
            }
            return (true);
        }
        #endregion
        #region Signal
        public eSodxSignal Signal
        {
            get { return (_signal); }
        }
        #endregion
        #region PeakNumber
        public eSodxPeakNumber PeakNumber
        {
            get { return (_peakNumber); }
        }
        #endregion
        
    }
#endregion

}
