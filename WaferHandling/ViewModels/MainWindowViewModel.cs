using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferHandling.ViewModels
{
    internal class MainWindowViewModel
    {
        public ObservableCollection<LoadPortViewModel> LoadPorts { get; }

        public MainWindowViewModel()
        {
            LoadPorts = new ObservableCollection<LoadPortViewModel>
            {
                new LoadPortViewModel(slotCount: 25, startsFull: true),
                new LoadPortViewModel(slotCount: 25, startsFull: false),
            };
        }
    }
}
