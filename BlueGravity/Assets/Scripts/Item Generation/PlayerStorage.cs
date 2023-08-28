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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P)) { storage.RetrieveItem(1001); }
            if (Input.GetKeyDown(KeyCode.O)) { storage.RetrieveItem(1002); }
            if (Input.GetKeyDown(KeyCode.Y)) { storage.Clear(); }
        }
        #endregion

        #region VARIABLES
        public static PlayerStorage Instance => instance;
        private static PlayerStorage instance;

        private Storage storage;
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