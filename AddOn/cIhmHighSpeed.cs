using System;
using System.Windows.Forms;
using MagicCommonLibrary;
using MagicGraphicLibrary;
using MagicServerLibrary;
using AddOn;

namespace MagicAddOn
{
    public class cIhmHighSpeed
    {

        public delegate void PrepareHighSpeedDelegateHandler(cClientCommunication client, cGeneralSettings generalSettings, sControlUpdateEx cbx_high_speed_mode, sControlUpdateEx cbx_high_speed);
        public delegate void UpdateHighSpeedDelegateHandler(cClientCommunication client, cGeneralSettings generalSettings, sControlUpdateEx cbx_high_speed_mode, sControlUpdateEx cbx_high_speed);
        public delegate void UpdateHighSpeedModeDelegateHandler(cClientCommunication client, cGeneralSettings generalSettings, sControlUpdateEx cbx_high_speed_mode, sControlUpdateEx cbx_high_speed);



        #region PrepareHighSpeed
        public static void PrepareHighSpeed(cClientCommunication client, cGeneralSettings generalSettings, sControlUpdateEx cbx_high_speed_mode, sControlUpdateEx cbx_high_speed)
        {
            if ((client != null) && (generalSettings != null) && ((cbx_high_speed_mode != null) && (cbx_high_speed_mode.Object is ComboBox)) && ((cbx_high_speed != null) && (cbx_high_speed.Object is ComboBox)))
            {
                ComboBox cbx_high_speed_mode_ctrl = (ComboBox)cbx_high_speed_mode.Object;
                ComboBox cbx_high_speed_ctrl = (ComboBox)cbx_high_speed.Object;
                cbx_high_speed_mode.EnableEvent(false);
                cbx_high_speed.EnableEvent(false);
                #region high speed mode
                cbx_high_speed_mode_ctrl.SuspendLayout();
                cbx_high_speed_mode_ctrl.Items.Clear();

                foreach (eClsHighSpeedMode data in (eClsHighSpeedMode[])Enum.GetValues(typeof(eClsHighSpeedMode)))
                {
                    if ((data == eClsHighSpeedMode.eFreeFrequency) || ((client.SensorFrequencyMax > generalSettings.General.Sensor.StandardFrequency) && (data != eClsHighSpeedMode.eFreeFrequency)))
                    {
                        cbx_high_speed_mode_ctrl.Items.Add(generalSettings.General.ResourceLanguage.GetString(cStringEnum.GetStringValue(data)));
                    }
                }
                cbx_high_speed_mode_ctrl.SelectedIndex = cbx_high_speed_mode_ctrl.Items.IndexOf(generalSettings.General.ResourceLanguage.GetString(cStringEnum.GetStringValue(generalSettings.General.HighSpeed.HighSpeedMode)));
                if ((cbx_high_speed_mode_ctrl.SelectedIndex == -1) && (cbx_high_speed_mode_ctrl.Items.Count > 0))
                {
                    cbx_high_speed_mode_ctrl.SelectedIndex = 0;
                }
                cbx_high_speed_mode_ctrl.ResumeLayout();
                #endregion
                #region high speed
                cbx_high_speed_ctrl.DropDownStyle = ComboBoxStyle.DropDownList;
                cbx_high_speed_ctrl.SuspendLayout();
                cbx_high_speed_ctrl.Items.Clear();
                foreach (eClsHighSpeed data in (eClsHighSpeed[])Enum.GetValues(typeof(eClsHighSpeed)))
                {
                    if ((data != eClsHighSpeed.e2000Hz) && (UInt32.Parse(cStringEnum.GetStringValue(data)) <= client.SensorFrequencyMax))
                    {
                        cbx_high_speed_ctrl.Items.Add(cStringEnum.GetStringValue(data));
                    }
                }
                cbx_high_speed_ctrl.ResumeLayout();
                if (generalSettings.General.HighSpeed.HighSpeedMode == eClsHighSpeedMode.eHighSpeedLimitedRange)
                {
                    if (((int)generalSettings.General.HighSpeed.Frequency - 1) < cbx_high_speed_ctrl.Items.Count)
                    {
                        cbx_high_speed_ctrl.SelectedIndex = ((int)generalSettings.General.HighSpeed.Frequency - 1);
                    }
                    else
                    {
                        cbx_high_speed_ctrl.SelectedIndex = cbx_high_speed_ctrl.Items.Count - 1;
                    }
                }
                else
                {
                    cbx_high_speed_ctrl.DropDownStyle = ComboBoxStyle.Simple;
                    cbx_high_speed_ctrl.Text = generalSettings.General.HighSpeed.ToString();
                }
                #endregion
                cbx_high_speed_mode.EnableEvent(true);
                cbx_high_speed.EnableEvent(true);
            }
        }
        #endregion
        #region UpdateHighSpeedMode
        public static void UpdateHighSpeedMode(cClientCommunication client, cGeneralSettings generalSettings, sControlUpdateEx cbx_high_speed_mode, sControlUpdateEx cbx_high_speed)
        {
            bool requestDark = false;
            ComboBox cbx_high_speed_ctrl = (ComboBox)cbx_high_speed.Object;
            ComboBox cbx_high_speed_mode_ctrl = (ComboBox)cbx_high_speed_mode.Object;
            //disabled change
            cbx_high_speed.EnableEvent(false);
            cbx_high_speed_mode.EnableEvent(false);
            if ((generalSettings != null) && (generalSettings.HighSpeedBase != null) && (client != null) && (client.SensorFrequencyMax != 0))
            {
                if (cbx_high_speed_mode_ctrl.SelectedIndex >= 0)
                {
                    foreach (eClsHighSpeedMode _data in (eClsHighSpeedMode[])Enum.GetValues(typeof(eClsHighSpeedMode)))
                    {
                        if (generalSettings.General.ResourceLanguage.GetString(cStringEnum.GetStringValue(_data)) == cbx_high_speed_mode_ctrl.Text)
                        {
                            foreach (sHighSpeed value in generalSettings.HighSpeedBase.List)
                            {
                                if (value.HighSpeedMode == _data)
                                {
                                    generalSettings.General.HighSpeed = value;
                                    requestDark = true;
                                    break;
                                }
                            }
                            cbx_high_speed_ctrl.DropDownStyle = (generalSettings.General.HighSpeed.HighSpeedMode == eClsHighSpeedMode.eFreeFrequency) ? ComboBoxStyle.Simple : ComboBoxStyle.DropDownList;
                            break;
                        }
                    }
                    if (requestDark)
                    {
                        MessageBox.Show(generalSettings.General.ResourceLanguage.GetString("message_high_speed_dark"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        client.FreeSampleRate = generalSettings.General.HighSpeed.FrequencyValue;
                    }
                }
            }
            //enabled change
            cbx_high_speed_mode.EnableEvent(true);
            cbx_high_speed.EnableEvent(true);
        }
        #endregion
        #region UpdateHighSpeed
        public static void UpdateHighSpeed(cClientCommunication client, cGeneralSettings generalSettings, sControlUpdateEx cbx_high_speed_mode, sControlUpdateEx cbx_high_speed)
        {
            bool requestDark = false;
            ComboBox cbx_high_speed_ctrl = (ComboBox)cbx_high_speed.Object;
            ComboBox cbx_high_speed_mode_ctrl = (ComboBox)cbx_high_speed_mode.Object;
            UInt32 tmpFreeFrequencyValue = generalSettings.General.Sensor.StandardFrequency;
            
            //disabled change
            cbx_high_speed.EnableEvent(false);
            cbx_high_speed_mode.EnableEvent(false);
            if ((generalSettings != null) && (generalSettings.HighSpeedBase != null) && (client != null) && (client.SensorFrequencyMax != 0))
            {
                sHighSpeed _oldHighSpeed = generalSettings.General.HighSpeed.Clone();
                if (UInt32.TryParse(cbx_high_speed_ctrl.Text, out tmpFreeFrequencyValue))
                {
                    generalSettings.General.HighSpeed = new sHighSpeed(generalSettings.HighSpeedBase, tmpFreeFrequencyValue, client.SensorFrequencyMax);
                    if (generalSettings.General.HighSpeed != null)
                    {
                        cbx_high_speed_ctrl.DropDownStyle = (generalSettings.General.HighSpeed.HighSpeedMode == eClsHighSpeedMode.eFreeFrequency) ? ComboBoxStyle.Simple : ComboBoxStyle.DropDownList;
                        cbx_high_speed_mode.Text = generalSettings.General.ResourceLanguage.GetString(cStringEnum.GetStringValue(generalSettings.General.HighSpeed.HighSpeedMode));
                        requestDark = (_oldHighSpeed.HighSpeedMode != generalSettings.General.HighSpeed.HighSpeedMode) || (generalSettings.General.HighSpeed.HighSpeedMode == eClsHighSpeedMode.eHighSpeedLimitedRange);
                    }
                }
                if (requestDark)
                {
                    MessageBox.Show(generalSettings.General.ResourceLanguage.GetString("message_high_speed_dark"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                client.FreeSampleRate = generalSettings.General.HighSpeed.FrequencyValue;
            }
            //enabled change
            cbx_high_speed_mode.EnableEvent(true);
            cbx_high_speed.EnableEvent(true);
        }
        #endregion
    }

}