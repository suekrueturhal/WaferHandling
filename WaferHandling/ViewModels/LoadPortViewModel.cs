using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaferHandling.Models;

namespace WaferHandling.ViewModels
{
    internal class LoadPortViewModel : ViewModelBase
    {
        private readonly LoadPort _loadPort;

        public LoadPortViewModel(int slotCount, bool startsFull)
        {
            _loadPort = new LoadPort
            {
                SlotCount = slotCount,
                StartsFull = startsFull,
            };

            WaferSlots = new ObservableCollection<WaferSlotViewModel>();
            for (int i = 0; i < _loadPort.SlotCount; i++)
            {
                var slot = new WaferSlotViewModel(startsFull);
                WaferSlots.Add(slot);
            }
        }

        public void PopWafer()
        {
            foreach (var slot in WaferSlots.Reverse())
            {
                if (!slot.IsOccupied)
                    continue;

                slot.IsOccupied = false;
                break;
            }
        }

        public void PushWafer()
        {
            foreach (var slot in WaferSlots.Reverse())
            {
                if (slot.IsOccupied)
                    continue;

                slot.IsOccupied = true;
                break;
            }
        }

        public int SlotCount => _loadPort.SlotCount;
        public ObservableCollection<WaferSlotViewModel> WaferSlots { get; }
    }
}
