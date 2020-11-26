using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
#if (_CLS)
using MagicCommonLibrary;
using MagicGraphicLibrary;
#elif (_MPS)
using MpsCommonLibrary;
using MpsGraphicLibrary;
#else
using MagicCommonLibrary;
using MagicGraphicLibrary;
#endif

#if (_CLS)
namespace MagicAddOn
#elif (_MPS)
namespace MpsAddOn
#else
namespace AddOn
#endif
{
    public partial class f_splash : Form
    {
        /// <summary>liste des actions a effectuer.</summary>
        enum eSplashAction
        {
            /// <summary>rien à faire</summary>
            eNothingToDo,
            /// <summary>chargement des DLL</summary>
            eLoadAssembly,
        }

        int _counterGauge = 0;
        cThreadProcess _threadGui = null;
        Version _version = null;

        #region Constructor
        public f_splash()
        {
            InitializeComponent();
        }
        public f_splash(Version version)
        {
            InitializeComponent();
            _version = version;
        } 
        #endregion
        #region Load
        private void f_splash_Load(object sender, EventArgs e)
        {
            _threadGui = new cThreadProcess("f_splash.Guid", 0);
            _threadGui.StartThread(new ThreadStart(ThreadGuiLoop));
            pic_logo.SizeMode = PictureBoxSizeMode.Zoom;
            pic_logo.Image = cResources.GetImageLogo;
            pic_logo.Visible = (pic_logo.Image != null);
            lbl_starting.Visible = (pic_logo.Image == null);
            lbl_version.Visible = (_version != null);
            lbl_version.Text = string.Format("Version : {0}", _version);
        } 
        #endregion
        #region ThreadGuiLoop
        /// <summary>This method is called when starting the thread.</summary> 
        public void ThreadGuiLoop()
        {
            try
            {
#if (!_QUICK_START)
               int timeout = 100;
#else
                int timeout = 10;

#endif
                while (!_threadGui.EventExitProcessThread.WaitOne(timeout))
                {
#if (!_QUICK_START)
                    if (_counterGauge < Enum.GetValues(typeof(eSplashAction)).Length)
                    {
                        eSplashAction splashAction = (eSplashAction)_counterGauge;
                        //eLoadAssembly
                        if (splashAction == eSplashAction.eLoadAssembly)
                        {
                            var assemblyFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory).Where(file => Path.GetExtension(file).Equals(".dll", StringComparison.OrdinalIgnoreCase));
                            this.Invoke((MethodInvoker)delegate { pgb_load.Value = pgb_load.Maximum = assemblyFiles.Count() + 1; }); 
                            foreach (var assemblyFile in assemblyFiles)
                            {
                                _counterGauge++;
                                this.Invoke((MethodInvoker)delegate
                                {
                                    pgb_load.Value = _counterGauge;
                                    lbl_action.Text = Path.GetFileName(assemblyFile);
                                    Thread.Sleep(200);
                                });
                                Console.Write("Load Assembly : [{0}]", Path.GetFileName(assemblyFile));
                                try
                                {
                                    Assembly.LoadFrom(assemblyFile);
                                    Console.WriteLine("OK");
                                }
                                catch(Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                    }
#endif
                    _counterGauge++;
                    if (_counterGauge >= pgb_load.Maximum)
                    {
                        _threadGui.EventExitProcessThread.Set();
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate { pgb_load.Value = _counterGauge; });
                    }
                }

                _threadGui.EventExitProcessThreadDo.Set();
                this.Invoke((MethodInvoker)delegate { this.Close(); });
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region FormClosed
        private void f_splash_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_threadGui != null)
            {
                _threadGui.StopThread(500);
                _threadGui.Dispose();
                _threadGui = null;
            }
        } 
        #endregion
    }
}

