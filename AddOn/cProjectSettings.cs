using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Velociraptor.AddOn
{
    /// <summary>
    /// Project parameters Class
    /// </summary>
    public class cProjectSettings : ICloneable
    {
        string _rootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        sProjectSettings _projectSettings = null;
        XmlSerializer _xmlSerializer = null;
        string _baseFileNameSettings = "?";

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="root_directory">répertoire ou se trouve le fichier du projet</param>
        public cProjectSettings()
        {
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
        /// <returns>retourne la classe clonée</returns>--
        public cProjectSettings Clone()
        {
            return (cProjectSettings)this.MemberwiseClone();
        }
        #endregion
        #region Clear
        /// <summary>
        /// Efface les informations courantes et initialise les valeurs par défaut.
        /// </summary>
        public void Clear()
        {
            Project = new sProjectSettings();
            FileNameSettings = "DefaultProject";
        }
        #endregion
        #region Project
        /// <summary>
        /// project settings
        /// </summary>
        [XmlElement(ElementName = "ProjectSettings", Type = typeof(sProjectSettings))]
        public sProjectSettings Project
        {
            get { return (_projectSettings); }
            set
            {
                _projectSettings = value;
            }
        }
        #endregion
        #region FileNameSettings
        /// <summary>
        /// project filename
        /// </summary>
        public string FileNameSettings
        {
            get { return (Path.Combine(_rootDirectory, _baseFileNameSettings + ".prc")); }
            set
            {
                _rootDirectory = Path.GetDirectoryName(value);
                _baseFileNameSettings = Path.GetFileNameWithoutExtension(value);
            }
        }
        #endregion
        #region BakFileNameSettings
        /// <summary>
        /// bak project filename
        /// </summary>
        public string BakFileNameSettings
        {
            get { return (Path.Combine(_rootDirectory, _baseFileNameSettings + ".bak")); }
        }
        #endregion
        #region Save
        /// <summary>sauvegarde du fichier (avec une sauvegarde du fichier bak au préalable).</summary>
        /// <returns>true en cas de succès, sinon false.</returns>
        public virtual bool Save()
        {
            try
            {
                bool _result = true;
                if (File.Exists(FileNameSettings))
                {
                    if (File.Exists(BakFileNameSettings))
                    {
                        File.Delete(BakFileNameSettings);
                    }
                    File.Move(FileNameSettings, BakFileNameSettings);
                }
                if (SaveSettings() == false)
                {
                    _result = false;
                }
                return _result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion
        #region SaveSettings
        /// <summary>sauvegarde du fichier Settings (avec une sauvegarde du fichier bak au préalable).</summary>
        /// <returns>true en cas de succès, sinon false.</returns>
        public virtual bool SaveSettings()
        {
            try
            {
                _xmlSerializer = new XmlSerializer(typeof(sProjectSettings), new Type[] { typeof(sProjectSettings) });
                using (StreamWriter wr = new StreamWriter(FileNameSettings, false, Encoding.Unicode))
                {
                    _xmlSerializer.Serialize(wr, Project);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion
        #region Load
        /// <summary>Chargement du fichier </summary>
        /// <returns>true en cas de succès, sinon false.</returns>
        public virtual bool Load()
        {
            try
            {
                if (!File.Exists(FileNameSettings))
                {
                    SaveSettings();
                    if (!File.Exists(FileNameSettings))
                    {
                        return (false);
                    }
                }
                Project.Clear();
                _xmlSerializer = new XmlSerializer(typeof(sProjectSettings), new Type[] { typeof(sProjectSettings) });
                using (StreamReader rd = new StreamReader(FileNameSettings, System.Text.Encoding.Unicode, true))
                {
                    Project = _xmlSerializer.Deserialize(rd) as sProjectSettings;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion
    }

}
