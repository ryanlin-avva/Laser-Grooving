using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Velociraptor.AddOn
{
    public class sAcquisition
    {
        bool _newProgressValue = false;
        int _progressValue = 0;
        int _oldProgressValue = -1;
        int _numberOfSamples = 0;
        int _numberOfAcquisition = 0;
        int _dieHeight = 0;
        int _dieWidth = 0;
        int _startMeasureXPos = 0;
        int _startMeasureYPos = 0;


        #region Constructor
        public sAcquisition()
        {

            EnabledTrigger = false;
            WaitTrigger = EnabledTrigger;
            NumberOfSamples = 0;
            Recording = false;
            NumberOfAcquisition = 0;
            ValidSample = false;
            _newProgressValue = EnabledTrigger == false;
            DoNextMeasure = true;


        }
        #endregion
        #region EnabledTrigger
        public bool EnabledTrigger
        {
            get;
            set;
        }
        #endregion
        #region NumberOfAcquisition
        public int NumberOfAcquisition
        {
            get { return (_numberOfAcquisition); }
            set
            {
                _numberOfAcquisition = value;
                if (NumberOfSamples != 0)
                {
                    _progressValue = (int)Math.Ceiling((100.0 / NumberOfSamples) * value);
                }
                else
                {
                    _progressValue = 0;
                }
                if (_progressValue != _oldProgressValue)
                {
                    _oldProgressValue = _progressValue;
                    _newProgressValue = true;
                }
            }
        }
        #endregion
        #region NumberOfSamples
        public int NumberOfSamples
        {
            get { return (_numberOfSamples); }
            set
            {
                _numberOfSamples = value;
            }
        }
        #endregion
        #region DieHeight
        public int DieHeight
        {
            get { return (_dieHeight); }
            set
            {
                _dieHeight = value;
            }
        }
        #endregion
        #region DieWidth
        public int DieWidth
        {
            get { return (_dieWidth); }
            set
            {
                _dieWidth = value;
            }
        }
        #endregion
        #region StartMeasureXPos
        public int StartMeasureXPos
        {
            get { return (_startMeasureXPos); }
            set
            {
                _startMeasureXPos = value;
            }
        }
        #endregion
        #region StartMeasureYPos
        public int StartMeasureYPos
        {
            get { return (_startMeasureYPos); }
            set
            {
                _startMeasureYPos = value;
            }
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
        #region Recording
        [XmlIgnore]
        public bool DoNextMeasure
        {
            get;
            set;
        }
        #endregion
        #region ValidSample
        [XmlIgnore]
        public bool ValidSample
        {
            get;
            set;
        }
        #endregion
        #region WaitTrigger
        [XmlIgnore]
        public bool WaitTrigger
        {
            get;
            set;
        }
        #endregion
        #region NewProgressValue
        [XmlIgnore]
        public bool NewProgressValue
        {
            get
            {
                bool result = _newProgressValue;
                _newProgressValue = false;
                return (result);
            }
        }
        #endregion
        #region ProgressValue
        [XmlIgnore]
        public int ProgressValue
        {
            get
            {
                return (_progressValue);
            }
        }
        #endregion
    }
}
