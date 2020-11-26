using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MagicAddOn
{
    public class cIhmSelectingFilters
    {
        public delegate void RemoveSelectingFiltersControlsHandler(Control.ControlCollection Container, cSelectingFilters selectingFilters);
        public delegate void AddSelectingFiltersControlsHandler(Control.ControlCollection Container, Point StartingDraw, cSelectingFilters selectingFilters);


        #region RemoveSelectingFiltersControls
        public static void RemoveSelectingFiltersControls(Control.ControlCollection Container, cSelectingFilters selectingFilters)
        {
            if (selectingFilters != null)
            {
                //remove old
                for (int idx = 0; idx < selectingFilters.List.Count; idx++)
                {
                    sSelectingFilter selectingFilter = selectingFilters.List[idx];
                    if (selectingFilter.CheckBox != null)
                    {
                        Container.Remove(selectingFilter.CheckBox);
                    }
                }
            }
        }
        #endregion
        #region AddSelectingFiltersControls
        public static void AddSelectingFiltersControls(Control.ControlCollection Container, Point StartingDraw, cSelectingFilters selectingFilters)
        {
            if (selectingFilters != null)
            {
                //remove old
                for (int idx = 0; idx < selectingFilters.List.Count; idx++)
                {
                    sSelectingFilter selectingFilter = selectingFilters.List[idx];
                    if (selectingFilter.CheckBox != null)
                    {
                        Container.Remove(selectingFilter.CheckBox);
                    }
                }
                //display new
                for (int idx = 0; idx < selectingFilters.List.Count; idx++)
                {
                    sSelectingFilter selectingFilter = selectingFilters.List[idx];
                    selectingFilter.CheckBox.Location = new Point(StartingDraw.X, StartingDraw.Y + 10 + ((idx + 0) * 18));
                    Container.Add(selectingFilter.CheckBox);
                    selectingFilter.CheckBox.Text = selectingFilter.SodxCommand.ToString();
                }
            }
        }
        #endregion
    }
}
