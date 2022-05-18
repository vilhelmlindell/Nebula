using System;
using System.Collections.Generic;
using System.Text;

namespace Nebula.Engine
{
    public class ItemStack
    {
        private int count;

        public ItemStack(Item item, int count = 0)
        {
            Item = item;
            Count = count;
        }

        public Item Item { get; set; }
        public int Count 
        { 
            get { return count; }
            set
            {
                count = value;
                OnCountChanged?.Invoke(count);
            }
        }

        public Action<int> OnCountChanged;
    }
}
