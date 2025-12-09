using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaferHandling.Models;

namespace WaferHandling.ViewModels
{
    internal class RobotArmViewModel : ViewModelBase
    {
        private readonly RobotArm _robotArm;

        public RobotArmViewModel()
        {
            _robotArm = new RobotArm();
        }

        public bool IsHandlingWafer
        {
            get => _robotArm.IsHandlingWafer;
            set
            {
                if (_robotArm.IsHandlingWafer != value)
                {
                    _robotArm.IsHandlingWafer = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsRunning
        {
            get => _robotArm.IsRunning;
            set
            {
                if (_robotArm.IsRunning != value)
                {
                    _robotArm.IsRunning = value;
                    OnPropertyChanged();
                }
            }
        }

        public double RotationAngle
        {
            get => _robotArm.RotationAngle;
            set
            {
                if (_robotArm.RotationAngle != value)
                {
                    _robotArm.RotationAngle = value;
                    OnPropertyChanged();
                }
            }
        }

        // Missing async Functions to actually animate over time
        public void RotateLeft()
        {
            RotationAngle = NormalizeAngle(RotationAngle - 180);
        }

        public void RotateRight()
        {
            RotationAngle = NormalizeAngle(RotationAngle + 180);
        }

        private double NormalizeAngle(double angle)
        {
            angle %= 360;
            return angle < 0 ? angle + 360 : angle;
        }
    }
}