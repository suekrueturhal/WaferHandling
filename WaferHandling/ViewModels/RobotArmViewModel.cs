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

        public RobotArmViewModel(bool isHandlingWafer)
        {
            _robotArm = new RobotArm
            {
                IsHandlingWafer = isHandlingWafer,
            };
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

        public void SetHandlingWafer(bool isHandlingWafer)
        {
            IsHandlingWafer = isHandlingWafer;
        }
    }
}