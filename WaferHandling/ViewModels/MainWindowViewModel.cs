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

        // The Cycle Functions should probably be in a separate Class
        private async void StartCycle()
        {
            if (!_isRunning)
                _isRunning = true;
            else
                return;

            while (_isRunning)
            {
                await AnimateWaferHandling();
            }
        }

        // Pause does not truly cancel an operation because the "Animation" executes fully
        // Would need an interrupt-like system (no time left though)
        private void PauseCycle()
        {
            if (_isRunning)
                _isRunning = false;
            else
                return;
        }

        private async Task AnimateWaferHandling()
        {
            FullLoadPort.PopWafer();
            RobotArm.IsHandlingWafer = true;
            await Task.Delay(500);
            RobotArm.RotateRight();
            await Task.Delay(500);
            EmptyLoadPort.PushWafer();
            RobotArm.IsHandlingWafer = false;
            await Task.Delay(500);
            RobotArm.RotateLeft();
            await Task.Delay(500);
        }
    }
}
