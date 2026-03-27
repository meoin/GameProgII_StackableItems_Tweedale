using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_StackableItems_Tweedale
{
    internal class Program
    {
        private static Inventory _inventory;
        private static ConsoleKey[] _validInputs = 
        { 
            ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, 
            ConsoleKey.Q, ConsoleKey.W, ConsoleKey.E, ConsoleKey.R,
            ConsoleKey.X, ConsoleKey.Escape 
        };

        static void Main(string[] args)
        {
            _inventory = new Inventory(4);

            _inventory.AddItem(new WizardHat());
            _inventory.AddItem(new Coin());
            _inventory.AddItem(new Coin());

            bool looping = true;

            while (looping) 
            {
                DisplayInventory();
                Console.WriteLine();
                Console.WriteLine("1 - Add Coin | 2 - Add Wizard Hat | 3 - Add Banana");
                Console.WriteLine("Q/W/E/R - Remove item in slots 1/2/3/4 respectively");
                Console.WriteLine("X/Escape - Exit Inventory");
                looping = ReadInput();
            }
            
            
        }

        static bool ReadInput() 
        {
            ConsoleKey input;

            while (true) 
            {
                input = Console.ReadKey(true).Key;

                if (_validInputs.Contains(input)) break;
            }

            if (input == ConsoleKey.X || input == ConsoleKey.Escape) return false;

            switch (input) 
            {
                case ConsoleKey.D1:
                    _inventory.AddItem(new Coin());
                    break;
                case ConsoleKey.D2:
                    _inventory.AddItem(new WizardHat());
                    break;
                case ConsoleKey.D3:
                    _inventory.AddItem(new Banana());
                    break;
                case ConsoleKey.Q:
                    PromptRemoveItem(0);
                    break;
                case ConsoleKey.W:
                    PromptRemoveItem(1);
                    break;
                case ConsoleKey.E:
                    PromptRemoveItem(2);
                    break;
                case ConsoleKey.R:
                    PromptRemoveItem(3);
                    break;
                default:
                    break;
            }

            return true;
        }

        static void PromptRemoveItem(int index) 
        {
            if (_inventory.Items[index].Item == null) return;
            if (!_inventory.Items[index].Item.IsStackable)
            {
                _inventory.RemoveItem(index);
                return;
            }

            string itemDescription = _inventory.Items[index].Item.Description;

            Console.WriteLine();
            Console.WriteLine($"How many {itemDescription} do you want to remove?");

            ConsoleKeyInfo input;

            while (true)
            {
                input = Console.ReadKey(true);

                if (Char.IsDigit(input.KeyChar)) break;
            }

            int amountToRemove = int.Parse(input.KeyChar.ToString());

            
            int amountRemoved = _inventory.RemoveItem(index, amountToRemove);

            Console.WriteLine($"Removed {amountRemoved} {itemDescription}.");
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey(true);
        }

        static void DisplayInventory() 
        {
            Console.Clear();
            Console.WriteLine("Inventory:");

            int index = 1;

            foreach (InventorySlot slot in _inventory.Items)
            {
                Console.Write(index + ". ");
                index++;

                if (slot.Item == null)
                {
                    Console.WriteLine("[Empty]");
                }
                else
                {
                    Console.Write(slot.Item.Description);

                    if (slot.Item.IsStackable) Console.Write(" x" + slot.Amount);

                    Console.WriteLine();
                }
            }
        }
    }
}
