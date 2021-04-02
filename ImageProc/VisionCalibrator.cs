using System;
using System.IO;

namespace Velociraptor
{
    class VisionCalibrator
    {
        //TO-DO: declare parameters
        private double um2pixel_x = 1;
        private double um2pixel_y = 1;

        public VisionCalibrator()
        {
            string filename = System.Environment.CurrentDirectory + "//" + "Calibrate.ini";
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

        public double Um2Pixel_X(double um)
        {
            return um * um2pixel_x;
        }
        public double Um2Pixel_Y(double um)
        {
            return um * um2pixel_y;
        }
        public double Pixel2Um_X(double pixel)
        {
            return pixel / um2pixel_x;
        }
        public double Pixel2Um_Y(double pixel)
        {
            return pixel / um2pixel_y;
        }
        private void SetParam(string key, string value)
        {
            switch (key)
            {
                case "mm2pixel_x":
                    um2pixel_x = Convert.ToInt32(value);
                    break;
                case "mm2pixel_y":
                    um2pixel_y = Convert.ToInt32(value);
                    break;
            }
        }
    }
}
