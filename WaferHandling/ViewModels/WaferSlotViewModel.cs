using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaferHandling.Models;

namespace WaferHandling.ViewModels
{
    internal class WaferSlotViewModel : ViewModelBase
    {
        private readonly WaferSlot _waferSlot;

        public WaferSlotViewModel(bool isOccupied)
        {
            _waferSlot = new WaferSlot
            {
                IsOccupied = isOccupied,
            };
        }

        public bool IsOccupied
        {
            get => _waferSlot.IsOccupied;
            set
            {
                if (_waferSlot.IsOccupied != value)
                {
                    _waferSlot.IsOccupied = value;
                    OnPropertyChanged(); 
                }
            }
        }
    }
}
