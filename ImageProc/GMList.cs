using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velociraptor
{
    class GMList
    {
        private List<GrouperMgr>grouper_list = new List<GrouperMgr>();
        private int _selected_grouper_idx = -1;
        public int FindMostSuitable()
        {
            if (grouper_list.Count <= 0) return Constants.E_NOLINEFOUND;
            var query = grouper_list
                .Select((x, index) => new { x.Line_num_diff, x.Pos_diff_avg, index })
                .OrderBy(o => Math.Abs(o.Line_num_diff))
                .ThenBy(n => n.Pos_diff_avg)
                .Where (w => w.Line_num_diff<Constants.E_ERROR);
            //如果目前所有line_num_diff都是error值，則回傳最近這次的line_num_diff
            if (query.Count() == 0)
            {
                _selected_grouper_idx = grouper_list.Count - 1;
                return grouper_list[grouper_list.Count - 1].Line_num_diff;
            }
            //紀錄目前最符合的grouperMgr
            int idx = query.ElementAt(0).index;
            _selected_grouper_idx = idx;
            return grouper_list[idx].Line_num_diff; ;
        }
        public void Add(GrouperMgr g)
        {
            grouper_list.Add(g);
        }
        public GrouperMgr GetLastGrouper()
        {
            return grouper_list[grouper_list.Count - 1];
        }
        public int GetRectSide(ref MyLine line1, ref MyLine line2)
        {
            if (_selected_grouper_idx == -1) return 0;
            List<MyLine> lines = grouper_list[_selected_grouper_idx].GetFilteredList();
            if (lines.Count == 0) return 0;
            else if (lines.Count == 1)
            {
                line1 = lines[0];
                line2 = lines[0];
                return 1;
            } 
            else
            {
                grouper_list[_selected_grouper_idx].GetBestLines(ref line1, ref line2);
                return 2;
            }
        }
        public List<MyLine> GetFilteredList()
        {
            if (grouper_list.Count == 0) return new List<MyLine>();
            return grouper_list[_selected_grouper_idx].GetFilteredList();
        }
    }
}
