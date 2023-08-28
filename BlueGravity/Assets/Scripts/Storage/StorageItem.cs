using GravityBlue.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue
{
    [System.Serializable]
    public struct StorageItem
    {
        #region CONSTRUCTORS
        public StorageItem(GameItemData config, int amount)
        {
            item = config;
            count = amount;
        }
        #endregion

        #region VARIABLES
        public int count;
        public GameItemData item;
        #endregion

        #region PUBLIC METHODS
        public void Add(int amount) {
            count = Mathf.Min(item.MaxCapacity, count + amount);
            count = Mathf.Max(0, count);
        }
        public void TakeOut(int amount) {
            Add(-amount);
        }
        public void Clear() { count = 0; }
        #endregion
    }
}