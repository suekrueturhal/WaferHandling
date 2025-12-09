using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WaferHandling.Commands;
using WaferHandling.Models;

namespace WaferHandling.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<LoadPortViewModel> LoadPorts { get; }

        public LoadPortViewModel FullLoadPort { get; }
        public LoadPortViewModel EmptyLoadPort { get; }
        public RobotArmViewModel RobotArm { get; }

        public ICommand StartCommand {  get; }

        public MainWindowViewModel()
        {
            FullLoadPort = new LoadPortViewModel(slotCount: 25, startsFull: true);
            EmptyLoadPort = new LoadPortViewModel(slotCount: 25, startsFull: false);

            LoadPorts = new ObservableCollection<LoadPortViewModel>
            {
                FullLoadPort,
                EmptyLoadPort,
            };

            var robotArmModel = new RobotArm();
            RobotArm = new RobotArmViewModel(isHandlingWafer: false);

            StartCommand = new RelayCommand(OnStart);
        }

        private void OnStart()
        {
            Console.WriteLine("TEST");
            RobotArm.SetHandlingWafer(!RobotArm.IsHandlingWafer);

            FullLoadPort.PopWafer();
        }
    }
}
