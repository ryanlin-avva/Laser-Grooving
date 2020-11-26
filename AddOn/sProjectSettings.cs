using MagicCommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Velociraptor.AddOn
{
    [Serializable]
    public class sProjectSettings : ICloneable, IDisposable
    {
        bool _disposed = false;
        #region GlobalSignals
        sSodxGlobalSignal _globalSignal = null;
        #endregion
        #region Signal
        sSodxSignal _signal = null;
        #endregion
        #region Sensor(s) Settings
        sProjectSettings _sensorSettingsCls_0 = null;
        #endregion
        eIdentification _identification = eIdentification.Cls_0;

        #region Constructor
        public sProjectSettings()
        {
           
            _globalSignal = new sSodxGlobalSignal();
            _signal = new sSodxSignal();
            Clear();
        }
        #endregion
        #region Clone
        /// <summary>
        /// Clonage de la classe
        /// </summary>
        /// <returns>retourne la classe clonée</returns>
        object ICloneable.Clone()
        {
            return this.Clone();
        }
        /// <summary>
        /// Clonage de la classe
        /// </summary>
        /// <returns>retourne la classe clonée</returns>
        public sProjectSettings Clone()
        {
            return (sProjectSettings)this.MemberwiseClone();
        }
        #endregion
        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                   
                    #region _globalSignal
                    if (_globalSignal != null)
                    {
                        _globalSignal.Dispose();
                        _globalSignal = null;
                    }
                    #endregion
                    #region _signal
                    if (_signal != null)
                    {
                        _signal.Dispose();
                        _signal = null;
                    }
                    #endregion
                }
                // Free your own state (unmanaged objects).  
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        #region Clear
        /// <summary>
        /// Efface les informations courantes et initialise les valeurs par défaut.
        /// </summary>
        public void Clear()
        {
            AutoDating = false;
            AutoRearmTrigger = false;
            EnabledTrigger = false;
            DataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Filename = "Sample";
            NumberOfSamples = -1;
        }
        #endregion

        #region Properties
        #region SenorSettingsCls_0
        /// <summary>Senor Settings Cls 0</summary>
        public sProjectSettings SenorSettingsCls_0
        {
            get { return (_sensorSettingsCls_0); }
            set
            {
                _sensorSettingsCls_0 = value;
            }
        }
        #endregion
      
        #region DataDirectory
        public string DataDirectory
        {
            get;
            set;
        }
        #endregion
        #region Filename
        public string Filename
        {
            get;
            set;
        }
        #endregion
        #region DataDirectoryFilename
        public string DataDirectoryFilename
        {
            get;
            set;
        }
        #endregion
        #region EnabledTrigger
        public bool EnabledTrigger
        {
            get;
            set;
        }
        #endregion
        #region AutoRearmTrigger
        public bool AutoRearmTrigger
        {
            get;
            set;
        }
        #endregion
        #region AutoDating
        public bool AutoDating
        {
            get;
            set;
        }
        #endregion
        #region NumberOfSamples
        public int NumberOfSamples
        {
            get;
            set;
        }
        #endregion
        #region Recording
        [XmlIgnore]
        public bool Recording
        {
            get;
            set;
        }
        #endregion
        #region Global Signal
        /// <summary>Global Signal</summary>
        public sSodxGlobalSignal GlobalSignal
        {
            get { return (_globalSignal); }
            set
            {
                if (_globalSignal != null)
                {
                    _globalSignal = value;
                }
            }
        }
        #endregion
        #region Signal
        /// <summary>Signal</summary>
        public sSodxSignal Signal
        {
            get { return (_signal); }
            set
            {
                if (_signal != null)
                {
                    _signal = value;
                }
            }
        }
        #endregion
        #region Identification
        public eIdentification Identification
        {
            get { return (_identification); }
            set
            {
                if (_identification != value)
                {
                    _identification = value;
                }
            }
        }
        #endregion
        #endregion
    }
}
