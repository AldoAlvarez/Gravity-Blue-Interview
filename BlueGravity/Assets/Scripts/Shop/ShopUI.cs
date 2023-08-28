using GravityBlue.Data;
using GravityBlue.Instantiation;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GravityBlue.UI
{
    public class ShopUI : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            if (instance != null) Destroy(this);
            else instance = this;
        }
        private void Start()
        {
            Hide();
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        public static ShopUI Instance =>instance;
        private static ShopUI instance;
        [SerializeField]
        private GameObject menu;
        [SerializeField] private TMP_Text greetingDisplay;
        [SerializeField] private Image requieredMaterial;
        [SerializeField] private TMP_Text price_sell_label;

        [SerializeField] private StorageDisplay shopDisplay;
        private Shop currentShop;
        private GameItemData currentItem;
        #endregion

        #region PUBLIC METHODS
        public void SetShop(Shop shop, float buyValue, float sellValue) {
            shopDisplay.DisplayStorage();
            shopDisplay.UpdateStorageDisplay(shop.shop);
            currentShop = shop;

            var items = shop.shop.GetStoredItems();
            for (int i = 0; i < shop.shop.GetStoredItems().Count; i++)
            {
                var display = shopDisplay.ScrollContent.GetChild(i);
                var poolable = display.GetComponent<PoolableObject>();
                poolable?.Spawn();
                var itemButton = display.GetComponent<Button>();
                int index = i;
                itemButton.onClick.AddListener(() => {
                    var item = GameItemsArchive.Instance.GetItem(items[index]);
                    UpdateItemDataDisplay(item, buyValue, sellValue);
                    currentItem = item;
                });
            }
        }
        public void UpdateItemDataDisplay(GameItemData item, float buyValue, float sellValue) {
            var requiered = GameItemsArchive.Instance.GetItem(item.TradeItem);
            requieredMaterial.sprite = requiered.Visual;
            var value = (int)(item.Value*sellValue);
            price_sell_label.text = value.ToString("D2");
        }
        public void Show()
        {
            menu.SetActive(true);
        }
        public void Hide() {
            Clear();
            menu.SetActive(false);
        }
        public void SetGreeting(string message) {
            greetingDisplay.text = message;
        }
        public void BuyCurrentItem() {
            if (currentItem == null) return;
            currentShop.BuyItem(currentItem, int.Parse(price_sell_label.text));
        }
        #endregion

        #region PRIVATE METHODS
        private void Clear()
        {
            price_sell_label.text = "";
            requieredMaterial.sprite = null;
            currentItem = null;
            for (int i = 0; i < shopDisplay.ScrollContent.childCount; i++)
            {
                var poolable = shopDisplay.ScrollContent.GetChild(i).GetComponent<PoolableObject>();
                poolable?.Despawn();
            }
        }
        #endregion
    }
}