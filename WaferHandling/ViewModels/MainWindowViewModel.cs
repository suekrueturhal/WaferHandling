using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
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
        public ICommand PauseCommand { get; }

        private bool _isRunning;

        public MainWindowViewModel()
        {
            FullLoadPort = new LoadPortViewModel(slotCount: 25, startsFull: true);
            EmptyLoadPort = new LoadPortViewModel(slotCount: 25, startsFull: false);

            LoadPorts = new ObservableCollection<LoadPortViewModel>
            {
                FullLoadPort,
                EmptyLoadPort,
            };

            RobotArm = new RobotArmViewModel();

            StartCommand = new RelayCommand(StartCycle);
            PauseCommand = new RelayCommand(PauseCycle);
        }

        private void StartCycle()
        {
            if (!_isRunning)
                _isRunning = true;
            else
                return;

            Console.WriteLine("TEST");
            RobotArm.IsHandlingWafer = true;

            FullLoadPort.PopWafer();
        }

        private void PauseCycle()
        {
            if (_isRunning)
                _isRunning = false;
            else
                return;

            Console.WriteLine("TEST");
            RobotArm.IsHandlingWafer = false;

            EmptyLoadPort.PushWafer();
        }
    }
}
