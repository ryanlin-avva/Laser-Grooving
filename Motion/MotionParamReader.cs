using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using MotionAPI;
using System.IO;

namespace Avva.MotionFramework
{
    public class MotionParamReader
    {
        private string filePath;
        private StringBuilder lpReturnedString;
        private int bufferSize;
        #region axis parameter
        private int axis_x;
        private int axis_y;
        private int axis_z;
        private int axis_r;
        private int axis_a; //leave for extension
        private int axis_b;
        private int _axis_num;
        #endregion
        private AxisData[] _axisData;
        private AxisData[] _homeData;
        private double[] _units;
        private bool _is_sim;
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        public bool IsSimulate { get { return _is_sim; } }
        public MotionParamReader(string iniPath)
        {
            filePath = iniPath;
            bufferSize = 512;
            lpReturnedString = new StringBuilder(bufferSize);

            axis_x = int.Parse(ReadIniFile("AxisMapping", "X", "-1"));
            axis_y = int.Parse(ReadIniFile("AxisMapping", "Y", "-1"));
            axis_z = int.Parse(ReadIniFile("AxisMapping", "Z", "-1"));
            axis_r = int.Parse(ReadIniFile("AxisMapping", "R", "-1"));
            axis_a = int.Parse(ReadIniFile("AxisMapping", "A", "-1"));
            axis_b = int.Parse(ReadIniFile("AxisMapping", "B", "-1")); 
            _axis_num = int.Parse(ReadIniFile("AxisMapping", "Num", "4"));
            _is_sim = int.Parse(ReadIniFile("AxisMapping", "Simulate", "1")) == 1? true : false;
            _axisData = new AxisData[_axis_num];
            _homeData = new AxisData[_axis_num];
            _units = new double[_axis_num];
            string[] sections = { "MotorParameter", "HomeParameter" };
            for (int i = 0; i < _axis_num; i++)
            {
                //Moving Unit Mapping
                string unitphrase = "unit_" + i.ToString();
                _units[i] = int.Parse(ReadIniFile("AxisMapping", unitphrase, "1"));
                //Axis Speed Setting
                string phrase = "Axis" + i.ToString();
                _axisData[i] = new AxisData();
                _homeData[i] = new AxisData();
                AxisData[] data = { _axisData[i], _homeData[i] };
                for (int s=0; s<sections.Length; s++)
                {
                    data[s].Velocity = double.Parse(ReadIniFile(sections[s], phrase + "VelData", "0"));
                    data[s].Acceleration = double.Parse(ReadIniFile(sections[s], phrase + "AccData", "0"));
                    data[s].Deceleration = double.Parse(ReadIniFile(sections[s], phrase + "DecData", "0"));
                }
            }
        }
        public int BuildAxisMapping(Dictionary<char, int> axis_map)
        {
            axis_map.Add('X', axis_x);
            axis_map.Add('Y', axis_y);
            axis_map.Add('Z', axis_z);
            axis_map.Add('R', axis_r);
            axis_map.Add('A', axis_a);
            axis_map.Add('B', axis_b);
            return _axis_num;
        }
        public AxisData[] GetAllAxisData()
        {
            return _axisData;
        }

        public AxisData GetAxisData(int idx)
        {
            if (idx >= _axis_num)
                throw new AvvaMotionException("Axis number exceeded");
            return _axisData[idx];
        }
        public AxisData[] GetHomeData()
        {
            return _homeData;
        }
        public double[] Units { get { return _units; } }
        // read ini date depend on section and key
        private string ReadIniFile(string section, string key, string defaultValue)
        {
            lpReturnedString.Clear();
            GetPrivateProfileString(section, key, defaultValue, lpReturnedString, bufferSize, filePath);
            
            return lpReturnedString.ToString();
        }
    }
    public class AxisData
    {
        public double Velocity { get; set; }
        public double Acceleration { get; set; }
        public double Deceleration { get; set; }
    }
    public class MotionParamWriter
    {
        private string filePath;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string lpString, string lpFileName);

        public MotionParamWriter(string iniPath)
        {
            filePath = iniPath;
        }
        // write ini data depend on section and key
        private void WriteIniFile(string section, string key, Object value)
        {
            WritePrivateProfileString(section, key, value.ToString(), filePath);
        }
    }
}
