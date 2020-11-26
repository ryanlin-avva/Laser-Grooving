using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MagicCommonLibrary;
using MagicServerLibrary;

namespace MagicAddOn
{
    public class sSelectingFilter : IDisposable
    {
        CheckBox _checkBox = null;
        StreamWriter _streamWriter = null;
        bool _disposed = false;
        string _filename = "?";
        //------------------------------------------------------------------------------------------------------
        public sSelectingFilter()
        {

        }
        //--------------------------------------------------------------------------------------
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                    CloseFile();
                }
                // Free your own state (unmanaged objects).  
                _disposed = true;
            }
        }
        //--------------------------------------------------------------------------------------
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //------------------------------------------------------------------------------------------------------
        public string Filename
        {
            get
            {
                if (SodxCommand != null)
                {
                    if (SodxCommand.SignalType == eSodxSignalType.Peak_Signals)
                    {
                        _filename = string.Format("{0}_{1}_{2:yy_MM_dd_HH_mm_ss}.csv", cStringEnum.GetStringValue((eSodxSignal)SodxCommand.Signal), cStringEnum.GetStringValue((eSodxPeakNumber)SodxCommand.PeakNumber), DateTime.Now);
                    }
                    else
                    {
                        _filename = string.Format("{0}_{1:yy_MM_dd_HH_mm_ss}.csv", cStringEnum.GetStringValue((eSodxSignal)SodxCommand.Signal), DateTime.Now);
                    }
                }
                return (_filename);
            }
        }
        //------------------------------------------------------------------------------------------------------
        public sSodxCommand SodxCommand
        {
            get
            {
                if ((_checkBox != null) && (_checkBox.Tag != null) && (_checkBox.Tag is sSodxCommand))
                {
                    return (((sSodxCommand)_checkBox.Tag).Clone());
                }
                return (null);
            }
        }
        //------------------------------------------------------------------------------------------------------
        public bool OpenFile(string directory)
        {
            try
            {
                if (_streamWriter != null)
                {
                    CloseFile();
                }
                _streamWriter = new StreamWriter(string.Format(@"{0}\{1}", directory, Filename));
                return (true);
            }
            catch
            {
                return (false);
            }
        }
        //------------------------------------------------------------------------------------------------------
        public void CloseFile()
        {
            if (_streamWriter != null)
            {
                _streamWriter.Close();
                _streamWriter.Dispose();
                _streamWriter = null;
            }
        }
        //------------------------------------------------------------------------------------------------------
        public bool WriteLineFile(string str)
        {
            try
            {
                if (_streamWriter != null)
                {
                    _streamWriter.WriteLine(str);
                }
                return (true);
            }
            catch
            {
                return (false);
            }
        }
        //------------------------------------------------------------------------------------------------------
        public bool WriteFile(string str)
        {
            try
            {
                if (_streamWriter != null)
                {
                    _streamWriter.Write(str);
                }
                return (true);
            }
            catch
            {
                return (false);
            }
        }
        //------------------------------------------------------------------------------------------------------
        public CheckBox CheckBox
        {
            get { return (_checkBox); }
            set { _checkBox = value; }
        }
        //------------------------------------------------------------------------------------------------------  
    }
}
