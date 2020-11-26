using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using MagicCommonLibrary;
using MagicGraphicLibrary;
using MagicServerLibrary;

namespace MagicAddOn
{
    /// <summary>
    /// Display Class
    /// </summary>
    public class cClientIhm
    {
        public delegate void UpdateDisplayErrorDelegateHandler(ListView listView, List<cErrorEventArgs> errorList);
        public delegate void UpdateDisplayUpLoadCalibrationDelegateHandler(ProgressBar progressBar, Button loadButton, Button sendButton, Button receiveButton, sUpldCommandStateCalibrationTables upldCommandState);
        public delegate void UpdateDisplayUpLoadMasksDelegateHandler(Button loadButton, Button sendButton, Button receiveButton, sUpldCommandStateMasksTables upldCommandState);
        public delegate void UpdateDisplayDownLoadDelegateHandler(Button buttonExecute, Button buttonSaveCsv, Button buttonSaveBmp, Label labelCounter, sDnldCommandState dnldCommandState);
        public delegate void UpdateDisplayStatusFifoDelegateHandler(cCalculationOfFifo fifo, Label Overflow, ProgressBar gauge);


        #region FuncUpdateDisplayStatusFifoDelegateHandler
        public static void FuncUpdateDisplayStatusFifoDelegateHandler(cCalculationOfFifo fifo, Label Overflow, ProgressBar gauge)
        {
            if (fifo != null)
            {
                Overflow.Text = string.Format("{0}, Max Used : {1:P0}", fifo.OverFlow, fifo.MaxPercent);
                Overflow.ForeColor = (fifo.OverFlow > 0) ? Color.Red : Color.Blue;
                gauge.Value = (int)(fifo.Percent * 100);
            }
        }
        #endregion
        #region FuncUpdateDisplayDownLoadDelegateHandler
        public static void FuncUpdateDisplayDownLoadDelegateHandler(Button buttonExecute, Button buttonSaveCsv, Button buttonSaveBmp, Label labelCounter, sDnldCommandState dnldCommandState)
        {
            try
            {
                if (buttonExecute != null)
                {
                    buttonExecute.Image = (dnldCommandState.State != sDnldCommandState.evcDnldCommand.EndReceiveSpectra) ? cResources.GetImageRunOn : cResources.GetImageRunOff;
                    if (buttonSaveCsv != null)
                    {
                        buttonSaveCsv.Enabled = (dnldCommandState.State == sDnldCommandState.evcDnldCommand.EndReceiveSpectra);
                    }
                    if (buttonSaveBmp != null)
                    {
                        buttonSaveBmp.Enabled = (dnldCommandState.State == sDnldCommandState.evcDnldCommand.EndReceiveSpectra);
                    }
                }
                if (labelCounter != null)
                {
                    labelCounter.Text = dnldCommandState.TotalNumberOfSpectra.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", "cClientIhm", System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region FuncUpdateDisplayErrorDelegateHandler
        public static void FuncUpdateDisplayErrorDelegateHandler(ListView listView, List<cErrorEventArgs> errorList)
        {
            try
            {
                double[] l_repartition_width = new double[] { 0.20, 0.76 };
                int idx = 0;

                listView.BeginUpdate();
                listView.Columns.Clear();
                listView.Items.Clear();
                listView.Columns.Add("Date", (int)((double)listView.Width * l_repartition_width[idx++]), HorizontalAlignment.Center);
                listView.Columns.Add("Message", (int)((double)listView.Width * l_repartition_width[idx++]), HorizontalAlignment.Left);
                if (errorList != null)
                {
                    lock (errorList)
                    {
                        foreach (cErrorEventArgs _data in errorList)
                        {
                            ListViewItem ItemCat = new ListViewItem("");
                            ItemCat.Text = _data.Message.Date.ToShortTimeString();
                            ItemCat.SubItems.Add(_data.Message.Text);
                            ItemCat.Tag = _data;
                            listView.Items.Add(ItemCat);
                        }
                    }
                }
                listView.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", "cClientIhm", System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region FuncUpdateDisplayUpLoadCalibrationDelegateHandler
        public static void FuncUpdateDisplayUpLoadCalibrationDelegateHandler(ProgressBar progressBar, Button loadButton, Button sendButton, Button receiveButton, sUpldCommandStateCalibrationTables upldCommandState)
        {
            try
            {
                switch (upldCommandState.State)
                {
                    case sUpldCommandStateCalibrationTables.evcUpldCommandCalibrationFiles.BeginSendCalibrationTables:
                    case sUpldCommandStateCalibrationTables.evcUpldCommandCalibrationFiles.BeginReceiveCalibrationTables:
                        if (loadButton != null)
                        {
                            loadButton.Enabled = false;
                        }
                        if (sendButton != null)
                        {
                            sendButton.Enabled = false;
                        }
                        if (receiveButton != null)
                        {
                            receiveButton.Enabled = false;
                        }
                        if (progressBar != null)
                        {
                            progressBar.Visible = true;
                        }
                        break;
                    case sUpldCommandStateCalibrationTables.evcUpldCommandCalibrationFiles.SendCalibrationTables:
                    case sUpldCommandStateCalibrationTables.evcUpldCommandCalibrationFiles.ReceiveCalibrationTables:
                        if (progressBar != null)
                        {
                            progressBar.Value = upldCommandState.CurrentNumberOfCalibrationFile;
                            progressBar.Maximum = upldCommandState.TotalNumberOfCalibrationFiles;
                        }
                        break;
                    case sUpldCommandStateCalibrationTables.evcUpldCommandCalibrationFiles.EndSendCalibrationTables:
                    case sUpldCommandStateCalibrationTables.evcUpldCommandCalibrationFiles.EndReceiveCalibrationTables:
                        if (loadButton != null)
                        {
                            loadButton.Enabled = true;
                        }
                        if (sendButton != null)
                        {
                            sendButton.Enabled = true;
                        }
                        if (receiveButton != null)
                        {
                            receiveButton.Enabled = true;
                        }
                        if (progressBar != null)
                        {
                            progressBar.Visible = false;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", "cClientIhm", System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region FuncUpdateDisplayUpLoadMaksDelegateHandler
        public static void FuncUpdateDisplayUpLoadMaksDelegateHandler(Button loadButton, Button sendButton, Button receiveButton, sUpldCommandStateMasksTables upldCommandState)
        {
            try
            {
                switch (upldCommandState.State)
                {
                    case sUpldCommandStateMasksTables.evcUpldCommandMasksFiles.BeginSendMasksTables:
                    case sUpldCommandStateMasksTables.evcUpldCommandMasksFiles.BeginReceiveMasksTables:
                        if (loadButton != null)
                        {
                            loadButton.Enabled = false;
                        }
                        if (sendButton != null)
                        {
                            sendButton.Enabled = false;
                        }
                        if (receiveButton != null)
                        {
                            receiveButton.Enabled = false;
                        }
                        break;
                    case sUpldCommandStateMasksTables.evcUpldCommandMasksFiles.SendMasksTables:
                    case sUpldCommandStateMasksTables.evcUpldCommandMasksFiles.ReceiveMasksTables:
                        break;
                    case sUpldCommandStateMasksTables.evcUpldCommandMasksFiles.EndSendMasksTables:
                    case sUpldCommandStateMasksTables.evcUpldCommandMasksFiles.EndReceiveMasksTables:
                        if (loadButton != null)
                        {
                            loadButton.Enabled = true;
                        }
                        if (sendButton != null)
                        {
                            sendButton.Enabled = true;
                        }
                        if (receiveButton != null)
                        {
                            receiveButton.Enabled = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", "cClientIhm", System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        

    }
}
