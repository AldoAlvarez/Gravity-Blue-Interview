using GravityBlue.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue
{
    public class GameItemsArchive : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            if (instance != null) Destroy(this);
            else instance = this;
        }
        private void OnEnable()
        {
            Items = new Dictionary<uint, GameItemData>();
            foreach (var item in allItems) {
                if (item != null) {
                    Items.Add(item.ID, item);
                }
            }
        }
        #endregion

        #region VARIABLES
        public static GameItemsArchive Instance => instance;
        private static GameItemsArchive instance;

        //for the time being it will xist as an array. It may also read them from the folders file, but its better if it is separated into different dictionaries according to a custom categorization based on its id
        [SerializeField] private GameItemData[] allItems;
        private Dictionary<uint, GameItemData> Items;
        #endregion

        #region PUBLIC METHODS
        public GameItemData GetItem(uint id)
        {
            if (!Items.ContainsKey(id)) return new GameItemData() { Value=0, ID=0, MaxCapacity=1 };
            return Items[id];
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}