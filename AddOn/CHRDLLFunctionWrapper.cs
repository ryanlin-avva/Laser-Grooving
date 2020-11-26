using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace CHRDLLDemoNS
{
    
    class TCHRDLLFunctionWrapper
    {
        public const int CHR_FirstGen_Device = 0;
        public const int CHR_2Gen_Device = 1;
        public const int CHR_CLSMPS_Device = 2;

        public const int Raw_Spectrum = 0;
        public const int Confocal_Spectrum = 1;
        public const int FT_Spectrum = 2;

        //error message of last error
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LastError();

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LastDeviceError(UInt32 _hConnection);

        //connect to CHRocodile Device. Device type: 0, first generation CHRocodile device; 1, CHR² device; 2, CLS/MPS device
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int OpenConnection(string _strConnectionInfo, int _nDeviceType, out int _pHandle);

        //disconnect
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CloseConnection(UInt32 _hConnection);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetConnectionInfo(UInt32 _hConnection, ref IntPtr _strConnectionInfo);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDeviceType(UInt32 _hConnection);

        //read the next sample from device
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNextSample(UInt32 _hConnection, ref IntPtr _ppData, out int _pnNumberOfSignals);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNextSampleMultiChannel(UInt32 _hConnection, ref IntPtr _ppData, out int _pnNumberOfSignals, out int _pnNumberOfGlobalSigs, out int _pnNumberOfChannels);

        //read the newest sample from device, read pointer will automatically move to the newest sample.....
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetLastSample(UInt32 _hConnection, ref IntPtr _ppData, out int _pnNumberOfSignals);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetLastSampleMultiChannel(UInt32 _hConnection, ref IntPtr _ppData, out int _pnNumberOfSignals, out int _pnNumberOfGlobalSigs, out int _pnNumberOfChannels);

        //send command to device and wait for response
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ExecCommand(UInt32 _hConnection, string _pstrCmd, ref IntPtr _pstrResponse);

        //move the read pointer to last valid stream position
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FlushInputBuffer(UInt32 _hConnection);

        //get the counter which indicates the number of data stream failing 
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetStreamFailCounter(UInt32 _hConnection);

        //set reader to the mode (auto buffer save mode), which automatically save the incoming data to the target buffer..
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetToAutoBufferSave(UInt32 _hConnection, double[] _pBuffer, int _nSampleNr);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetToAutoBufferSaveWithSizeCheck(UInt32 _hConnection, double[] _pBuffer, int _nSampleNr, out int _pBufferSize);

        //get the sample number, which has been saved to the buffer in auto buffer save mode
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetAutoBufferSavedSampleNr(UInt32 _hConnection);

        //set reader to normal mode...
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ClearAutoBufferSave(UInt32 _hConnection);

        //check whether reader still in the auto. save mode
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IsAutoBufferSave(UInt32 _hConnection);

        //set output signal by device
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetOutputSignals(UInt32 _hConnection, int[] _anSignals, int _nSignalsCount);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDeviceOutputSignalIDs(UInt32 _hConnection, ref IntPtr _pSignalIDbuffer, out int _pSignalNr);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDLLOutputSignalIDs(UInt32 _hConnection, ref IntPtr _pSignalIDbuffer, out int _pSignalNr);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDeviceOutputSignalFormatIndex(UInt32 _hConnection, out int _pSignalFormatIdx);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDeviceChannelNumber(UInt32 _hConnection);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetMeasuringMode(UInt32 _hConnection, int _nMode);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFullScale(UInt32 _hConnection, out int _pnFullScale);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetScanRate(UInt32 _hConnection, float _nScanRate);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetDataAverage(UInt32 _hConnection, int _nAVD);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetSpectrumAverage(UInt32 _hConnection, int _nAVS);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRefractiveIndex(UInt32 _hConnection, float _nRefIdx);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetABBENumber(UInt32 _hConnection, float _nABBE);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetLampIntensity(UInt32 _hConnection, float _nIntensity);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetLightSouceAutoAdapt(UInt32 _hConnection, int _bAuto, float _nLevel);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetOpticalProbe(UInt32 _hConnection, int _nIndex);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRefractiveIndexTable(UInt32 _hConnection, int _nIndex);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetConfocalDetectionThreshold(UInt32 _hConnection, int _nThreshold);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetInterQualityThreshold(UInt32 _hConnection, int _nThreshold);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetDetectionWindowActive(UInt32 _hConnection, int _bActive);

        //valid for CHR²/MPS/CLS device
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetDetectionWindow(UInt32 _hConnection, float[] _anDWs, int _nWindowNr);

        //valid for first generation CHRocodile device
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetLimit(UInt32 _hConnection, int _bLeft, float _nLimit);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetAnalogOutput(UInt32 _hConnection, int _nIndex, int _nSignalID, float _nMin, float _nMax);

        //valid for CHR²/MPS/CLS device
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetAnalogOutputExtended(UInt32 _hConnection, int _nIndex, int _nSignalID,
                float _nMin, float _nMax, float _nVolMin, float _nVolMax, float _nVolInvalid);

        //valid for CHR²/MPS/CLS device
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetMedian(UInt32 _hConnection, int _nMedianWidth, float _nPercentile);

        //valid for CHR²/MPS/CLS device
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetNumberOfPeaks(UInt32 _hConnection, int _nPeakNum);

        //valid for CHR²/MPS/CLS device
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetPeakOrdering(UInt32 _hConnection, int _nPeakOrdering);

        //encoder counter related function
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetEncoderCounter(UInt32 _hConnection, int _nAxis, int _nPosition);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetEncoderCounterSource(UInt32 _hConnection, int _nAxis, int _nSource);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetEncoderPreloadFunction(UInt32 _hConnection, int _nAxis, int _nPreloadValue, int _nPreloadFunctionSetting);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetEncoderPreloadFunctionExtended(UInt32 _hConnection, int _nAxis, int _nPreloadValue, int _nPreloadFunctionSetting, int _nTriggerSource);

        //encoder trigger related function
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetEncoderTriggerProperty(UInt32 _hConnection, int _nEncoderAxis, int _nStartPos, int _nStopPos, float _nInterval,
            bool _bTriggerOnReturnMove);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetEncoderTriggerEnabled(UInt32 _hConnection, bool _bEnabled);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetDeviceTriggerMode(UInt32 _hConnection, int _nTriggerMode);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DarkReference(UInt32 _hConnection);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StartDataStream(UInt32 _hConnection);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StopDataStream(UInt32 _hConnection);

        //download spectrum, spectrum type: 0, raw spectrum; 1, processed spectrum in confocal mode; 2, FT spectrum
        //valid for first generation CHRocodile device and CHRocodile² device
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DownloadDeviceSpectrum(UInt32 _hConnection, int _nSpecType, ref IntPtr _pSpectrumBuffer, out int _pSpectrumLength);

        //valid for MPS/CLS device
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DownloadDeviceSpectrumsMultiChannel(UInt32 _hConnection, int _nSpecType, int _nStartChannelIdx, int _nChannelNumber,
            ref IntPtr _pSpectrumBuffer, out int _pSingleSpectrumLength);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DownloadDeviceSpectrumMultiChannel(UInt32 _hConnection, int _nSpecType, int _nChannelIdx,
                ref IntPtr _pSpectrumBuffer, out int _pSpectrumLength);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DownloadCurrentCalibrationTable(UInt32 _hConnection, ref IntPtr _pTable, out int _nTableLength);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DownloadWaveLengthTable(UInt32 _hConnection, ref IntPtr _pTable, out int _nTableLength);

        //CLS profile interpolation
        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetMultiChannelProfileInterpolation(UInt32 _hConnection, int _nMaxHoleSize);

        [DllImport("C:\\Users\\User\\Desktop\\Velociraptor\\obj\\Debug\\CHRocodileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetDLLOutputDataFormatMode(UInt32 _hConnection, int _eMode);




    }
}
