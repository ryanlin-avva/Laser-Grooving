using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using MagicCommonLibrary;
using MagicServerLibrary;
using System.Diagnostics;

namespace MagicAddOn
{
    //-------------------------------------------------------------------------
    public partial class f_selected_sodx : Form
    {
        enum eThreadAction
        {
            /// <summary>Updated Data To Form</summary>
            UpdatedDataToForm,
        }

        private cThreadProcess _threadProcess = null;


        public bool test = false;

        public delegate void UpdatedDataToFormDelegateHandler(object form);
        private UpdatedDataToFormDelegateHandler UpdatedDataToFormDelegate;
        public delegate void UpdatedFormToDataDelegateHandler(object form);
        private UpdatedFormToDataDelegateHandler UpdatedFormToDataDelegate;

        cSodxCommand _sodx_command = null;
        cSodxCommand _bak_sodx_command = null;
        bool IsBusyToUpdate = false;

        //-------------------------------------------------------------------------
        public f_selected_sodx()
        {
            InitializeComponent();
            _sodx_command = null;
            UpdatedDataToFormDelegate = new UpdatedDataToFormDelegateHandler(FuncUpdatedDataToForm);
            UpdatedFormToDataDelegate = new UpdatedFormToDataDelegateHandler(FuncUpdatedFormToData);            
            _threadProcess = new cThreadProcess(Enum.GetValues(typeof(eThreadAction)).Length);
            _threadProcess.StartThread(new ThreadStart(ThreadLoop));
        }
        //-------------------------------------------------------------------------
        private void f_selected_sodx_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_threadProcess != null)
            {
                _threadProcess.StopThread(500);
                _threadProcess.Dispose();
                _threadProcess = null;
            }
        }
        //--------------------------------------------------------------------------------------
        /// <summary>This method is called when starting the thread.</summary>
        private void ThreadLoop()
        {
            try
            {
                while (_threadProcess.EventExitProcessThread.WaitOne(100) == false)
                {
                    //Debug.WriteLine("f_selected_sodx ThreadGuiLoop");

                    if (_threadProcess.EventUserList[(int)eThreadAction.UpdatedDataToForm].WaitOne(0))
                    {
                        IsBusyToUpdate = true;
                        this.Invoke(this.UpdatedDataToFormDelegate, new object[] { this });
                        IsBusyToUpdate = false;
                    }
                }
                _threadProcess.EventExitProcessThreadDo.Set();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-------------------------------------------------------------------------
        public cSodxCommand SodxCommand
        {
            get { return (_sodx_command); }
            set
            {
                _sodx_command = value;
                _bak_sodx_command = _sodx_command.Copy();
            }
        }
        //-------------------------------------------------------------------------
        public cSodxCommand BackupSodxCommand
        {
            get { return (_bak_sodx_command); }            
        }
        //-------------------------------------------------------------------------
        private void f_selected_sodx_Load(object sender, EventArgs e)
        {
            this.Text = "Selecting Settings";
            _threadProcess.EventUserList[(int)eThreadAction.UpdatedDataToForm].Set();
        }       
        //----------------------------------------------------------------------------------------------------
        private static void FuncUpdatedDataToForm(object sender)
        {
            try
            {

                if (sender is f_selected_sodx)
                {
                    f_selected_sodx form = (f_selected_sodx)sender;
                    if ((form != null) && (form is f_selected_sodx))
                    {
                        //global signal------------------------------   
                        if (form.chk_start_time.Checked != form.BackupSodxCommand.GlobalSignal.StartTime)
                        {
                            form.chk_start_time.Checked = form.BackupSodxCommand.GlobalSignal.StartTime;
                        }
                        if (form.chk_start_position_x.Checked != form.BackupSodxCommand.GlobalSignal.StartPositionX)
                        {
                            form.chk_start_position_x.Checked = form.BackupSodxCommand.GlobalSignal.StartPositionX;
                        }
                        if (form.chk_start_position_y.Checked != form.BackupSodxCommand.GlobalSignal.StartPositionY)
                        {
                            form.chk_start_position_y.Checked = form.BackupSodxCommand.GlobalSignal.StartPositionY;
                        }
                        if (form.chk_start_position_z.Checked != form.BackupSodxCommand.GlobalSignal.StartPositionZ)
                        {
                            form.chk_start_position_z.Checked = form.BackupSodxCommand.GlobalSignal.StartPositionZ;
                        }
                        if (form.chk_start_position_u.Checked != form.BackupSodxCommand.GlobalSignal.StartPositionU)
                        {
                            form.chk_start_position_u.Checked = form.BackupSodxCommand.GlobalSignal.StartPositionU;
                        }
                        if (form.chk_start_position_v.Checked != form.BackupSodxCommand.GlobalSignal.StartPositionV)
                        {
                            form.chk_start_position_v.Checked = form.BackupSodxCommand.GlobalSignal.StartPositionV;
                        }
                        if (form.chk_stop_position_x.Checked != form.BackupSodxCommand.GlobalSignal.StopPositionX)
                        {
                            form.chk_stop_position_x.Checked = form.BackupSodxCommand.GlobalSignal.StopPositionX;
                        }
                        if (form.chk_stop_position_y.Checked != form.BackupSodxCommand.GlobalSignal.StopPositionY)
                        {
                            form.chk_stop_position_y.Checked = form.BackupSodxCommand.GlobalSignal.StopPositionY;
                        }
                        if (form.chk_stop_position_z.Checked != form.BackupSodxCommand.GlobalSignal.StopPositionZ)
                        {
                            form.chk_stop_position_z.Checked = form.BackupSodxCommand.GlobalSignal.StopPositionZ;
                        }
                        if (form.chk_stop_position_u.Checked != form.BackupSodxCommand.GlobalSignal.StopPositionU)
                        {
                            form.chk_stop_position_u.Checked = form.BackupSodxCommand.GlobalSignal.StopPositionU;
                        }
                        if (form.chk_stop_position_v.Checked != form.BackupSodxCommand.GlobalSignal.StopPositionV)
                        {
                            form.chk_stop_position_v.Checked = form.BackupSodxCommand.GlobalSignal.StopPositionV;
                        }
                        if (form.chk_first_exposure_count.Checked != form.BackupSodxCommand.GlobalSignal.FirstExposureCount)
                        {
                            form.chk_first_exposure_count.Checked = form.BackupSodxCommand.GlobalSignal.FirstExposureCount;
                        }
                        if (form.chk_exposure_flags.Checked != form.BackupSodxCommand.GlobalSignal.ExposureFlags)
                        {
                            form.chk_exposure_flags.Checked = form.BackupSodxCommand.GlobalSignal.ExposureFlags;
                        }
                        if (form.chk_real_exposure_time.Checked != form.BackupSodxCommand.GlobalSignal.RealExposureTime)
                        {
                            form.chk_real_exposure_time.Checked = form.BackupSodxCommand.GlobalSignal.RealExposureTime;
                        }
                        if (form.chk_real_lightning_time.Checked != form.BackupSodxCommand.GlobalSignal.RealLightningTime)
                        {
                            form.chk_real_lightning_time.Checked = form.BackupSodxCommand.GlobalSignal.RealLightningTime;
                        }
                        if (form.chk_trigger_lost_count.Checked != form.BackupSodxCommand.GlobalSignal.TriggerLostCount)
                        {
                            form.chk_trigger_lost_count.Checked = form.BackupSodxCommand.GlobalSignal.TriggerLostCount;
                        }
                        if (form.chk_number_of_valid_peaks.Checked != form.BackupSodxCommand.GlobalSignal.NumberOfValidPeaks)
                        {
                            form.chk_number_of_valid_peaks.Checked = form.BackupSodxCommand.GlobalSignal.NumberOfValidPeaks;
                        }
                        if (form.chk_ticket_number.Checked != form.BackupSodxCommand.GlobalSignal.TicketNumber)
                        {
                            form.chk_ticket_number.Checked = form.BackupSodxCommand.GlobalSignal.TicketNumber;
                        }
                        if (form.chk_sample_counter.Checked != form.BackupSodxCommand.GlobalSignal.SampleCounter)
                        {
                            form.chk_sample_counter.Checked = form.BackupSodxCommand.GlobalSignal.SampleCounter;
                        }
                        if (form.chk_health_dsp_load.Checked != form.BackupSodxCommand.GlobalSignal.HealthDspLoad)
                        {
                            form.chk_health_dsp_load.Checked = form.BackupSodxCommand.GlobalSignal.HealthDspLoad;
                        }
                        if (form.chk_health_ticket_wrong_order.Checked != form.BackupSodxCommand.GlobalSignal.HealthTicketWrongOrder)
                        {
                            form.chk_health_ticket_wrong_order.Checked = form.BackupSodxCommand.GlobalSignal.HealthTicketWrongOrder;
                        }
                        if (form.chk_health_upp_lost_count.Checked != form.BackupSodxCommand.GlobalSignal.HealthUppLostCount)
                        {
                            form.chk_health_upp_lost_count.Checked = form.BackupSodxCommand.GlobalSignal.HealthUppLostCount;
                        }
                        if (form.chk_health_exposure_lost_count.Checked != form.BackupSodxCommand.GlobalSignal.HealthExposureLostCount)
                        {
                            form.chk_health_exposure_lost_count.Checked = form.BackupSodxCommand.GlobalSignal.HealthExposureLostCount;
                        }
                        if (form.chk_health_upp_not_finished.Checked != form.BackupSodxCommand.GlobalSignal.HealthUppNotFinished)
                        {
                            form.chk_health_upp_not_finished.Checked = form.BackupSodxCommand.GlobalSignal.HealthUppNotFinished;
                        }
                        //Thickness---------------------------------
                        if (form.chk_thickness.Checked != form.BackupSodxCommand.Signal.Thickness)
                        {
                            form.chk_thickness.Checked = form.BackupSodxCommand.Signal.Thickness;
                        }
                        if (form.chk_thickness_peak_1.Checked != form.BackupSodxCommand.Signal.ThicknessPeak1)
                        {
                            form.chk_thickness_peak_1.Checked = form.BackupSodxCommand.Signal.ThicknessPeak1;
                        }
                        if (form.chk_thickness_peak_2.Checked != form.BackupSodxCommand.Signal.ThicknessPeak2)
                        {
                            form.chk_thickness_peak_2.Checked = form.BackupSodxCommand.Signal.ThicknessPeak2;
                        }
                        if (form.chk_thickness_peak_3.Checked != form.BackupSodxCommand.Signal.ThicknessPeak3)
                        {
                            form.chk_thickness_peak_3.Checked = form.BackupSodxCommand.Signal.ThicknessPeak3;
                        }
                        form.ed_thickness_reafractive_index_1.Enabled = form.chk_thickness_peak_1.Checked;
                        form.ed_thickness_reafractive_index_1.Text = form.BackupSodxCommand.Signal.RefractiveIndexTableThickness1.RefractiveIndexList[0].Value.ToString();
                        form.ed_thickness_reafractive_index_2.Enabled = form.chk_thickness_peak_2.Checked;
                        form.ed_thickness_reafractive_index_2.Text = form.BackupSodxCommand.Signal.RefractiveIndexTableThickness2.RefractiveIndexList[0].Value.ToString();
                        form.ed_thickness_reafractive_index_3.Enabled = form.chk_thickness_peak_3.Checked;
                        form.ed_thickness_reafractive_index_3.Text = form.BackupSodxCommand.Signal.RefractiveIndexTableThickness3.RefractiveIndexList[0].Value.ToString();
                        //Altitude---------------------------------
                        if (form.chk_altitude.Checked != form.BackupSodxCommand.Signal.Altitude)
                        {
                            form.chk_altitude.Checked = form.BackupSodxCommand.Signal.Altitude;
                        }
                        if (form.chk_altitude_peak_1.Checked != form.BackupSodxCommand.Signal.AltitudePeak1)
                        {
                            form.chk_altitude_peak_1.Checked = form.BackupSodxCommand.Signal.AltitudePeak1;
                        }
                        if (form.chk_altitude_peak_2.Checked != form.BackupSodxCommand.Signal.AltitudePeak2)
                        {
                            form.chk_altitude_peak_2.Checked = form.BackupSodxCommand.Signal.AltitudePeak2;
                        }
                        if (form.chk_altitude_peak_3.Checked != form.BackupSodxCommand.Signal.AltitudePeak3)
                        {
                            form.chk_altitude_peak_3.Checked = form.BackupSodxCommand.Signal.AltitudePeak3;
                        }
                        if (form.chk_altitude_peak_4.Checked != form.BackupSodxCommand.Signal.AltitudePeak4)
                        {
                            form.chk_altitude_peak_4.Checked = form.BackupSodxCommand.Signal.AltitudePeak4;
                        }                  
                        //IntensityLevel---------------------------------
                        if (form.chk_intensity_level.Checked != form.BackupSodxCommand.Signal.IntensityLevel)
                        {
                            form.chk_intensity_level.Checked = form.BackupSodxCommand.Signal.IntensityLevel;
                        }
                        if (form.chk_intensity_level_peak_1.Checked != form.BackupSodxCommand.Signal.IntensityLevelPeak1)
                        {
                            form.chk_intensity_level_peak_1.Checked = form.BackupSodxCommand.Signal.IntensityLevelPeak1;
                        }
                        if (form.chk_intensity_level_peak_2.Checked != form.BackupSodxCommand.Signal.IntensityLevelPeak2)
                        {
                            form.chk_intensity_level_peak_2.Checked = form.BackupSodxCommand.Signal.IntensityLevelPeak2;
                        }
                        if (form.chk_intensity_level_peak_3.Checked != form.BackupSodxCommand.Signal.IntensityLevelPeak3)
                        {
                            form.chk_intensity_level_peak_3.Checked = form.BackupSodxCommand.Signal.IntensityLevelPeak3;
                        }
                        if (form.chk_intensity_level_peak_4.Checked != form.BackupSodxCommand.Signal.IntensityLevelPeak4)
                        {
                            form.chk_intensity_level_peak_4.Checked = form.BackupSodxCommand.Signal.IntensityLevelPeak4;
                        }
                        //Roughness / Waviness-----------------------
                        if (form.chk_roughness.Checked != form.BackupSodxCommand.RoughnessWavinessProcessing.Roughness)
                        {
                            form.chk_roughness.Checked = form.BackupSodxCommand.RoughnessWavinessProcessing.Roughness;
                        }
                        if (form.chk_waviness.Checked != form.BackupSodxCommand.RoughnessWavinessProcessing.Waviness)
                        {
                            form.chk_waviness.Checked = form.BackupSodxCommand.RoughnessWavinessProcessing.Waviness;
                        }
                        if (form.chk_roughness_coeficient_on_roughness.Checked != form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessCoefficientOnRoughness)
                        {
                            form.chk_roughness_coeficient_on_roughness.Checked = form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessCoefficientOnRoughness;
                        }
                        if (form.chk_roughness_coeficient_on_waviness.Checked != form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessCoefficientOnWaviness)
                        {
                            form.chk_roughness_coeficient_on_waviness.Checked = form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessCoefficientOnWaviness;
                        }
                        switch (form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessSignal)
                        {
                            case eRoughnessSignal.AltitudePeak2:
                                form.rb_roughness_altitude_peak_2.Checked = true;
                                break;
                            case eRoughnessSignal.AltitudePeak3:
                                form.rb_roughness_altitude_peak_3.Checked = true;
                                break;
                            case eRoughnessSignal.AltitudePeak4:
                                form.rb_roughness_altitude_peak_4.Checked = true;
                                break;
                            default:
                                form.rb_roughness_altitude_peak_1.Checked = true;
                                break;
                        }
                        switch (form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessFilter)
                        {
                            case eRoughnessFilter.Ten:
                                form.rb_roughness_filter_ten.Checked = true;
                                break;
                            case eRoughnessFilter.Twenty:
                                form.rb_roughness_filter_twenty.Checked = true;
                                break;
                            case eRoughnessFilter.Forty:
                                form.rb_roughness_filter_forty.Checked = true;
                                break;
                            default:
                                form.rb_roughness_filter_five.Checked = true;
                                break;
                        }
                        form.chk_roughness_interpolation.Checked = form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessIsolatedNonMeasuredInterpolation;
                        form.chk_roughness_despiking.Checked = form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessDespiking;
                        //Processing---------------------------------
                        if (form.rb_temporal_average.Checked != form.BackupSodxCommand.SignalProcessing.TemporalAverage)
                        {
                            form.rb_temporal_average.Checked = form.BackupSodxCommand.SignalProcessing.TemporalAverage;
                        }
                        if (form.nud_temporal_average.Value != form.BackupSodxCommand.SignalProcessing.TemporalAverageNumber)
                        {
                            form.nud_temporal_average.Text = form.BackupSodxCommand.SignalProcessing.TemporalAverageNumber.ToString();
                        }
                        if (form.rb_moving_average.Checked != form.BackupSodxCommand.SignalProcessing.MovingAverage)
                        {
                            form.rb_moving_average.Checked = form.BackupSodxCommand.SignalProcessing.MovingAverage;
                        }
                        if (form.nud_moving_average.Value != form.BackupSodxCommand.SignalProcessing.MovingAverageNumber)
                        {
                            form.nud_moving_average.Text = form.BackupSodxCommand.SignalProcessing.MovingAverageNumber.ToString();
                        }
                        if (form.rb_moving_line_despiking.Checked != form.BackupSodxCommand.SignalProcessing.MovingLineDespiking)
                        {
                            form.rb_moving_line_despiking.Checked = form.BackupSodxCommand.SignalProcessing.MovingLineDespiking;
                        }
                        if (form.nt_moving_despike_threshold.Value != (decimal)form.BackupSodxCommand.SignalProcessing.MovingLineDespikingThreshold)
                        {
                            form.nt_moving_despike_threshold.Text = form.BackupSodxCommand.SignalProcessing.MovingLineDespikingThreshold.ToString();
                        }
                        if (form.nt_moving_interpolation_coefficient.Value != (decimal)form.BackupSodxCommand.SignalProcessing.MovingLineDespikingCoefficient)
                        {
                            form.nt_moving_interpolation_coefficient.Text = form.BackupSodxCommand.SignalProcessing.MovingLineDespikingCoefficient.ToString();
                        }
                        if (form.chk_interpolation.Checked != form.BackupSodxCommand.SignalProcessing.IsolatedNonMeasuredInterpolation)
                        {
                            form.chk_interpolation.Checked = form.BackupSodxCommand.SignalProcessing.IsolatedNonMeasuredInterpolation;
                        }
                        if (form.rb_line_smoothing.Checked != form.BackupSodxCommand.SignalProcessing.LineSmoothing)
                        {
                            form.rb_line_smoothing.Checked = form.BackupSodxCommand.SignalProcessing.LineSmoothing;
                        }
                        switch (form.BackupSodxCommand.SignalProcessing.LineSmoothingValue)
                        {
                            case eLineSmoothing.Three:
                                form.rb_line_smoothing_3.Checked = true;
                                break;
                            case eLineSmoothing.Five:
                                form.rb_line_smoothing_5.Checked = true;
                                break;
                            default:
                                form.rb_line_smoothing_1.Checked = true;
                                break;
                        }
                        if (form.rb_line_despiking.Checked != form.BackupSodxCommand.SignalProcessing.LineDespiking)
                        {
                            form.rb_line_despiking.Checked = form.BackupSodxCommand.SignalProcessing.LineDespiking;
                        }
                        if (form.nt_despike_threshold.Value != (decimal)form.BackupSodxCommand.SignalProcessing.LineDespikingThreshold)
                        {
                            form.nt_despike_threshold.Text = form.BackupSodxCommand.SignalProcessing.LineDespikingThreshold.ToString();
                        }
                        if (form.nt_interpolation_coefficient.Value != (decimal)form.BackupSodxCommand.SignalProcessing.MovingLineDespikingCoefficient)
                        {
                            form.nt_interpolation_coefficient.Text = form.BackupSodxCommand.SignalProcessing.MovingLineDespikingCoefficient.ToString(); 
                        }
                        //interactive changes
                        bool Processing = ((form.BackupSodxCommand.RoughnessWavinessProcessing.Roughness == false) && (form.BackupSodxCommand.RoughnessWavinessProcessing.Waviness == false) && (form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessCoefficientOnRoughness == false) && (form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessCoefficientOnWaviness == false));
                        bool Roughness = (Processing) ? false : true;
                        //Thickness
                        if ((form.chk_thickness.Checked == false) || (Roughness))
                        {
                            form.chk_thickness.Checked = false;
                            form.chk_thickness_peak_1.Checked = false;
                            form.chk_thickness_peak_2.Checked = false;
                            form.chk_thickness_peak_3.Checked = false;
                        }
                        form.chk_thickness.Enabled = Processing;
                        form.chk_thickness_peak_1.Enabled = form.chk_thickness.Checked;
                        form.chk_thickness_peak_2.Enabled = form.chk_thickness.Checked;
                        form.chk_thickness_peak_3.Enabled = form.chk_thickness.Checked;

                        //Altitude
                        form.chk_altitude_peak_1.Checked = (form.BackupSodxCommand.Signal.AltitudePeak1) || (form.BackupSodxCommand.Signal.ThicknessPeak1);
                        form.chk_altitude_peak_2.Checked = (form.BackupSodxCommand.Signal.AltitudePeak2) || (form.BackupSodxCommand.Signal.ThicknessPeak1) || (form.BackupSodxCommand.Signal.ThicknessPeak2);
                        form.chk_altitude_peak_3.Checked = (form.BackupSodxCommand.Signal.AltitudePeak3) || (form.BackupSodxCommand.Signal.ThicknessPeak2) || (form.BackupSodxCommand.Signal.ThicknessPeak3);
                        form.chk_altitude_peak_4.Checked = (form.BackupSodxCommand.Signal.AltitudePeak4) || (form.BackupSodxCommand.Signal.ThicknessPeak3);
                        if (Roughness)
                        {
                            form.chk_altitude.Checked = false;
                            form.chk_altitude.Enabled = false;
                            form.chk_altitude_peak_1.Checked = false;
                            form.chk_altitude_peak_2.Checked = false;
                            form.chk_altitude_peak_3.Checked = false;
                            form.chk_altitude_peak_4.Checked = false;
                            form.chk_altitude_peak_1.Enabled = false;
                            form.chk_altitude_peak_2.Enabled = false;
                            form.chk_altitude_peak_3.Enabled = false;
                            form.chk_altitude_peak_4.Enabled = false;
                            if (form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessSignal == eRoughnessSignal.AltitudePeak1)
                            {
                                form.chk_altitude_peak_1.Checked = (form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessSignal == eRoughnessSignal.AltitudePeak1);
                                form.chk_altitude_peak_1.Enabled = false;
                                form.chk_altitude.Checked = true;
                            }
                            if (form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessSignal == eRoughnessSignal.AltitudePeak2)
                            {
                                form.chk_altitude_peak_2.Checked = (form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessSignal == eRoughnessSignal.AltitudePeak2);
                                form.chk_altitude_peak_2.Enabled = false;
                                form.chk_altitude.Checked = true;
                            }
                            if (form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessSignal == eRoughnessSignal.AltitudePeak3)
                            {
                                form.chk_altitude_peak_3.Checked = (form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessSignal == eRoughnessSignal.AltitudePeak3);
                                form.chk_altitude_peak_3.Enabled = false;
                                form.chk_altitude.Checked = true;
                            }
                            if (form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessSignal == eRoughnessSignal.AltitudePeak4)
                            {
                                form.chk_altitude_peak_4.Checked = (form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessSignal == eRoughnessSignal.AltitudePeak4);
                                form.chk_altitude_peak_4.Enabled = false;
                                form.chk_altitude.Checked = true;
                            }
                        }
                        else if ((Processing) && (form.BackupSodxCommand.Signal.Thickness))
                        {
                            form.chk_altitude_peak_1.Enabled = ((form.BackupSodxCommand.Signal.Altitude) && (form.BackupSodxCommand.Signal.ThicknessPeak1 == false));
                            form.chk_altitude_peak_2.Enabled = ((form.BackupSodxCommand.Signal.Altitude) && (form.BackupSodxCommand.Signal.ThicknessPeak1 == false) && (form.BackupSodxCommand.Signal.ThicknessPeak2 == false));
                            form.chk_altitude_peak_3.Enabled = ((form.BackupSodxCommand.Signal.Altitude) && (form.BackupSodxCommand.Signal.ThicknessPeak2 == false) && (form.BackupSodxCommand.Signal.ThicknessPeak3 == false));
                            form.chk_altitude_peak_4.Enabled = ((form.BackupSodxCommand.Signal.Altitude) && (form.BackupSodxCommand.Signal.ThicknessPeak3 == false));
                            form.chk_altitude.Checked = (form.chk_altitude_peak_1.Checked) || (form.chk_altitude_peak_2.Checked) || (form.chk_altitude_peak_3.Checked) || (form.chk_altitude_peak_4.Checked);
                        }
                        else
                        {
                            form.chk_altitude.Enabled = Processing;
                            form.chk_altitude_peak_1.Enabled = form.chk_altitude.Checked;
                            form.chk_altitude_peak_2.Enabled = form.chk_altitude.Checked;
                            form.chk_altitude_peak_3.Enabled = form.chk_altitude.Checked;
                            form.chk_altitude_peak_4.Enabled = form.chk_altitude.Checked;
                        }                        
                        //Intensity Level
                        if (Roughness)
                        {
                            form.chk_intensity_level.Checked = false;
                            form.chk_intensity_level_peak_1.Checked = false;
                            form.chk_intensity_level_peak_2.Checked = false;
                            form.chk_intensity_level_peak_3.Checked = false;
                            form.chk_intensity_level_peak_4.Checked = false;
                        }
                        form.chk_intensity_level.Enabled = Processing;
                        form.chk_intensity_level_peak_1.Enabled = form.chk_intensity_level.Checked;
                        form.chk_intensity_level_peak_2.Enabled = form.chk_intensity_level.Checked;
                        form.chk_intensity_level_peak_3.Enabled = form.chk_intensity_level.Checked;
                        form.chk_intensity_level_peak_4.Enabled = form.chk_intensity_level.Checked;
                        //Roughness
                        form.gp_roughness_altitude.Enabled = Roughness;
                        form.gp_roughness_filter.Enabled = Roughness;
                        form.gp_processing.Enabled = (Processing);
                        form.chk_roughness_interpolation.Enabled = Roughness;
                        form.chk_roughness_despiking.Enabled = Roughness;
                        form.gp_roughness_line_despiking.Enabled = (Roughness && form.chk_roughness_despiking.Checked);
                        if (form.nt_roughness_despike_threshold.Value != (decimal)form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessDespikeThreshold)
                        {
                            form.nt_roughness_despike_threshold.Text= form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessDespikeThreshold.ToString();
                        }
                        if (form.nt_roughness_interpolation_coefficient.Value != (decimal)form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessInterpolationCoefficient)
                        {
                            form.nt_roughness_interpolation_coefficient.Text = form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessInterpolationCoefficient.ToString();
                        }
                        if (Processing)
                        {
                            form.chk_roughness_interpolation.Checked = false;
                            form.chk_roughness_despiking.Checked = false;
                        }
                        //Processing
                        //form.gp_moving_line_despiking.Enabled = form.rb_moving_line_despiking.Checked;
                        form.gp_line_smoothing.Enabled = form.rb_line_smoothing.Checked;
                        //form.gp_line_despiking.Enabled = form.rb_line_despiking.Checked;
                        form.nud_temporal_average.Enabled = form.rb_temporal_average.Checked;
                        form.nud_moving_average.Enabled = form.rb_moving_average.Checked;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", "f_selected_sodx", System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //----------------------------------------------------------------------------------------------------
        private static void FuncUpdatedFormToData(object sender)
        {
            try
            {
                if (sender is f_selected_sodx)
                {
                    f_selected_sodx form = (f_selected_sodx)sender;
                    if ((form != null) && (form is f_selected_sodx))
                    {
                        //global signal------------------------------                        
                        form.BackupSodxCommand.GlobalSignal.StartTime = form.chk_start_time.Checked;
                        form.BackupSodxCommand.GlobalSignal.StartPositionX = form.chk_start_position_x.Checked;
                        form.BackupSodxCommand.GlobalSignal.StartPositionY = form.chk_start_position_y.Checked;
                        form.BackupSodxCommand.GlobalSignal.StartPositionZ = form.chk_start_position_z.Checked;
                        form.BackupSodxCommand.GlobalSignal.StartPositionU = form.chk_start_position_u.Checked;
                        form.BackupSodxCommand.GlobalSignal.StartPositionV = form.chk_start_position_v.Checked;
                        form.BackupSodxCommand.GlobalSignal.StopPositionX = form.chk_stop_position_x.Checked;
                        form.BackupSodxCommand.GlobalSignal.StopPositionY = form.chk_stop_position_y.Checked;
                        form.BackupSodxCommand.GlobalSignal.StopPositionZ = form.chk_stop_position_z.Checked;
                        form.BackupSodxCommand.GlobalSignal.StopPositionU = form.chk_stop_position_u.Checked;
                        form.BackupSodxCommand.GlobalSignal.StopPositionV = form.chk_stop_position_v.Checked;
                        form.BackupSodxCommand.GlobalSignal.FirstExposureCount = form.chk_first_exposure_count.Checked;
                        form.BackupSodxCommand.GlobalSignal.ExposureFlags = form.chk_exposure_flags.Checked;
                        form.BackupSodxCommand.GlobalSignal.RealExposureTime = form.chk_real_exposure_time.Checked;
                        form.BackupSodxCommand.GlobalSignal.RealLightningTime = form.chk_real_lightning_time.Checked;
                        form.BackupSodxCommand.GlobalSignal.TriggerLostCount = form.chk_trigger_lost_count.Checked;
                        form.BackupSodxCommand.GlobalSignal.NumberOfValidPeaks = form.chk_number_of_valid_peaks.Checked;
                        form.BackupSodxCommand.GlobalSignal.TicketNumber = form.chk_ticket_number.Checked;
                        form.BackupSodxCommand.GlobalSignal.SampleCounter = form.chk_sample_counter.Checked;
                        form.BackupSodxCommand.GlobalSignal.HealthDspLoad = form.chk_health_dsp_load.Checked;
                        form.BackupSodxCommand.GlobalSignal.HealthTicketWrongOrder = form.chk_health_ticket_wrong_order.Checked;
                        form.BackupSodxCommand.GlobalSignal.HealthUppLostCount = form.chk_health_upp_lost_count.Checked;
                        form.BackupSodxCommand.GlobalSignal.HealthExposureLostCount = form.chk_health_exposure_lost_count.Checked;
                        form.BackupSodxCommand.GlobalSignal.HealthUppNotFinished = form.chk_health_upp_not_finished.Checked;
                        //Thickness---------------------------------                             
                        if ((form.chk_thickness.Checked == true) && (form.BackupSodxCommand.Signal.ThicknessPeak1 == false) && (form.BackupSodxCommand.Signal.ThicknessPeak2 == false) && (form.BackupSodxCommand.Signal.ThicknessPeak3 == false))
                        {
                            form.BackupSodxCommand.Signal.ThicknessPeak1 = true;
                        }
                        else if ((form.chk_thickness.Checked == false) && ((form.chk_thickness_peak_1.Checked == true) || (form.chk_thickness_peak_2.Checked == true) || (form.chk_thickness_peak_3.Checked == true)))
                        {
                            form.BackupSodxCommand.Signal.ThicknessPeak1 = false;
                            form.BackupSodxCommand.Signal.ThicknessPeak2 = false;
                            form.BackupSodxCommand.Signal.ThicknessPeak3 = false;
                        }
                        else
                        {
                            form.BackupSodxCommand.Signal.ThicknessPeak1 = form.chk_thickness_peak_1.Checked;
                            form.BackupSodxCommand.Signal.ThicknessPeak2 = form.chk_thickness_peak_2.Checked;
                            form.BackupSodxCommand.Signal.ThicknessPeak3 = form.chk_thickness_peak_3.Checked;
                        }
                        form.BackupSodxCommand.Signal.RefractiveIndexTableThickness1 = new cRefractiveIndexTables((float)form.ed_thickness_reafractive_index_1.Value);
                        form.BackupSodxCommand.Signal.RefractiveIndexTableThickness2 = new cRefractiveIndexTables((float)form.ed_thickness_reafractive_index_2.Value);
                        form.BackupSodxCommand.Signal.RefractiveIndexTableThickness3 = new cRefractiveIndexTables((float)form.ed_thickness_reafractive_index_3.Value);
                        //Altitude---------------------------------    
                        if ((form.chk_altitude.Checked == true) && (form.BackupSodxCommand.Signal.AltitudePeak1 == false) && (form.BackupSodxCommand.Signal.AltitudePeak2 == false) && (form.BackupSodxCommand.Signal.AltitudePeak3 == false) && (form.BackupSodxCommand.Signal.AltitudePeak4 == false))
                        {
                            form.BackupSodxCommand.Signal.AltitudePeak1 = true;
                        }
                        else if ((form.chk_altitude.Checked == false) && ((form.chk_altitude_peak_1.Checked == true) || (form.chk_altitude_peak_2.Checked == true) || (form.chk_altitude_peak_3.Checked == true) || (form.chk_altitude_peak_4.Checked == true)))
                        {
                            form.BackupSodxCommand.Signal.AltitudePeak1 = false;
                            form.BackupSodxCommand.Signal.AltitudePeak2 = false;
                            form.BackupSodxCommand.Signal.AltitudePeak3 = false;
                            form.BackupSodxCommand.Signal.AltitudePeak4 = false;
                        }
                        else
                        {
                            form.BackupSodxCommand.Signal.AltitudePeak1 = form.chk_altitude_peak_1.Checked;
                            form.BackupSodxCommand.Signal.AltitudePeak2 = form.chk_altitude_peak_2.Checked;
                            form.BackupSodxCommand.Signal.AltitudePeak3 = form.chk_altitude_peak_3.Checked;
                            form.BackupSodxCommand.Signal.AltitudePeak4 = form.chk_altitude_peak_4.Checked;
                        }
                        //IntensityLevel---------------------------------                        
                        if ((form.chk_intensity_level.Checked == true) && (form.BackupSodxCommand.Signal.IntensityLevelPeak1 == false) && (form.BackupSodxCommand.Signal.IntensityLevelPeak2 == false) && (form.BackupSodxCommand.Signal.IntensityLevelPeak3 == false) && (form.BackupSodxCommand.Signal.IntensityLevelPeak4 == false))
                        {
                            form.BackupSodxCommand.Signal.IntensityLevelPeak1 = true;
                        }
                        else if ((form.chk_intensity_level.Checked == false) && ((form.chk_intensity_level_peak_1.Checked == true) || (form.chk_intensity_level_peak_2.Checked == true) || (form.chk_intensity_level_peak_3.Checked == true) || (form.chk_intensity_level_peak_4.Checked == true)))
                        {
                            form.BackupSodxCommand.Signal.IntensityLevelPeak1 = false;
                            form.BackupSodxCommand.Signal.IntensityLevelPeak2 = false;
                            form.BackupSodxCommand.Signal.IntensityLevelPeak3 = false;
                            form.BackupSodxCommand.Signal.IntensityLevelPeak4 = false;
                        }
                        else
                        {
                            form.BackupSodxCommand.Signal.IntensityLevelPeak1 = form.chk_intensity_level_peak_1.Checked;
                            form.BackupSodxCommand.Signal.IntensityLevelPeak2 = form.chk_intensity_level_peak_2.Checked;
                            form.BackupSodxCommand.Signal.IntensityLevelPeak3 = form.chk_intensity_level_peak_3.Checked;
                            form.BackupSodxCommand.Signal.IntensityLevelPeak4 = form.chk_intensity_level_peak_4.Checked;
                        }
                        //Roughness/Waviness
                        form.BackupSodxCommand.RoughnessWavinessProcessing.Roughness = form.chk_roughness.Checked;
                        form.BackupSodxCommand.RoughnessWavinessProcessing.Waviness = form.chk_waviness.Checked;
                        form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessCoefficientOnRoughness = form.chk_roughness_coeficient_on_roughness.Checked;
                        form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessCoefficientOnWaviness = form.chk_roughness_coeficient_on_waviness.Checked;
                        if (form.rb_roughness_altitude_peak_2.Checked)
                        {
                            form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessSignal = eRoughnessSignal.AltitudePeak2;
                        }
                        else if (form.rb_roughness_altitude_peak_3.Checked)
                        {
                            form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessSignal = eRoughnessSignal.AltitudePeak3;
                        }
                        else if (form.rb_roughness_altitude_peak_4.Checked)
                        {
                            form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessSignal = eRoughnessSignal.AltitudePeak4;
                        }
                        else
                        {
                            form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessSignal = eRoughnessSignal.AltitudePeak1;
                        }
                        if (form.rb_roughness_filter_ten.Checked)
                        {
                            form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessFilter = eRoughnessFilter.Ten;
                        }
                        else if (form.rb_roughness_filter_twenty.Checked)
                        {
                            form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessFilter = eRoughnessFilter.Twenty;
                        }
                        else if (form.rb_roughness_filter_forty.Checked)
                        {
                            form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessFilter = eRoughnessFilter.Forty;
                        }
                        else
                        {
                            form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessFilter = eRoughnessFilter.Five;
                        }
                        form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessIsolatedNonMeasuredInterpolation = form.chk_roughness_interpolation.Checked;
                        form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessDespiking = form.chk_roughness_despiking.Checked;
                        form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessDespikeThreshold = (UInt32)form.nt_roughness_despike_threshold.Value;
                        form.BackupSodxCommand.RoughnessWavinessProcessing.RoughnessInterpolationCoefficient = (float)form.nt_roughness_interpolation_coefficient.Value;   
                        //Processing
                        form.BackupSodxCommand.SignalProcessing.TemporalAverage = form.rb_temporal_average.Checked;
                        form.BackupSodxCommand.SignalProcessing.TemporalAverageNumber = (UInt32)form.nud_temporal_average.Value;
                        form.BackupSodxCommand.SignalProcessing.MovingAverage = form.rb_moving_average.Checked;
                        form.BackupSodxCommand.SignalProcessing.MovingAverageNumber = (UInt32)form.nud_moving_average.Value;
                        form.BackupSodxCommand.SignalProcessing.MovingLineDespiking = form.rb_moving_line_despiking.Checked;
                        form.BackupSodxCommand.SignalProcessing.MovingLineDespikingThreshold = (UInt32)form.nt_moving_despike_threshold.Value;
                        form.BackupSodxCommand.SignalProcessing.MovingLineDespikingCoefficient = (float)form.nt_moving_interpolation_coefficient.Value;
                        form.BackupSodxCommand.SignalProcessing.IsolatedNonMeasuredInterpolation = form.chk_interpolation.Checked;
                        form.BackupSodxCommand.SignalProcessing.LineSmoothing = form.rb_line_smoothing.Checked;
                        if (form.rb_line_smoothing_3.Checked)
                        {
                            form.BackupSodxCommand.SignalProcessing.LineSmoothingValue = eLineSmoothing.Three;
                        }
                        else if (form.rb_line_smoothing_5.Checked)
                        {
                            form.BackupSodxCommand.SignalProcessing.LineSmoothingValue = eLineSmoothing.Five;
                        }
                        else
                        {
                            form.BackupSodxCommand.SignalProcessing.LineSmoothingValue = eLineSmoothing.One;
                        }

                        form.BackupSodxCommand.SignalProcessing.LineDespiking = form.rb_line_despiking.Checked;
                        form.BackupSodxCommand.SignalProcessing.LineDespikingThreshold = (UInt32)form.nt_despike_threshold.Value;
                        form.BackupSodxCommand.SignalProcessing.LineDespikingCoefficient = (float)form.nt_interpolation_coefficient.Value;   
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", "f_selected_sodx", System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-------------------------------------------------------------------------  
        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Invoke(this.UpdatedFormToDataDelegate, new object[] { this });
            DialogResult = DialogResult.OK;
        }
        //-------------------------------------------------------------------------  
        private void DataChange(object sender, EventArgs e)
        {
            if (IsBusyToUpdate == false)
            {
                IsBusyToUpdate = true;
                this.Invoke(this.UpdatedFormToDataDelegate, new object[] { this });
                this.Invoke(this.UpdatedDataToFormDelegate, new object[] { this });
                IsBusyToUpdate = false;
            }            
        }        
        //-------------------------------------------------------------------------        
    }
    //-------------------------------------------------------------------------
}
