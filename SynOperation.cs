using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velociraptor
{
    class SynOperation
    {
        public void FocusClimbing()
        {
            int zpos = Get_Z_MotorPos();
            List<int> zpos_List = new List<int>();
            movePositionAbsolute(Get_X_MotorPos(), Get_Y_MotorPos(), -48000);
            for (int i = 0; i < 1500; i++)
            {
                movePositionRelative(2, -1, 1);
                zpos = Get_Z_MotorPos();
                if (dataIntensityAverage != 0)
                {
                    zpos = Get_Z_MotorPos();
                    zpos_List.Add(zpos);
                }
            }
            movePositionAbsolute(Get_X_MotorPos(), Get_Y_MotorPos(), zpos_List[zpos_List.Count / 2]);
        }
    }
}
