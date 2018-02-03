using System.Collections.Generic;

namespace TddBook.FantasyWorld
{
    public class Character
    {
        public List<Item> Items { get; }
        public int? DeathYear { get; set; }

        public Character()
        {
            Items = new List<Item>();
        }

        public bool IsAlive()
        {
            return !DeathYear.HasValue;
        }

        public void Death(int inYear)
        {
            DeathYear = inYear;
        }

        public void PickUp(string itemName)
        {
            Items.Add(new Item(itemName));
        }

        public void Drop(string itemName)
        {
            Items.RemoveAll(x => x.Name == itemName);
        }
    }
}
