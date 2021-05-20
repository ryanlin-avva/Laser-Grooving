using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using MotionAPI;

namespace Velociraptor
{
    public class ParamReader
    {
        private string filePath;
        private StringBuilder lpReturnedString;
        private int bufferSize;
        #region pos parameter
        public int moveToWaferCenterPointXDistance;
        public int moveToWaferCenterPointYDistance;
        public int moveToWaferCenterPointZDistance;
        public int moveToWaferCenterPointRDistance;
        public int moveToWaferUnloadPointYDistance;
        #endregion
        public int ScanningMode;
        public int DataDirection { get; set; }
        public int TriggerInterval;
        public string SavingPath { get; set; }
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string lpString, string lpFileName);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        public ParamReader(string iniPath)
        {
            filePath = iniPath;
            bufferSize = 512;
            lpReturnedString = new StringBuilder(bufferSize);

            //Get Wafer Center Position
            moveToWaferCenterPointXDistance = int.Parse(ReadIniFile("Geometry", "moveToWaferCenterPointXDistance", "0"));
            moveToWaferCenterPointYDistance = int.Parse(ReadIniFile("Geometry", "moveToWaferCenterPointYDistance", "0"));
            moveToWaferCenterPointZDistance = int.Parse(ReadIniFile("Geometry", "moveToWaferCenterPointZDistance", "0"));
            moveToWaferCenterPointRDistance = int.Parse(ReadIniFile("Geometry", "moveToWaferCenterPointRDistance", "0"));
            moveToWaferUnloadPointYDistance = int.Parse(ReadIniFile("Geometry", "moveToWaferUnloadPointYDistance", "0"));

            SavingPath = ReadIniFile("ScanParameter", "SavePath", "C:/Avva");
            DataDirection = int.Parse(ReadIniFile("ScanParameter", "DataDirection", "0"));
            TriggerInterval = int.Parse(ReadIniFile("TriggerParameter", "SetTriggerInterval", "0"));
        }
        public void GetDistance2Measure(ref int[] dist)
        {
            //X軸必須位移500um，做為相對起始掃描位置
            dist[0] = int.Parse(ReadIniFile("Geometry", "RelToMeasureCameraX", "0"))-500;
            dist[1] = int.Parse(ReadIniFile("Geometry", "RelToMeasureCameraY", "0"));
            dist[2] = int.Parse(ReadIniFile("Geometry", "RelToMeasureCameraZ", "0"));
        }
        // read ini date depend on section and key
        private string ReadIniFile(string section, string key, string defaultValue)
        {
            lpReturnedString.Clear();
            GetPrivateProfileString(section, key, defaultValue, lpReturnedString, bufferSize, filePath);
            
            return lpReturnedString.ToString();
        }
    }
}
