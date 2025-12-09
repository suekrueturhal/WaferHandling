using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferHandling.Models
{
    internal class RobotArm
    {
        public bool IsHandlingWafer { get; set; }
        public bool IsRunning { get; set; }
        public double RotationAngle { get; set; }
    }
}
