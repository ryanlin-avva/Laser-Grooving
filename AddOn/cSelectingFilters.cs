using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using MagicCommonLibrary;
using MagicServerLibrary;

namespace MagicAddOn
{
    //--------------------------------------------------------------------------------------
    public class cSelectingFilters : IDisposable
    {
        private bool _disposed = false;
        private List<sSelectingFilter> _selecting_filter_list = null;
        private List<sSodxCommand> _sodxCommandList = null;
        private Mutex _mutex = null;

        public delegate void OnFiltersRemoveEventHandler(object sender);
        public event OnFiltersRemoveEventHandler OnFiltersRemove;
        public delegate void OnFiltersAddEventHandler(object sender);
        public event OnFiltersAddEventHandler OnFiltersAdd;

        //-----------------------------------------------------------------------------------------------
        public cSelectingFilters()
        {
            System.Guid guid = System.Guid.NewGuid();
            _mutex = new Mutex(false, guid.ToString("N"));
            _selecting_filter_list = new List<sSelectingFilter>();
        }
        //--------------------------------------------------------------------------------------
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                    if (_selecting_filter_list != null)
                    {
                        for (int idx = 0; idx < _selecting_filter_list.Count; idx++)
                        {
                            _selecting_filter_list[idx].Dispose();
                        }
                        _selecting_filter_list = null;
                    }
                    if (_mutex != null)
                    {
                        _mutex.Dispose();
                        _mutex = null;
                    }
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
        //--------------------------------------------------------------------------------------
        public List<sSelectingFilter> List
        {
            get
            {
                try
                {
                    _mutex.WaitOne(-1);
                    return (_selecting_filter_list);
                }
                finally
                {
                    _mutex.ReleaseMutex();
                }
            }
        }
        //--------------------------------------------------------------------------------------
        public sSelectingFilter IsSelected(sSignalData signalData)
        {
            try
            {
                _mutex.WaitOne(-1);
                if ((signalData != null) && (_selecting_filter_list != null))
                {
                    foreach (sSelectingFilter selectingFilter in _selecting_filter_list)
                    {
                        if ((selectingFilter.SodxCommand != null) && (selectingFilter.CheckBox.Checked))
                        {
                            sSodxCommand sodxCommand = selectingFilter.SodxCommand;
                            if ((signalData.Signal == sodxCommand.Signal) && (signalData.PeakNumber == sodxCommand.PeakNumber))
                            {
                                return (selectingFilter);
                            }
                        }
                    }
                }
                return (null);
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
        //--------------------------------------------------------------------------------------
        public void SetSodxCommandList(List<sSodxCommand> sodxCommandList)
        {
            try
            {
                bool _canBeSelected = false;
                _mutex.WaitOne(-1);
                if ((_selecting_filter_list != null) && (sodxCommandList != null))
                {
                    _sodxCommandList = sodxCommandList;
                    //event to remove old control
                    if (OnFiltersRemove != null)
                    {
                        OnFiltersRemove(this);
                    }
                    //delete old 
                    for (int idx = 0; idx < _selecting_filter_list.Count; idx++)
                    {
                        _selecting_filter_list[idx].Dispose();
                    }
                    _selecting_filter_list.Clear();
                    //create new                    
                    for (int idx = 0; idx < _sodxCommandList.Count; idx++)
                    {
                        sSodxCommand sodx = _sodxCommandList[idx];
                        _canBeSelected = ((sodx.SignalType == eSodxSignalType.Global_Signals) && (sodx.Signal == eSodxSignal.Global_Signal_Sample_Counter));
                        _canBeSelected |= ((sodx.SignalType == eSodxSignalType.Global_Signals) && (sodx.Signal == eSodxSignal.Global_Signal_Roughness_Coefficient));
                        _canBeSelected |= ((sodx.SignalType == eSodxSignalType.Global_Signals) && (sodx.Signal == eSodxSignal.Global_Signal_Waviness_Coefficient));
                        _canBeSelected |= (sodx.SignalType == eSodxSignalType.Peak_Signals);

                        if (_canBeSelected)
                        {
                            //selection filter
                            sSelectingFilter selectingFilter = new sSelectingFilter();
                            selectingFilter.CheckBox = new CheckBox();
                            selectingFilter.CheckBox.AutoSize = true;
                            selectingFilter.CheckBox.Tag = sodx;
                            _selecting_filter_list.Add(selectingFilter);
                        }
                    }
                    //event to dislay new control
                    if (OnFiltersAdd != null)
                    {
                        OnFiltersAdd(this);
                    }
                }
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
