using GravityBlue.Data;
using GravityBlue.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue
{
    public class Shop : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            UpdateShop();
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        public Storage shop;
        [SerializeField] private StorageItem[] shopItems;
        private float sellValue;
        private float buyValue;
        #endregion

        #region PUBLIC METHODS
        public void Open(float buyPrice, float sellPrice)
        {
            UpdateShop();
            ShopUI.Instance.SetShop(this, buyPrice, sellPrice);

            sellValue = sellPrice;
            buyValue = buyPrice;
        }
        public void BuyItem(GameItemData item, int price) {
            uint requiredItem = item.TradeItem;

            var tradeItem = PlayerStorage.Instance.RetrieveItem(requiredItem, price);
            if (tradeItem.ID == 0) return;

            PlayerStorage.Instance.StorageItem(item);
            shop.RetrieveItems(item.ID);

            UpdateShop();
            ShopUI.Instance.SetShop(this, buyValue, sellValue);

        }
        #endregion

        #region PRIVATE METHODS
        private void UpdateShop()
        {
            shop = new Storage();
            foreach (var item in shopItems)
            {
                shop.AddItem(item.item, item.count);
            }
        }
        #endregion
    }
}