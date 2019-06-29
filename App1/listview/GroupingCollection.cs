using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.listview
{
    public class GroupingCollection<K, T> : ObservableCollection<T>
    {
        public K Name { get; private set; }
        public GroupingCollection(K name, IEnumerable<T> items)
        {
            Name = name;
            foreach (T item in items)
                Items.Add(item);
        }
        
    }
}
