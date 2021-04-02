using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Velociraptor
{
    public class MeasureParamReader
    {
        private string filePath;
        private StringBuilder lpReturnedString;
        private int bufferSize;

        #region trigger parameter
        public int EnableTriggerDuringReturnMovement;
        public int ChooseAxis;
        public int EndlessRountripTrigger;
        public int SetStopPosition;
        public int SetTriggerInterval;
        public int SetStartPosition;
        public int SelectEncoderTriggerSource;
        private int isSim;
        #endregion
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string lpString, string lpFileName);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        public MeasureParamReader(string iniPath)
        {
            filePath = System.Environment.CurrentDirectory + "//" + iniPath;
            bufferSize = 512;
            lpReturnedString = new StringBuilder(bufferSize);

            isSim = int.Parse(ReadIniFile("AxisMapping", "Simulate", "0"));

            #region Gets the trigger parameter
            EnableTriggerDuringReturnMovement = int.Parse(ReadIniFile("TriggerParameter", "EnableTriggerDuringReturnMovement", "0"));
            ChooseAxis = int.Parse(ReadIniFile("TriggerParameter", "ChooseAxis", "0"));
            EndlessRountripTrigger = int.Parse(ReadIniFile("TriggerParameter", "EndlessRountripTrigger", "0"));
            SetStopPosition = int.Parse(ReadIniFile("TriggerParameter", "SetStopPosition", "0"));
            SetTriggerInterval = int.Parse(ReadIniFile("TriggerParameter", "SetTriggerInterval", "0"));
            SetStartPosition = int.Parse(ReadIniFile("TriggerParameter", "SetStartPosition", "0"));
            SelectEncoderTriggerSource = int.Parse(ReadIniFile("TriggerParameter", "SelectEncoderTriggerSource", "0"));
            #endregion
        }

        public bool IsSimulate()
        {
            return (isSim == 1) ? true : false;
        }
        private string ReadIniFile(string section, string key, string defaultValue)
        {
            lpReturnedString.Clear();
            GetPrivateProfileString(section, key, defaultValue, lpReturnedString, bufferSize, filePath);

            return lpReturnedString.ToString();
        }

    }
}
