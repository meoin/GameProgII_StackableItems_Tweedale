using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_StackableItems_Tweedale
{
    internal abstract class Item
    {
        public string Description;
        public bool IsStackable;
        public int Value;

        public Item(string description, bool stackable, int value)
        {
            Description = description;
            IsStackable = stackable;
            Value = value;
        }
    }
}
