using MagicCommonLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Velociraptor.AddOn
{
    public class MyThread: IDisposable
    {
        cThreadProcess _thread;
        string _name = "my name";
        public List<AutoResetEvent> EventUserList = new List<AutoResetEvent>();
        public MyThread(int EventNumber)
        {
            _thread = new cThreadProcess(EventNumber);
            _name = Thread.CurrentThread.Name;
            for (int i = 0; i < EventNumber; i++)
            {
                AutoResetEvent e = new AutoResetEvent(false);
                EventUserList.Add(e);
            }
            Debug.WriteLine("MyThread Constructor " + _name);
        }
        public MyThread(string name, int EventNumber)
        {
            _thread = new cThreadProcess(name, EventNumber);
            _name = name;
            for (int i = 0; i < EventNumber; i++)
            {
                AutoResetEvent e = new AutoResetEvent(false);
                EventUserList.Add(e);
            }
            Debug.WriteLine("MyThread Constructor " + _name);
        }

        public ApartmentState ApartmentState {
            get { return _thread.ApartmentState; } }
        public AutoResetEvent EventExitProcessThread { 
            get {
                Debug.WriteLine("EventExitProcessThread " + _name);
                return _thread.EventExitProcessThread; } 
        }
        public AutoResetEvent EventExitProcessThreadDo {
            get
            {
                Debug.WriteLine("EventExitProcessThreadDo " + _name);
                return _thread.EventExitProcessThreadDo; } }
        public bool IsRunning { get { return _thread.IsRunning; } }

        public event cErrorEventArgs.OnErrorEventHandler OnError;

        public bool BreakThread(int timeout) {
            Debug.WriteLine("BreakThread " + _name);
            return _thread.BreakThread(timeout); 
        }
        public bool StartThread(ThreadStart start) {
            Debug.WriteLine("StartThread " + _name);
            return _thread.StartThread(start); 
        }
        public bool StopThread(int timeout) {
            Debug.WriteLine("StopThread " + _name);
            return _thread.StopThread(timeout); 
        }
        //protected override void Dispose(bool disposing) { }
        public void Dispose()
        {
            _thread.Dispose();
            //Dispose(true);
        }
    }
}
