using System;
using Automation.BDaq;

namespace Velociraptor
{
    public class WaferChuck
    {
        InstantDiCtrl instantDiCtrl = new InstantDiCtrl();
        InstantDoCtrl instantDoCtrl = new InstantDoCtrl();
        int deviceNumber = 1; //參考Navigator.exe中之情況，0代表Demo Device，1為PCIE-1750U,BID#0
        ErrorCode errorCode = ErrorCode.Success;
        public string errstr = "";

        //設定8吋晶圓位置
        public bool Set_8inchWafer()
        {
            StaticDO_Set(1, false);
            StaticDO_Set(0, true);
            if (StaticDI_Get(2) != 1 || StaticDI_Get(3) != 1 || StaticDI_Get(4) != 1)
            {
                return false;
            }
            return true;
        }

        //設定12吋晶圓位置
        public bool Set_12inchWafer()
        {
            StaticDO_Set(0, false);
            StaticDO_Set(1, true);
            if (StaticDI_Get(2) != 0 || StaticDI_Get(3) != 0 || StaticDI_Get(4) != 0)
            {
                return false;
            }
            return true;
        }

        //壓緊晶圓
        public bool PressWafer()
        {
            StaticDO_Set(3, false);
            StaticDO_Set(2, true);
            if (StaticDI_Get(0) != 1 || StaticDI_Get(1) != 1)
            {
                return false;
            }
            return true;
        }

        //鬆開晶圓
        public bool ReleaseWafer()
        {
            StaticDO_Set(2, false);
            StaticDO_Set(3, true);
            if (StaticDI_Get(0) != 0 || StaticDI_Get(1) != 0)
            {
                return false;
            }
            return true;
        }
        #region StaticDI_Get
        private int StaticDI_Get(int channel)
        {
            try
            {

                instantDiCtrl.SelectedDevice = new DeviceInformation(deviceNumber);

                byte data = new byte();

                errorCode = instantDiCtrl.ReadBit(ChannelToPort(channel), ChannelToBit(channel), out data);
                if (BioFailed(errorCode))
                {
                    throw new Exception();
                }
                return data;
            }
            catch (Exception e)
            {
                // Something is wrong
                string errStr = BioFailed(errorCode) ? " Some error occurred. And the last error code is " + errorCode.ToString()
                                                          : e.Message;
                return -1;
            }
        }
        #endregion
        #region StaticDO_Set
        public bool StaticDO_Set(int channel, bool open)
        {
            try
            {

                instantDoCtrl.SelectedDevice = new DeviceInformation(deviceNumber);

                if (open)
                {
                    errorCode = instantDoCtrl.WriteBit(ChannelToPort(channel), ChannelToBit(channel), 1);
                }
                else
                {
                    errorCode = instantDoCtrl.WriteBit(ChannelToPort(channel), ChannelToBit(channel), 0);
                }

                /************************************************************************/
                //errorCode = instantDoCtrl.WriteBit(startPort, bit, dataForWriteBit); 
                //NOTE:
                //Every channel has 8 bits, which be used to control 0--7 bit of anyone channel.
                //argument1:which port you want to contrl? For example, startPort is 0.
                //argument2:which bit you want to control? You can write 0--7, any number you want.
                //argument3:What status you want, open or close? 1 menas open, 0 means close.*/
                /************************************************************************/
                if (BioFailed(errorCode))
                {
                    throw new Exception();
                }
                // Read back the DO status. 
                // Note: 
                // For relay output, the read back must be deferred until the relay is stable.
                // The delay time is decided by the HW SPEC.
                byte errorForReadingDO = new byte();
                errorCode = instantDoCtrl.ReadBit(ChannelToPort(channel), ChannelToBit(channel), out errorForReadingDO);
                //if (errorForReadingDO != Convert.ToByte(open))
                //{
                //    throw new Exception();
                //}
                if (BioFailed(errorCode))
                {
                    throw new Exception();
                }
                return true;
            }
            catch (Exception e)
            {
                // Something is wrong
                string errStr = BioFailed(errorCode) ? " Some error occurred. And the last error code is " + errorCode.ToString()
                                                           : e.Message;
                return false;
            }

        }
        #endregion
        #region DIDO_Release
        public void DIDO_Release()
        {
            instantDiCtrl.Dispose();
            instantDoCtrl.Dispose();
        }
        #endregion
        #region  BioFailed
        static bool BioFailed(ErrorCode err)
        {
            return err < ErrorCode.Success && err >= ErrorCode.ErrorHandleNotValid;
        }
        #endregion
        #region GetErrorMsg
        public string GetErrorMsg()
        {
            return errstr;
        }
        #endregion
        #region ChannelToPort
        public int ChannelToPort(int channel)
        {
            if (channel >= 0 && channel <= 7)
            {
                return 0;
            }
            if (channel >= 8 && channel <= 15)
            {
                return 1;
            }
            return -1;
        }
        #endregion
        #region ChannelToBit
        public int ChannelToBit(int channel)
        {
            if (channel >= 0 && channel <= 7)
            {
                return channel;
            }
            if (channel >= 8 && channel <= 15)
            {
                return (channel - 8);
            }
            return -1;
        }
        #endregion
    }
}
