
using System;
using System.IO;

namespace Velociraptor
{
    class ParamMgr
    {
        //TO-DO: declare parameters
        public bool IsDark { get; set; }
        public int Threshold { get; set; }
        public int HorLines { get; set; }
        public int VerLines { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string IsDarkStr { get; set; }
        public string ThresholdStr { get; set; }
        public string HorLinesStr { get; set; }
        public string VerLinesStr { get; set; }
        public string WidthStr { get; set; }
        public string HeightStr { get; set; }
        public string ImageFilePath { get; set; }
        public bool Read(string filename, bool needStr=false)
        {
            if (!File.Exists(filename)) //Set default
            {
                //SetParamDefault();
                return false;
            }
            using (StreamReader file = new StreamReader(filename))
            {
                while (!file.EndOfStream)
                {
                    string dataLine = file.ReadLine(); //row number
                    int idx = dataLine.IndexOf(":");
                    if (idx < 0) continue;
                    if (needStr)
                    {
                        SetParamStr(dataLine.Substring(0, idx), dataLine.Substring(idx + 1));
                    }
                    else
                    {
                        SetParam(dataLine.Substring(0, idx), dataLine.Substring(idx + 1));
                    }
                }
            }
            return true;
        }

        public void Write(string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                string text;
                //TO-DO
                text = "IsDark:" + IsDark;
                outputFile.WriteLine(text);
                text = "Threshold:" + Threshold.ToString();
                outputFile.WriteLine(text);
                text = "HorLines:" + HorLines.ToString();
                outputFile.WriteLine(text);
                text = "VerLines:" + VerLines.ToString();
                outputFile.WriteLine(text);
                text = "Width:" + Width.ToString();
                outputFile.WriteLine(text);
                text = "Height:" + Height.ToString();
                outputFile.WriteLine(text);
                text = "ImageFilePath:" + ImageFilePath;
                outputFile.WriteLine(text);

            }

        }
        public void WriteStr(string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                //TO-DO
                outputFile.WriteLine("IsDark:" + IsDarkStr);
                outputFile.WriteLine("Threshold:" + ThresholdStr);
                outputFile.WriteLine("HorLines:" + HorLinesStr);
                outputFile.WriteLine("VerLines:" + VerLinesStr);
                outputFile.WriteLine("Width:" + WidthStr);
                outputFile.WriteLine("Height:" + HeightStr);
                outputFile.WriteLine("ImageFilePath:" + ImageFilePath);
            }

        }
        private void SetParamStr(string key, string value)
        {
            switch (key)
            {
                case "IsDark":
                    IsDarkStr = value;
                    break;
                case "Threshold":
                    ThresholdStr = value;
                    break;
                case "HorLines":
                    HorLinesStr = value;
                    break;
                case "VerLines":
                    VerLinesStr = value;
                    break;
                case "Width":
                    WidthStr = value;
                    break;
                case "Height":
                    HeightStr = value;
                    break;
                case "ImageFilePath":
                    ImageFilePath = value;
                    break;
            }
        }
        private void SetParam(string key, string value)
        {
            switch (key)
            {
                case "IsDark":
                    IsDark = Convert.ToBoolean(value);
                    break;
                case "Threshold":
                    Threshold = Convert.ToInt32(value);
                    break;
                case "HorLines":
                    HorLines = Convert.ToInt32(value);
                    break;
                case "VerLines":
                    VerLines = Convert.ToInt32(value);
                    break;
                case "Width":
                    Width = Convert.ToInt32(value);
                    break;
                case "Height":
                    Height = Convert.ToInt32(value);
                    break;
                case "ImageFilePath":
                    ImageFilePath = value;
                    break;
            }
        }
        private void SetParamDefault()
        {
            //TO-DO

        }
    }
}
