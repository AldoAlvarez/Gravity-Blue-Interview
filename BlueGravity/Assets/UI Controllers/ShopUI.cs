using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        #endregion

        #region PUBLIC METHODS
        public void Show()
        {
            menu.SetActive(true);
        }
        public void Hide() {
            menu.SetActive(false);
        }
        public void SetGreeting(string message) {
            greetingDisplay.text = message;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}