using GravityBlue.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue
{
    [System.Serializable]
    public class Storage
    {
        #region CONSTRUCTORS
        public Storage()
        {
            
        }
        #endregion

        #region VARIABLES
        public uint MaxCapacity = 10;
        private Dictionary<uint, StorageItem> containedItems = new Dictionary<uint, StorageItem>();
        #endregion

        #region PUBLIC METHODS
        public void AddItem(GameItem item, int count)
        {
            AddItem(GameItemsArchive.Instance.GetItem(item.ID), count);
        }
        public void AddItem(GameItemData item, int count) {
            var id = item.ID;
            if (containedItems.ContainsKey(id))
            {
                var it = containedItems[id];
                it.Add(count);
                containedItems[id] = it;
                return;
            }

            if (containedItems.Count >= MaxCapacity) return;

            var itemConfig = GameItemsArchive.Instance.GetItem(item.ID);
            containedItems.Add(id, new StorageItem(itemConfig,count));
        }
        public GameItemData RetrieveItems(uint id, int count=1) {
            if (!containedItems.ContainsKey(id)) return new GameItemData() { ID = 0, Value = 0, MaxCapacity = 1 };

            var it = containedItems[id];

            if (it.count < count) return new GameItemData() { ID = 0, Value = 0, MaxCapacity = 1 }; ;

            it.TakeOut(count);
            containedItems[id] = it;

            if (containedItems[id].count <= 0) containedItems.Remove(id);

            return it.item;
        }
        public void Clear() { containedItems.Clear(); }
        public List<uint> GetStoredItems() {

            return new List<uint>(containedItems.Keys);
        }
        public int CountItem(uint id) {
            if (!containedItems.ContainsKey(id)) return 0;
            return containedItems[id].count;
        }
        #endregion
    }
}