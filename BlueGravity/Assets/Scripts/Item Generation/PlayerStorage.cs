using GravityBlue.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] private RectTransform storageDisplayContainer;
        #endregion

        #region PUBLIC METHODS
        public void StorageItem(GameItem item)
        {
            storage.AddItem(item,1);
        }
        public void StorageItem(GameItemData item) {
            storage.AddItem(item, 1);
        }
        public GameItemData RetrieveItem(uint id, int count=1) {
            return storage.RetrieveItems(id, count);
        }
        public void Open() {
            var items = storage.GetStoredItems();
            for (int i = 0; i < storageDisplayContainer.childCount; i++)
            {
                var button = storageDisplayContainer.GetChild(i).GetComponent<Button>();
                var index = i;
                button.onClick.AddListener(() => {
                    var item = GameItemsArchive.Instance.GetItem(items[index]);
                    if (item.ID > 2000) {
                        PlayerAvatar.Instance.SetOutfit(item.Visual);
                    }
                });
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}