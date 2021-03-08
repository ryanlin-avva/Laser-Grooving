using System;
using System.Net;
using MagicCommonLibrary;
using MagicServerLibrary;

namespace Velociraptor
{
    class MeasureInstrument
    {
        private bool isSimulate;
        #region Trigger
        private cClientCommunication _client = null;
        /// <summary>size of rx/tx ethernet buffer</summary>
        const int _rxBufferSizeOfClientSocket = 1024 * 1024 * 16;
        const int _txBufferSizeOfClientSocket = 1024 * 1024 * 16;
        private cGeneralSettings _generalSettings;
        object _lockActionProcess = new object();
        #endregion
        #region Fifo
        //Command Data Fifo
        const int _maxNumberOfBufferInFifoCommandData = 64;
        cQueueExt _fifoCommandData = null;
        //Data Sample Fifo
        private const int _maxNumberOfBufferInFifoDataSample = 1024 * 16;
        private cQueueExt _fifoDataSample = null;
        object _lockFifoDataSample = new object();
        //Data Sodx Fifo
        private const int _maxNumberOfBufferInFifoDataSodx = 1024 * 8;
        private cQueueExt _fifoDataSodx = null;
        //Data Format Fifo
        private const int _maxNumberOfBufferInFifoDataFormat = 64;
        private cQueueExt _fifoDataFormat = null;
        #endregion
        public bool Init(string filename)
        {
            MeasureParamReader paraReader = new MeasureParamReader(filename);
            isSimulate = paraReader.IsSimulate();
            if (isSimulate) return true;

            _client = new cClientCommunication(_rxBufferSizeOfClientSocket, _txBufferSizeOfClientSocket);
            _generalSettings = new cGeneralSettings(null, null);
            _generalSettings.Load();
            TriggerInit(paraReader);
            FifoInit();
            return true;
        }

        public bool Connect(string ip, ref f_main.eThreadAction _threadAction)
        {
            if (isSimulate) return true;
            if (_client == null) return false;
            _client.IP = IPAddress.Parse(ip);
            _generalSettings.General.IpAddress = ip;
            lock (_lockActionProcess)
            {
                _threadAction = (_client.ClientIsConnected) ? eThreadAction.eClientDisconnect : eThreadAction.eClientConnect;
                if (_client.ClientIsConnected)
                {
                    _eventActionProcessControlList.Add(new sEventActionProcessControl(eThreadAction.eClientDisconnect, _generalSettings));
                }
                else
                {
                    _eventActionProcessControlList.Add(new sEventActionProcessControl(eThreadAction.eClientConnect, _generalSettings));
                }
            }
        }

        private void TriggerInit(MeasureParamReader para)
        {
            UInt32[] Re_LongData = new UInt32[3];   // L size register data storage variable
            _client.SetEncoderCounters(eEncoderId.Encoder_X, eEncoderFunc.SetPositionImmediately, Re_LongData[0]);
            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.EnableTriggerDuringReturnMovement, para.EnableTriggerDuringReturnMovement);
            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.ChooseAxis, para.ChooseAxis);
            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.EndlessRountripTrigger, para.EndlessRountripTrigger);
            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SetStopPosition, para.SetStartPosition + para.MeasureDistance);
            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SetTriggerInterval, para.SetTriggerInterval);
            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SetStartPosition, para.SetStartPosition);
            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SelectEncoderTriggerSource, para.SelectEncoderTriggerSource);
            _client.Initialize(null, null);
            _client.HighSpeedBase = _generalSettings.HighSpeedBase;
            _client.SensorsBase = _generalSettings.SensorsBase;
            _client.OpticalProbesBase = _generalSettings.OpticalProbesBase;
        }

        private void FifoInit()
        {
            #region Fifo
            //Fifo Data Format
            _fifoCommandData = new cQueueExt(_maxNumberOfBufferInFifoCommandData);
            _fifoCommandData.IdName = "Sample Command";
            _fifoCommandData.OnError += _eventOnError;
            //Fifo Data Sample
            _fifoDataSample = new cQueueExt(_maxNumberOfBufferInFifoDataSample);
            _fifoDataSample.IdName = "Fifo Data Sample";
            _fifoDataSample.OnError += _eventOnError;
            //Fifo Data Format
            _fifoDataFormat = new cQueueExt(_maxNumberOfBufferInFifoDataFormat);
            _fifoDataFormat.IdName = "Sample Data Format";
            _fifoDataFormat.OnError += _eventOnError;
            //Fifo Data Sodx       
            _fifoDataSodx = new cQueueExt(_maxNumberOfBufferInFifoDataSodx);
            _fifoDataSodx.IdName = "Sample Data Sodx";
            _fifoDataSodx.OnError += _eventOnError;
            #endregion
        }
    }
}
