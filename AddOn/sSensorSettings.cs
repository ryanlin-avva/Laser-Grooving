using MagicCommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sample_1.AddOn
{      

    [Serializable]
    public class sSensorSettings : ICloneable, IDisposable
    {
        bool _disposed = false;
        eIdentification _identification = eIdentification.Cls_0;
        bool _auto_connect_mode = false;
        string _ip_address = "192.168.170.2";
        float _led_intensity = 100;
        sHighSpeed _highSpeed = new sHighSpeed();
        int _threshold = 0;
        int _scale = 0;
        cOpticalProbes _opticalProbesBase = null;
        sOpticalProbe _currentOpticalProbe = new sOpticalProbe();

        #region GlobalSignals
        sSodxGlobalSignal _globalSignal = null;
        #endregion
        #region Signal
        sSodxSignal _signal = null;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public sSensorSettings()
        {
            _globalSignal = new sSodxGlobalSignal();
            _signal = new sSodxSignal();
            Clear();
        }
        #endregion
        #region Clone
        /// <summary>
        /// Clonage de la classe
        /// </summary>
        /// <returns>retourne la classe clonée</returns>
        object ICloneable.Clone()
        {
            return this.Clone();
        }
        /// <summary>
        /// Clonage de la classe
        /// </summary>
        /// <returns>retourne la classe clonée</returns>
        public sSensorSettings Clone()
        {
            return (sSensorSettings)this.MemberwiseClone();
        }
        #endregion
        #region Copy
        public sSensorSettings Copy()
        {
            sSensorSettings result = new sSensorSettings();
            result.GlobalSignal = GlobalSignal.Copy();
            result.Signal = Signal.Copy();
            result.Scale = Scale;
            result.OpticalProbesBase = OpticalProbesBase;
            result.IpAddress = IpAddress;
            result.LedIntensity = LedIntensity;
            result.AutoConnectMode = AutoConnectMode;
            result.HighSpeed = HighSpeed.Copy();
            result.Threshold = Threshold;
            result.Identification = Identification;
            return (result);
        }
        #endregion
        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    #region _globalSignal
                    if (_globalSignal != null)
                    {
                        _globalSignal.Dispose();
                        _globalSignal = null;
                    }
                    #endregion
                    #region _signal
                    if (_signal != null)
                    {
                        _signal.Dispose();
                        _signal = null;
                    }
                    #endregion
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
        #region Clear
        /// <summary>
        /// Efface les informations courantes et initialise les valeurs par défaut.
        /// </summary>
        public void Clear()
        {
            ClearSodx();
            IpAddress = "192.168.170.2";
            LedIntensity = 100;
            HighSpeed = new sHighSpeed();
            HighSpeed.FrequencyValue = 2000;
            Threshold = 400;
            Signal.AltitudePeak1 = true;
            Signal.IntensityLevelPeak1 = true;
            GlobalSignal.SampleCounter = true;
        }
        #endregion
        #region Clear SODX
        /// <summary>
        /// Efface les informations courantes concernant le SODX et initialise les valeurs par défaut.
        /// </summary>
        public void ClearSodx()
        {
            Signal.Clear();
            GlobalSignal.Clear();
        }
        #endregion
        #region GetNumberOfPeaks
        public int GetNumberOfPeaks()
        {
            try
            {
                int result = 1;
                if ((Signal.AltitudePeak2) || (Signal.IntensityLevelPeak2))
                {
                    result = 2;
                }
                if ((Signal.AltitudePeak3) || (Signal.IntensityLevelPeak3))
                {
                    result = 3;
                }
                if ((Signal.AltitudePeak4) || (Signal.IntensityLevelPeak4))
                {
                    result = 4;
                }                 
                return (result);
            }
            catch
            {
                return (1);
            }
        }
        #endregion
        #region GetSodx
        public cSodxCommand GetSodx(bool basicMode)
        {
            try
            {
                cSodxCommand sodxCommand = new cSodxCommand();

                if (basicMode)
                {
                    #region BasicMode_Section
                    #region MeasurementMode
                    sodxCommand.Signal.ThicknessPeak1 = Signal.ThicknessPeak1;
                    sodxCommand.Signal.ThicknessPeak2 = false;
                    sodxCommand.Signal.ThicknessPeak3 = false;
                    sodxCommand.Signal.AltitudePeak1 = Signal.AltitudePeak1;
                    sodxCommand.Signal.AltitudePeak2 = Signal.AltitudePeak2;
                    sodxCommand.Signal.AltitudePeak3 = false;
                    sodxCommand.Signal.AltitudePeak4 = false;
                    sodxCommand.Signal.IntensityRawPeak1 = false;
                    sodxCommand.Signal.IntensityRawPeak2 = false;
                    sodxCommand.Signal.IntensityRawPeak3 = false;
                    sodxCommand.Signal.IntensityRawPeak4 = false;
                    sodxCommand.Signal.IntensityLevelPeak1 = Signal.IntensityLevelPeak1;
                    sodxCommand.Signal.IntensityLevelPeak2 = Signal.IntensityLevelPeak2;
                    sodxCommand.Signal.IntensityLevelPeak3 = false;
                    sodxCommand.Signal.IntensityLevelPeak4 = false;
                    sodxCommand.Signal.RefractiveIndexTableThickness1 = Signal.RefractiveIndexTableThickness1;
                    sodxCommand.Signal.RefractiveIndexTableThickness2 = Signal.RefractiveIndexTableThickness2;
                    sodxCommand.Signal.RefractiveIndexTableThickness3 = Signal.RefractiveIndexTableThickness3;
                    #endregion
                    #region GlobalSignals
                    sodxCommand.GlobalSignal.SampleCounter = GlobalSignal.SampleCounter;
                    sodxCommand.GlobalSignal.StartPositionX = GlobalSignal.StartPositionX;
                    sodxCommand.GlobalSignal.StopPositionX = GlobalSignal.StopPositionX;
                    sodxCommand.GlobalSignal.StartPositionY = GlobalSignal.StartPositionY;
                    sodxCommand.GlobalSignal.StopPositionY = GlobalSignal.StopPositionY;
                    sodxCommand.GlobalSignal.StartPositionZ = GlobalSignal.StartPositionZ;
                    sodxCommand.GlobalSignal.StopPositionZ = GlobalSignal.StopPositionZ;
                    sodxCommand.GlobalSignal.StartPositionU = GlobalSignal.StartPositionU;
                    sodxCommand.GlobalSignal.StopPositionU = GlobalSignal.StopPositionU;
                    sodxCommand.GlobalSignal.StartPositionV = GlobalSignal.StartPositionV;
                    sodxCommand.GlobalSignal.StopPositionV = GlobalSignal.StopPositionV;
                    #endregion
                    #endregion
                }
                else
                {
                    #region ExpertMode_Section
                    #region MeasurementMode
                    sodxCommand.Signal.ThicknessPeak1 = Signal.ThicknessPeak1;
                    sodxCommand.Signal.ThicknessPeak2 = Signal.ThicknessPeak2;
                    sodxCommand.Signal.ThicknessPeak3 = Signal.ThicknessPeak3;
                    sodxCommand.Signal.AltitudePeak1 = Signal.AltitudePeak1;
                    sodxCommand.Signal.AltitudePeak2 = Signal.AltitudePeak2;
                    sodxCommand.Signal.AltitudePeak3 = Signal.AltitudePeak3;
                    sodxCommand.Signal.AltitudePeak4 = Signal.AltitudePeak4;
                    sodxCommand.Signal.IntensityRawPeak1 = false;
                    sodxCommand.Signal.IntensityRawPeak2 = false;
                    sodxCommand.Signal.IntensityRawPeak3 = false;
                    sodxCommand.Signal.IntensityRawPeak4 = false;
                    sodxCommand.Signal.IntensityLevelPeak1 = Signal.IntensityLevelPeak1;
                    sodxCommand.Signal.IntensityLevelPeak2 = Signal.IntensityLevelPeak2;
                    sodxCommand.Signal.IntensityLevelPeak3 = Signal.IntensityLevelPeak3;
                    sodxCommand.Signal.IntensityLevelPeak4 = Signal.IntensityLevelPeak4;
                    sodxCommand.Signal.RefractiveIndexTableThickness1 = Signal.RefractiveIndexTableThickness1;
                    sodxCommand.Signal.RefractiveIndexTableThickness2 = Signal.RefractiveIndexTableThickness2;
                    sodxCommand.Signal.RefractiveIndexTableThickness3 = Signal.RefractiveIndexTableThickness3;
                    #endregion
                    #region GlobalSignals
                    sodxCommand.GlobalSignal.SampleCounter = GlobalSignal.SampleCounter;
                    sodxCommand.GlobalSignal.StartPositionX = GlobalSignal.StartPositionX;
                    sodxCommand.GlobalSignal.StopPositionX = GlobalSignal.StopPositionX;
                    sodxCommand.GlobalSignal.StartPositionY = GlobalSignal.StartPositionY;
                    sodxCommand.GlobalSignal.StopPositionY = GlobalSignal.StopPositionY;
                    sodxCommand.GlobalSignal.StartPositionZ = GlobalSignal.StartPositionZ;
                    sodxCommand.GlobalSignal.StopPositionZ = GlobalSignal.StopPositionZ;
                    sodxCommand.GlobalSignal.StartPositionU = GlobalSignal.StartPositionU;
                    sodxCommand.GlobalSignal.StopPositionU = GlobalSignal.StopPositionU;
                    sodxCommand.GlobalSignal.StartPositionV = GlobalSignal.StartPositionV;
                    sodxCommand.GlobalSignal.StopPositionV = GlobalSignal.StopPositionV;
                    sodxCommand.GlobalSignal.TriggerLostCount = GlobalSignal.TriggerLostCount;
                    sodxCommand.GlobalSignal.ExposureFlags = GlobalSignal.ExposureFlags;
                    sodxCommand.GlobalSignal.StartTime = GlobalSignal.StartTime;
                    #endregion
                    #endregion
                }
                ParametersVerification(ref sodxCommand);
                return (sodxCommand);
            }
            catch
            {
                return (null);
            }
        }
        #endregion
        #region SetSodx
        public void SetSodx(List<sSodxCommand> sodxCommandList)
        {
            foreach (sSodxCommand sodxCommand in sodxCommandList)
            {
                if (sodxCommand.SignalType == eSodxSignalType.Global_Signals)
                {
                    #region GlobalSignals_Section
                    switch (sodxCommand.Signal)
                    {
                        case eSodxSignal.Global_Signal_Exposure_Flags:
                            GlobalSignal.ExposureFlags = true;
                            break;
                        case eSodxSignal.Global_Signal_First_Exposure_Count:
                            GlobalSignal.FirstExposureCount = true;
                            break;
                        case eSodxSignal.Global_Signal_Health_Dsp_Load:
                            GlobalSignal.HealthDspLoad = true;
                            break;
                        case eSodxSignal.Global_Signal_Health_Exposure_Lost_Count:
                            GlobalSignal.HealthExposureLostCount = true;
                            break;
                        case eSodxSignal.Global_Signal_Health_Ticket_Wrong_Order:
                            GlobalSignal.HealthTicketWrongOrder = true;
                            break;
                        case eSodxSignal.Global_Signal_Health_Upp_Lost_Count:
                            GlobalSignal.HealthUppLostCount = true;
                            break;
                        case eSodxSignal.Global_Signal_Health_Upp_Not_Finished:
                            GlobalSignal.HealthUppNotFinished = true;
                            break;
                        case eSodxSignal.Global_Signal_Number_Of_Valid_Peaks:
                            GlobalSignal.NumberOfValidPeaks = true;
                            break;
                        case eSodxSignal.Global_Signal_Packet_Timestamp_Offset:
                            GlobalSignal.PacketTimeStampOffset = true;
                            break;
                        case eSodxSignal.Global_Signal_Real_Exposure_Time:
                            GlobalSignal.RealExposureTime = true;
                            break;
                        case eSodxSignal.Global_Signal_Real_Lightning_Time:
                            GlobalSignal.RealLightningTime = true;
                            break;
                        case eSodxSignal.Global_Signal_Sample_Counter:
                            GlobalSignal.SampleCounter = true;
                            break;
                        case eSodxSignal.Global_Signal_Start_Position_U:
                            GlobalSignal.StartPositionU = true;
                            break;
                        case eSodxSignal.Global_Signal_Start_Position_V:
                            GlobalSignal.StartPositionV = true;
                            break;
                        case eSodxSignal.Global_Signal_Start_Position_X:
                            GlobalSignal.StartPositionX = true;
                            break;
                        case eSodxSignal.Global_Signal_Start_Position_Y:
                            GlobalSignal.StartPositionY = true;
                            break;
                        case eSodxSignal.Global_Signal_Start_Position_Z:
                            GlobalSignal.StartPositionZ = true;
                            break;
                        case eSodxSignal.Global_Signal_Start_Time:
                            GlobalSignal.StartTime = true;
                            break;
                        case eSodxSignal.Global_Signal_Stop_Position_U:
                            GlobalSignal.StopPositionU = true;
                            break;
                        case eSodxSignal.Global_Signal_Stop_Position_V:
                            GlobalSignal.StopPositionV = true;
                            break;
                        case eSodxSignal.Global_Signal_Stop_Position_X:
                            GlobalSignal.StopPositionX = true;
                            break;
                        case eSodxSignal.Global_Signal_Stop_Position_Y:
                            GlobalSignal.StopPositionY = true;
                            break;
                        case eSodxSignal.Global_Signal_Stop_Position_Z:
                            GlobalSignal.StopPositionZ = true;
                            break;
                        case eSodxSignal.Global_Signal_Ticket_Number:
                            GlobalSignal.TicketNumber = true;
                            break;
                        case eSodxSignal.Global_Signal_Trigger_Lost_Count:
                            GlobalSignal.TriggerLostCount = true;
                            break;
                    }
                    #endregion
                }
                else if (sodxCommand.SignalType == eSodxSignalType.Peak_Signals)
                {
                    #region PeakSignals_Section
                    switch (sodxCommand.Signal)
                    {
                        case eSodxSignal.Altitude:
                            #region Altitude_Section
                            switch (sodxCommand.PeakNumber)
                            {
                                case eSodxPeakNumber.Peak_1:
                                    Signal.AltitudePeak1 = true;
                                    break;
                                case eSodxPeakNumber.Peak_2:
                                    Signal.AltitudePeak2 = true;
                                    break;
                                case eSodxPeakNumber.Peak_3:
                                    Signal.AltitudePeak3 = true;
                                    break;
                                case eSodxPeakNumber.Peak_4:
                                    Signal.AltitudePeak4 = true;
                                    break;
                            }
                            #endregion
                            break;
                        case eSodxSignal.Intensity_Raw:
                            #region Intensity_Raw_Section
                            switch (sodxCommand.PeakNumber)
                            {
                                case eSodxPeakNumber.Peak_1:
                                    Signal.IntensityRawPeak1 = true;
                                    break;
                                case eSodxPeakNumber.Peak_2:
                                    Signal.IntensityRawPeak2 = true;
                                    break;
                                case eSodxPeakNumber.Peak_3:
                                    Signal.IntensityRawPeak3 = true;
                                    break;
                                case eSodxPeakNumber.Peak_4:
                                    Signal.IntensityRawPeak4 = true;
                                    break;
                            }
                            #endregion
                            break;
                        case eSodxSignal.Intensity_Level:
                            #region Intensity_Level_Section
                            switch (sodxCommand.PeakNumber)
                            {
                                case eSodxPeakNumber.Peak_1:
                                    Signal.IntensityLevelPeak1 = true;
                                    break;
                                case eSodxPeakNumber.Peak_2:
                                    Signal.IntensityLevelPeak2 = true;
                                    break;
                                case eSodxPeakNumber.Peak_3:
                                    Signal.IntensityLevelPeak3 = true;
                                    break;
                                case eSodxPeakNumber.Peak_4:
                                    Signal.IntensityLevelPeak4 = true;
                                    break;
                            }
                            #endregion
                            break;
                    }
                    #endregion
                }
            }
        }
        #endregion
        #region ParametersVerification
        private void ParametersVerification(ref cSodxCommand sodxCommand)
        {
            #region Roughness/Waviness
            if ((sodxCommand.RoughnessWavinessProcessing.Roughness) || (sodxCommand.RoughnessWavinessProcessing.Waviness))
            {
                Signal.ThicknessPeak1 = false;
                Signal.ThicknessPeak2 = false;
                Signal.ThicknessPeak3 = false;
                sodxCommand.Signal.ThicknessPeak1 = false;
                sodxCommand.Signal.ThicknessPeak2 = false;
                sodxCommand.Signal.ThicknessPeak3 = false;
                sodxCommand.Signal.AltitudePeak1 = false;
                sodxCommand.Signal.AltitudePeak2 = false;
                sodxCommand.Signal.AltitudePeak3 = false;
                sodxCommand.Signal.AltitudePeak4 = false;
                switch (sodxCommand.RoughnessWavinessProcessing.RoughnessSignal)
                {
                    case eRoughnessSignal.AltitudePeak1:
                        sodxCommand.Signal.AltitudePeak1 = true;
                        Signal.AltitudePeak2 = false;
                        Signal.AltitudePeak3 = false;
                        Signal.AltitudePeak4 = false;
                        break;
                    case eRoughnessSignal.AltitudePeak2:
                        sodxCommand.Signal.AltitudePeak2 = true;
                        Signal.AltitudePeak1 = false;
                        Signal.AltitudePeak3 = false;
                        Signal.AltitudePeak4 = false;

                        break;
                    case eRoughnessSignal.AltitudePeak3:
                        sodxCommand.Signal.AltitudePeak3 = true;
                        Signal.AltitudePeak1 = false;
                        Signal.AltitudePeak2 = false;
                        Signal.AltitudePeak4 = false;
                        break;
                    case eRoughnessSignal.AltitudePeak4:
                        sodxCommand.Signal.AltitudePeak4 = true;
                        Signal.AltitudePeak1 = false;
                        Signal.AltitudePeak2 = false;
                        Signal.AltitudePeak3 = false;
                        break;
                }
            }
            #endregion
            #region Thickness
            if (Signal.ThicknessPeak1)
            {
                sodxCommand.Signal.AltitudePeak1 = Signal.ThicknessPeak1;
            }
            if ((Signal.ThicknessPeak1) || (Signal.ThicknessPeak2))
            {
                sodxCommand.Signal.AltitudePeak2 = Signal.ThicknessPeak1 || Signal.ThicknessPeak2;
            }
            if ((Signal.ThicknessPeak2) || (Signal.ThicknessPeak3))
            {
                sodxCommand.Signal.AltitudePeak3 = Signal.ThicknessPeak2 || Signal.ThicknessPeak3;
            }
            if (Signal.ThicknessPeak3)
            {
                sodxCommand.Signal.AltitudePeak4 = Signal.ThicknessPeak3;
            }
            #endregion
            #region ThicknessPeak1
            if (sodxCommand.Signal.ThicknessPeak1 == false)
            {
                sodxCommand.FibersDataStatistics.Thickness1.Average = false;
                sodxCommand.FibersDataStatistics.Thickness1.Min = false;
                sodxCommand.FibersDataStatistics.Thickness1.Max = false;
                sodxCommand.FibersDataStatistics.Thickness1.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.Thickness1.PeakToValley = false;
                sodxCommand.LineProfileStatistics.Thickness1.Average = false;
                sodxCommand.LineProfileStatistics.Thickness1.Min = false;
                sodxCommand.LineProfileStatistics.Thickness1.Max = false;
                sodxCommand.LineProfileStatistics.Thickness1.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.Thickness1.PeakToValley = false;
            }
            #endregion
            #region ThicknessPeak2
            if (sodxCommand.Signal.ThicknessPeak2 == false)
            {
                sodxCommand.FibersDataStatistics.Thickness2.Average = false;
                sodxCommand.FibersDataStatistics.Thickness2.Min = false;
                sodxCommand.FibersDataStatistics.Thickness2.Max = false;
                sodxCommand.FibersDataStatistics.Thickness2.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.Thickness2.PeakToValley = false;
                sodxCommand.LineProfileStatistics.Thickness2.Average = false;
                sodxCommand.LineProfileStatistics.Thickness2.Min = false;
                sodxCommand.LineProfileStatistics.Thickness2.Max = false;
                sodxCommand.LineProfileStatistics.Thickness2.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.Thickness2.PeakToValley = false;
            }
            #endregion
            #region ThicknessPeak3
            if (sodxCommand.Signal.ThicknessPeak3 == false)
            {
                sodxCommand.FibersDataStatistics.Thickness3.Average = false;
                sodxCommand.FibersDataStatistics.Thickness3.Min = false;
                sodxCommand.FibersDataStatistics.Thickness3.Max = false;
                sodxCommand.FibersDataStatistics.Thickness3.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.Thickness3.PeakToValley = false;
                sodxCommand.LineProfileStatistics.Thickness3.Average = false;
                sodxCommand.LineProfileStatistics.Thickness3.Min = false;
                sodxCommand.LineProfileStatistics.Thickness3.Max = false;
                sodxCommand.LineProfileStatistics.Thickness3.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.Thickness3.PeakToValley = false;
            }
            #endregion
            #region AltitudePeak1
            if (sodxCommand.Signal.AltitudePeak1 == false)
            {
                sodxCommand.FibersDataStatistics.AltitudePeak1.Average = false;
                sodxCommand.FibersDataStatistics.AltitudePeak1.Min = false;
                sodxCommand.FibersDataStatistics.AltitudePeak1.Max = false;
                sodxCommand.FibersDataStatistics.AltitudePeak1.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.AltitudePeak1.PeakToValley = false;
                sodxCommand.LineProfileStatistics.AltitudePeak1.Average = false;
                sodxCommand.LineProfileStatistics.AltitudePeak1.Min = false;
                sodxCommand.LineProfileStatistics.AltitudePeak1.Max = false;
                sodxCommand.LineProfileStatistics.AltitudePeak1.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.AltitudePeak1.PeakToValley = false;
            }
            #endregion
            #region AltitudePeak2
            if (sodxCommand.Signal.AltitudePeak2 == false)
            {
                sodxCommand.FibersDataStatistics.AltitudePeak2.Average = false;
                sodxCommand.FibersDataStatistics.AltitudePeak2.Min = false;
                sodxCommand.FibersDataStatistics.AltitudePeak2.Max = false;
                sodxCommand.FibersDataStatistics.AltitudePeak2.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.AltitudePeak2.PeakToValley = false;
                sodxCommand.LineProfileStatistics.AltitudePeak2.Average = false;
                sodxCommand.LineProfileStatistics.AltitudePeak2.Min = false;
                sodxCommand.LineProfileStatistics.AltitudePeak2.Max = false;
                sodxCommand.LineProfileStatistics.AltitudePeak2.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.AltitudePeak2.PeakToValley = false;
            }
            #endregion
            #region AltitudePeak2
            if (sodxCommand.Signal.AltitudePeak3 == false)
            {
                sodxCommand.FibersDataStatistics.AltitudePeak3.Average = false;
                sodxCommand.FibersDataStatistics.AltitudePeak3.Min = false;
                sodxCommand.FibersDataStatistics.AltitudePeak3.Max = false;
                sodxCommand.FibersDataStatistics.AltitudePeak3.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.AltitudePeak3.PeakToValley = false;
                sodxCommand.LineProfileStatistics.AltitudePeak3.Average = false;
                sodxCommand.LineProfileStatistics.AltitudePeak3.Min = false;
                sodxCommand.LineProfileStatistics.AltitudePeak3.Max = false;
                sodxCommand.LineProfileStatistics.AltitudePeak3.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.AltitudePeak3.PeakToValley = false;
            }
            #endregion
            #region AltitudePeak4
            if (sodxCommand.Signal.AltitudePeak4 == false)
            {
                sodxCommand.FibersDataStatistics.AltitudePeak4.Average = false;
                sodxCommand.FibersDataStatistics.AltitudePeak4.Min = false;
                sodxCommand.FibersDataStatistics.AltitudePeak4.Max = false;
                sodxCommand.FibersDataStatistics.AltitudePeak4.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.AltitudePeak4.PeakToValley = false;
                sodxCommand.LineProfileStatistics.AltitudePeak4.Average = false;
                sodxCommand.LineProfileStatistics.AltitudePeak4.Min = false;
                sodxCommand.LineProfileStatistics.AltitudePeak4.Max = false;
                sodxCommand.LineProfileStatistics.AltitudePeak4.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.AltitudePeak4.PeakToValley = false;
            }
            #endregion
            #region IntensityRawPeak1
            if (sodxCommand.Signal.IntensityRawPeak1 == false)
            {
                sodxCommand.FibersDataStatistics.IntensityRawPeak1.Average = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak1.Min = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak1.Max = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak1.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak1.PeakToValley = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak1.Average = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak1.Min = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak1.Max = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak1.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak1.PeakToValley = false;
            }
            #endregion
            #region IntensityRawPeak2
            if (sodxCommand.Signal.IntensityRawPeak2 == false)
            {
                sodxCommand.FibersDataStatistics.IntensityRawPeak2.Average = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak2.Min = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak2.Max = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak2.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak2.PeakToValley = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak2.Average = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak2.Min = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak2.Max = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak2.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak2.PeakToValley = false;
            }
            #endregion
            #region IntensityPercentagePeak3
            if (sodxCommand.Signal.IntensityRawPeak3 == false)
            {
                sodxCommand.FibersDataStatistics.IntensityRawPeak3.Average = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak3.Min = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak3.Max = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak3.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak3.PeakToValley = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak3.Average = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak3.Min = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak3.Max = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak3.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak3.PeakToValley = false;
            }
            #endregion
            #region IntensityRawPeak4
            if (sodxCommand.Signal.IntensityRawPeak4 == false)
            {
                sodxCommand.FibersDataStatistics.IntensityRawPeak4.Average = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak4.Min = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak4.Max = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak4.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.IntensityRawPeak4.PeakToValley = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak4.Average = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak4.Min = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak4.Max = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak4.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.IntensityRawPeak4.PeakToValley = false;
            }
            #endregion
            #region IntensityLevelPeak1
            if (sodxCommand.Signal.IntensityLevelPeak1 == false)
            {
                sodxCommand.FibersDataStatistics.IntensityLevelPeak1.Average = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak1.Min = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak1.Max = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak1.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak1.PeakToValley = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak1.Average = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak1.Min = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak1.Max = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak1.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak1.PeakToValley = false;
            }
            #endregion
            #region IntensityLevelPeak2
            if (sodxCommand.Signal.IntensityLevelPeak2 == false)
            {
                sodxCommand.FibersDataStatistics.IntensityLevelPeak2.Average = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak2.Min = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak2.Max = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak2.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak2.PeakToValley = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak2.Average = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak2.Min = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak2.Max = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak2.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak2.PeakToValley = false;
            }
            #endregion
            #region IntensityLevelPeak3
            if (sodxCommand.Signal.IntensityLevelPeak3 == false)
            {
                sodxCommand.FibersDataStatistics.IntensityLevelPeak3.Average = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak3.Min = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak3.Max = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak3.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak3.PeakToValley = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak3.Average = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak3.Min = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak3.Max = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak3.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak3.PeakToValley = false;
            }
            #endregion
            #region IntensityLevelPeak4
            if (sodxCommand.Signal.IntensityLevelPeak4 == false)
            {
                sodxCommand.FibersDataStatistics.IntensityLevelPeak4.Average = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak4.Min = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak4.Max = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak4.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.IntensityLevelPeak4.PeakToValley = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak4.Average = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak4.Min = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak4.Max = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak4.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.IntensityLevelPeak4.PeakToValley = false;
            }
            #endregion
            #region Roughness
            if (sodxCommand.RoughnessWavinessProcessing.Roughness == false)
            {
                sodxCommand.FibersDataStatistics.Roughness.Average = false;
                sodxCommand.FibersDataStatistics.Roughness.Min = false;
                sodxCommand.FibersDataStatistics.Roughness.Max = false;
                sodxCommand.FibersDataStatistics.Roughness.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.Roughness.PeakToValley = false;
                sodxCommand.LineProfileStatistics.Roughness.Average = false;
                sodxCommand.LineProfileStatistics.Roughness.Min = false;
                sodxCommand.LineProfileStatistics.Roughness.Max = false;
                sodxCommand.LineProfileStatistics.Roughness.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.Roughness.PeakToValley = false;
            }
            #endregion
            #region Waviness
            if (sodxCommand.RoughnessWavinessProcessing.Waviness == false)
            {
                sodxCommand.FibersDataStatistics.Waviness.Average = false;
                sodxCommand.FibersDataStatistics.Waviness.Min = false;
                sodxCommand.FibersDataStatistics.Waviness.Max = false;
                sodxCommand.FibersDataStatistics.Waviness.StandardDeviation = false;
                sodxCommand.FibersDataStatistics.Waviness.PeakToValley = false;
                sodxCommand.LineProfileStatistics.Waviness.Average = false;
                sodxCommand.LineProfileStatistics.Waviness.Min = false;
                sodxCommand.LineProfileStatistics.Waviness.Max = false;
                sodxCommand.LineProfileStatistics.Waviness.StandardDeviation = false;
                sodxCommand.LineProfileStatistics.Waviness.PeakToValley = false;
            }
            #endregion
        }
        #endregion
        
        #region Properties
        #region Identification
        public eIdentification Identification
        {
            get { return (_identification); }
            set
            {
                if (_identification != value)
                {
                    _identification = value;
                }
            }
        }
        #endregion
        #region IpAddress
        /// <summary>Adresse IP du CLS</summary>
        public string IpAddress
        {
            get { return (_ip_address); }
            set
            {
                if (_ip_address != value)
                {
                    _ip_address = value;
                }
            }
        }
        #endregion
        #region LedIntensity
        /// <summary>Led Intensity</summary>
        public float LedIntensity
        {
            get { return (_led_intensity); }
            set
            {
                if (_led_intensity != value)
                {
                    _led_intensity = value;
                }
            }
        }
        #endregion        
        #region AutoConnectMode
        /// <summary>Auto connect</summary>
        public bool AutoConnectMode
        {
            get { return (_auto_connect_mode); }
            set
            {
                if (_auto_connect_mode != value)
                {
                    _auto_connect_mode = value;
                }
            }
        }
        #endregion
        #region HighSpeed
        /// <summary>High Speed</summary>
        public sHighSpeed HighSpeed
        {
            get { return (_highSpeed); }
            set
            {
                _highSpeed = value;
            }
        }
        #endregion   
        #region Threshold
        /// <summary>Threshold</summary>
        public int Threshold
        {
            get { return (_threshold); }
            set
            {
                if (_threshold != value)
                {
                    _threshold = value;
                }
            }
        }
        #endregion        
        #region Global Signal
        /// <summary>Global Signal</summary>
        public sSodxGlobalSignal GlobalSignal
        {
            get { return (_globalSignal); }
            set
            {
                if (_globalSignal != null)
                {
                    _globalSignal = value; 
                }
            }
        }
        #endregion
        #region Signal
        /// <summary>Signal</summary>
        public sSodxSignal Signal
        {
            get { return (_signal); }
            set
            {
                if (_signal != null)
                {
                    _signal = value;
                }
            }
        }
        #endregion
        #endregion

        #region Programm Parameters (Not Saved)       
        #region Current Optical Probes
        /// <summary>Current Optical Probes</summary>
        [XmlIgnore]
        public sOpticalProbe CurrentOpticalProbe
        {
            get { return (_currentOpticalProbe); }
        }
        #endregion
        #region Optical Probes Data Base
        /// <summary>Optical Probes Data Base</summary>
        [XmlIgnore]
        public cOpticalProbes OpticalProbesBase
        {
            get { return (_opticalProbesBase); }
            set
            {
                if (_opticalProbesBase != value)
                {
                    _opticalProbesBase = value;
                }
            }
        }
        #endregion
        #region Scale
        /// <summary>Scale Parameters</summary>
        [XmlIgnore]
        public int Scale
        {
            get { return (_scale); }
            set
            {
                if (_scale != value)
                {
                    _scale = value;
                    //search current optical probe
                    sOpticalProbe opticalProbe = new sOpticalProbe(eClsProbe.eNotReferenced, 0, 0, 0);
                    if (OpticalProbesBase != null)
                    {
                        foreach (sOpticalProbe data in OpticalProbesBase.List)
                        {
                            int margin_of_error = (int)Math.Round(data.Scale * 0.2);
                            if ((_scale - margin_of_error <= data.Scale) && (_scale + margin_of_error >= data.Scale))
                            {
                                opticalProbe = data.Clone();
                                break;
                            }
                        }
                    }
                    _currentOpticalProbe = opticalProbe;                    
                }
            }
        }
        #endregion       
        #endregion

    }
}
