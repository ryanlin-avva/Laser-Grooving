using MagicCommonLibrary;
using MagicServerLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Velociraptor.AddOn
{
    #region cCsvWriteFiles
    public class CsvWriteFile : IDisposable
    {

        sCsvWriteFiles _file = null;
        int _scan_mode;
        int _line_cnt = 1;
        LineKeeper[] line_keeper = new LineKeeper[5];
        public string ErrMsg { get { return _file.ErrMsg;  } }
        public bool IsOpen { get { return _file.IsOpen();  } }

        #region Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
        #region Open
        public bool Open(string directory, string fileName, int ScanningMode)
        {
            Close();
            _scan_mode = ScanningMode;
            _line_cnt = (_scan_mode == 5) ? 1 : 5;
            for (int i = 0; i < _line_cnt; i++)
            {
                line_keeper[i] = new LineKeeper();
            }

            _file = new sCsvWriteFiles();
            return _file.Open(Path.Combine(directory, fileName));
        }
        #endregion
        #region Close
        public void Close()
        {
            if (_file != null)
            {
                _file.Close();
                _file.Dispose();
                _file = null;
            }
            Dispose();
        }
        #endregion
        #region Add
        public bool Add(List<sSignalData> signalDataList, int line=0)
        {
            if (signalDataList == null || signalDataList.Count == 0) return false;
            if ((line % 2) != 0)
                line_keeper[line].Add(signalDataList);
            else
                line_keeper[line].Insert(0, signalDataList);
            return (true);
        }
        #endregion
        #region Save
        public bool Save(int DataDirection, int ZPos)
        {
            //檢查資料正確性
            int cnt = line_keeper[0].Count;
            for (int i = 1; i < _line_cnt; i++)
            {
                if (cnt != line_keeper[i].Count)
                {
                    MessageBox.Show(string.Format("Line{0}資料總筆數{1}不等於標準筆數{2}，請重新操作!!"
                                    , i, line_keeper[i].Count, cnt));
                    return (false);
                }
            }
            
            _file.WriteLine(cnt);
            _file.WriteLine(_line_cnt);
            _file.WriteLine(DataDirection);
            _file.WriteLine(ZPos);
            int line_points = line_keeper[0].Altitude(0).Count;
            //寫入每一列
            for (int j = 0; j < cnt; j++)
            {
                _file.Write(line_keeper[0].PosX(j));
                _file.Write(line_keeper[0].PosY(j));
                for (int k = 0; k < line_points; k++)
                {
                    for (int i = 0; i < _line_cnt; i++)
                        _file.Write(line_keeper[i].Altitude(j)[k]);
                }
                for (int k = 0; k < line_points; k++)
                {
                    for (int i = 0; i < _line_cnt; i++)
                    {
                        if (k == line_points - 1 && i == _line_cnt - 1)
                            _file.WriteEnd(line_keeper[i].Intensity(j)[k]);
                        else
                            _file.Write(line_keeper[i].Intensity(j)[k]);
                    }
                }              
            }
            return true;
        }
        #endregion
    }
    #endregion


    #region sCsvWriteFiles
    public class sCsvWriteFiles : IDisposable
    {
        bool _isOpen = false;
        StreamWriter _streamWriter = null;
        public string ErrMsg = "";
        #region Dispose
        protected virtual void Dispose(bool disposing) { }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        #region Open
        public bool Open(string filename)
        {
            try
            {
                _streamWriter = new StreamWriter(filename);
                ErrMsg = "OK";
                _isOpen = true;
                return true;
            } catch (Exception e)
            {
                ErrMsg = e.Message;
                return false;
            }
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
            _isOpen = false;
            return (true);
        }
        #endregion
        #region Write
        //Integer
        public bool Write(int value)
        {
            if ((_streamWriter != null))
                _streamWriter.Write(string.Format("{0},", value));
            return (true);
        }
        public bool WriteLine(int value)
        {
            if ((_streamWriter != null))
                _streamWriter.WriteLine(string.Format("{0}", value));
            return (true);
        }
       
        public bool WriteArray(int[] value)
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
        // Double
        public bool Write(double value)
        {
            if ((_streamWriter != null))
                _streamWriter.Write(string.Format("{0},", value));
            return (true);
        }
        public bool WriteEnd(double value)
        {
            if ((_streamWriter != null))
                _streamWriter.Write(string.Format("{0}", value));
            return (true);
        }
        public bool WriteList(List<double> values, bool with_end = false)
        {
            if ((_streamWriter == null)) return false;
            if (!with_end)
            { 
                foreach (double v in values)
                    _streamWriter.Write(string.Format("{0},", v));
            } 
            else
            {
                for (int i=0; i<values.Count-1; i++)
                    _streamWriter.Write(string.Format("{0},", values[i]));
                _streamWriter.WriteLine(string.Format("{0}", values[values.Count - 1]));
            }
            return (true);
        }
        public bool WriteArray(double[] value)
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
        public bool IsOpen()
        {
            return _isOpen;
        }
    }
    #endregion
    public class DataKeeper:IDisposable
    {
        List<double> intensity = new List<double>();
        List<double> altitude = new List<double>();
        public int Pos_x { get; set; }
        public int Pos_y { get; set; }
        public List<double> Intensity { get { return intensity; } }
        public List<double> Altitude { get { return altitude; } }
        public int DataCount { get { return intensity.Count; } }

        public void Dispose()
        {
            intensity.Clear();
            intensity = null;
            altitude.Clear();
            altitude = null;
        }
        public void Add(List<sSignalData> signalDataList)
        {
            foreach (sSignalData signalData in signalDataList)
            {
                signalData.DataType = eDataType.LongInt;
                switch (signalData.Signal)
                {
                    case eSodxSignal.Global_Signal_Start_Position_X:
                        Pos_x = (int)signalData.DataToDouble;
                        break;
                    case eSodxSignal.Global_Signal_Start_Position_Y:
                        Pos_y = (int)signalData.DataToDouble;
                        break;
                    case eSodxSignal.Altitude:
                        if ((signalData.DataToArrayDouble != null) && (signalData.DataToArrayDouble.Length == 192))
                        {
                            double[] temp = signalData.AltitudeToArrayDouble(230);
                            for (int idy = 0; idy < signalData.DataToArrayDouble.Length; idy++)
                                if (temp[idy] == 230) temp[idy] = 0;
                            altitude = temp.ToList();
                        }
                        break;
                    case eSodxSignal.Intensity_Raw:
                        intensity = signalData.DataToArrayDouble.ToList();
                        break;
                }
            }
        }
    }
    public class LineKeeper
    {
        List<DataKeeper> data = new List<DataKeeper>();
        public void Add(List<sSignalData> signalList)
        {
            DataKeeper dk = new DataKeeper();
            dk.Add(signalList);
            data.Add(dk);
        }
        public void Insert(int idx, List<sSignalData> signalList)
        {
            DataKeeper dk = new DataKeeper();
            dk.Add(signalList);
            data.Insert(idx, dk);
        }

        public int Count { get { return data.Count; } }
        public int PosX(int idx) { return data[idx].Pos_x; }
        public int PosY(int idx) { return data[idx].Pos_y; }
        public List<double> Altitude(int idx) { return data[idx].Altitude; }
        public List<double> Intensity(int idx) { return data[idx].Intensity; }
    }
}
