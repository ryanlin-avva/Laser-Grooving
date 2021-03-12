using System;
using System.IO;

namespace Velociraptor
{
    class VisionCalibrator
    {
        //TO-DO: declare parameters
        private double mm2pixel_x = 1;
        private double mm2pixel_y = 1;

        public VisionCalibrator()
        {
            string filename = "Calibrate.ini";
            if (!File.Exists(filename)) 
                return;
            using (StreamReader file = new StreamReader(filename))
            {
                while (!file.EndOfStream)
                {
                    string dataLine = file.ReadLine(); //row number
                    int idx = dataLine.IndexOf(":");
                    if (idx < 0) continue;
                    SetParam(dataLine.Substring(0, idx), dataLine.Substring(idx + 1));
                }
            }
        }

        public double Mm2Pixel_X(double mm)
        {
            return mm * mm2pixel_x;
        }
        public double Mm2Pixel_Y(double mm)
        {
            return mm * mm2pixel_y;
        }
        private void SetParam(string key, string value)
        {
            switch (key)
            {
                case "mm2pixel_x":
                    mm2pixel_x = Convert.ToInt32(value);
                    break;
                case "mm2pixel_y":
                    mm2pixel_y = Convert.ToInt32(value);
                    break;
            }
        }
    }
}
