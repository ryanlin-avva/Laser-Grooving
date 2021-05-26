using System;

namespace Avva.MotionFramework
{
    public interface IAvvaMotion : IDisposable
    {
        log4net.ILog log { set; }
        void Init(AxisData[] axes, AxisData[] home);
        void MotorOn();
        void MotorOff();
        void MoveTo(int axis, double distance,double velocity, bool isRelative = true);
        void MoveTo(int[] axis, double[] distance,double[] velocity, bool isRelative = true);
        void AsyncMoveTo(int axis, double distance,double velocity, bool isRelative = true);
        void AsyncMoveTo(int[] axis, double[] distance,double[] velocity, bool isRelative = true);
        void StopMove();
        double GetPos(int axis);
        void JogStart(int axis, bool isPositive = true);
        void JogStop();
        void ClearAlarm();
        void GoHome();
        void GoHome(int[] axis);
    }
}
