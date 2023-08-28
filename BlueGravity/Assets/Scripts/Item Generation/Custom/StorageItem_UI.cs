using GravityBlue.Instantiation;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GravityBlue
{
    public class StorageItem_UI : PoolableObject
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void OnEnable()
        {
            OnSpawn += () => ShowObject();
            OnDespawen += () => HideObject();
        }
        private void OnDisable()
        {
            OnSpawn -= () => ShowObject();
            OnDespawen -= () => HideObject();
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Image ItemVisual;
        [SerializeField] private TMP_Text ItemCount;
        #endregion

        #region PUBLIC METHODS
        public void Initialze(uint id, int count)
        {
            var config = GameItemsArchive.Instance.GetItem(id);
            ItemVisual.sprite = config.Visual;
            ItemCount.text = count.ToString("D2");
        }
        #endregion

        #region PRIVATE METHODS
        private void HideObject() { gameObject.SetActive(false); }
        private void ShowObject() { gameObject.SetActive(true); }
        #endregion
    }
}