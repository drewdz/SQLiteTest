using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SqliteTest.Core.Models
{
    public class Grouping<TKey, TItem> : ObservableCollection<TItem>
    {
        #region Constructors

        public Grouping(TKey key, IEnumerable<TItem> items)
        {
            Key = key;
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        #endregion Constructors

        #region Properties

        public TKey Key { get; set; }

        #endregion Properties
    }
}
