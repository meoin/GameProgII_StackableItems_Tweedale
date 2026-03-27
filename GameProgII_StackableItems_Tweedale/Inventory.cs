using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_StackableItems_Tweedale
{
    internal class Inventory
    {
        private int _size;

        public InventorySlot[] Items;

        public Inventory(int size) 
        {
            _size = size;

            Items = new InventorySlot[size];

            for (int i = 0; i < size; i++)
            {
                Items[i] = new InventorySlot();
            }
        }

        public bool AddItem(Item item) 
        {
            if (item.IsStackable) 
            {
                foreach (InventorySlot slot in Items) 
                {
                    if (slot.Item == null) continue;
                    if (slot.Item.Description != item.Description) continue;

                    slot.Amount++;
                    return true;
                }
            }

            foreach (InventorySlot slot in Items) 
            {
                if (slot.Item != null) continue;

                slot.Item = item;
                slot.Amount = 1;
                return true;
            }

            return false;
        }

        public void RemoveItem(int index) 
        {
            if (Items[index].Item == null) return;

            if (Items[index].Amount > 1) Items[index].Amount--;
            else
            {
                Items[index].Item = null;
                Items[index].Amount = 0;
            }
        }
    }
}
