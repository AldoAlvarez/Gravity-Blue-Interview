using GravityBlue.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue
{
    public class PlayerStorage : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            if (instance != null) Destroy(this);
            else instance = this;

            storage = new Storage();
        }
        #endregion

        #region VARIABLES
        public static PlayerStorage Instance => instance;
        private static PlayerStorage instance;

        public Storage storage { get; private set; }
        #endregion

        #region PUBLIC METHODS
        public void StorageItem(GameItem item)
        {
            storage.AddItem(item,1);
        }
        public GameItemData RetrieveItem(uint id) {
            return storage.RetrieveItem(id);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}