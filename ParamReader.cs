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
        // pos parameters
        public int MoveToWaferCenterPointXDistance { get; set; }
        public int MoveToWaferCenterPointYDistance { get; set; }
        public int MoveToWaferCenterPointZDistance { get; set; }
        public int MoveToWaferCenterPointRDistance { get; set; }
        public int MoveToWaferUnloadPointYDistance { get; set; }
        public int RelToMeasureCameraX { get; set; }
        public int RelToMeasureCameraY { get; set; }
        public int RelToMeasureCameraZ { get; set; }
        // camera parameters
        public int MaxMagAutoFocusBegin { get; set; }
        public int MaxMagAutoFocusEnd { get; set; }
        public int MinMagAutoFocusBegin { get; set; }
        public int MinMagAutoFocusEnd { get; set; }
        // scan parameters
        public int DataDirection { get; set; }
        public int TriggerInterval { get; set; }
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
            MoveToWaferCenterPointXDistance = int.Parse(ReadIniFile("Geometry", "moveToWaferCenterPointXDistance", "0"));
            MoveToWaferCenterPointYDistance = int.Parse(ReadIniFile("Geometry", "moveToWaferCenterPointYDistance", "0"));
            MoveToWaferCenterPointZDistance = int.Parse(ReadIniFile("Geometry", "moveToWaferCenterPointZDistance", "0"));
            MoveToWaferCenterPointRDistance = int.Parse(ReadIniFile("Geometry", "moveToWaferCenterPointRDistance", "0"));
            MoveToWaferUnloadPointYDistance = int.Parse(ReadIniFile("Geometry", "moveToWaferUnloadPointYDistance", "0"));
            RelToMeasureCameraX = int.Parse(ReadIniFile("Geometry", "RelToMeasureCameraX", "0"));
            RelToMeasureCameraY = int.Parse(ReadIniFile("Geometry", "RelToMeasureCameraY", "0"));
            RelToMeasureCameraZ = int.Parse(ReadIniFile("Geometry", "RelToMeasureCameraZ", "0"));       

            SavingPath = ReadIniFile("ScanParameter", "SavePath", "C:/Avva");
            DataDirection = int.Parse(ReadIniFile("ScanParameter", "DataDirection", "0"));
            TriggerInterval = int.Parse(ReadIniFile("ScanParameter", "SetTriggerInterval", "0"));
            MaxMagAutoFocusBegin = int.Parse(ReadIniFile("CameraParameter", "MaxMagAutoFocusBegin", "0"));
            MaxMagAutoFocusEnd = int.Parse(ReadIniFile("CameraParameter", "MaxMagAutoFocusEnd", "0"));
            MinMagAutoFocusBegin = int.Parse(ReadIniFile("CameraParameter", "MinMagAutoFocusBegin", "0"));
            MinMagAutoFocusEnd = int.Parse(ReadIniFile("CameraParameter", "MinMagAutoFocusEnd", "0"));
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
