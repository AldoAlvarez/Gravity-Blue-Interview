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
            shop = new Storage();
            foreach (var item in shopItems) {
                shop.AddItem(item.item, item.count);
            }
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        private Storage shop;
        [SerializeField] private StorageItem[] shopItems;
        //[SerializeField] private StorageDisplay shopDisplay;
        #endregion

        #region PUBLIC METHODS
        public void Open(float buyPrice, float sellPrice)
        {
            shop = new Storage();
            foreach (var item in shopItems)
            {
                shop.AddItem(item.item, item.count);
            }
            ShopUI.Instance.SetShop(shop, buyPrice, sellPrice);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}