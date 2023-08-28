using GravityBlue.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GravityBlue.UI;

namespace GravityBlue.NPCs
{
    public class ShopVendor : MonoBehaviour, IInteractible
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField, TextArea]
        private string greetingMessage="Welcome to my shop! What are you interested in?";
        [SerializeField, Range(0, 2)] private float SellValue = 1.2f;
        [SerializeField, Range(0, 2)] private float BuyValue = 0.8f;
        [SerializeField] private Shop shop;
        #endregion

        #region PUBLIC METHODS
        public void Interact()
        {
            PlayerInputController.Instance.DisableGeneralControls();
            ShopUI.Instance.Show();
            ShopUI.Instance.SetGreeting(greetingMessage);
            shop.Open(BuyValue, SellValue);
            //Shop.Instance.SetSellBuyValues(SellValue, BuyValue);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}