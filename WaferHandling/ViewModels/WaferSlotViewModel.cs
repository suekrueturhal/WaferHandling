using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaferHandling.Models;

namespace WaferHandling.ViewModels
{
    internal class WaferSlotViewModel
    {
        private readonly WaferSlot _waferSlot;

        public WaferSlotViewModel(bool isOccupied)
        {
            _waferSlot = new WaferSlot
            {
                IsOccupied = isOccupied,
            };
        }

        public bool IsOccupied => _waferSlot.IsOccupied;
        public void SetOccupied(bool isOccupied) { _waferSlot.IsOccupied = isOccupied; }
    }
}
