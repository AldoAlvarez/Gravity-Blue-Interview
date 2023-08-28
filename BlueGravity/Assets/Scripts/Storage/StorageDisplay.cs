using GravityBlue.Instantiation;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GravityBlue
{
    public class StorageDisplay : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private GameObject StorageMenu;
        [SerializeField] private RectTransform ScrollContent;
        [SerializeField] private int ItemsPerRow=4;
        [SerializeField] private Vector2 ItemsSeparation;
        [SerializeField] private ObjectPool ItemDisplays;
        [SerializeField] private TMP_Text ItemDescription;
        #endregion

        #region PUBLIC METHODS
        public void DisplayStorage() {
            StorageMenu.SetActive(true);
            PlayerInputController.Instance.DisableGeneralControls();
        }
        public void HideStorage() {
            StorageMenu.SetActive(false);
            PlayerInputController.Instance.EnableGeneralControls();
        }
        public void UpdateStorageDisplay(Storage storage)
        {
            DespawnAllItemDisplays();

            var items = storage.GetStoredItems();
            ResizeContentBox(items.Count);
            SpawnItemsDisplays(items.Count);
            InitializeItemsDisplays(storage);
            ItemDescription.text = "";
        }
        #endregion

        #region PRIVATE METHODS
        private void SpawnItemsDisplays(int totalItems) {

            var initialOffset_X = (ScrollContent.sizeDelta.x / 2f) - (ItemsSeparation.x / 2f);
            var initialOffset_Y = (ScrollContent.sizeDelta.y / 2f) - (ItemsSeparation.y / 2f);
            for (int i = 0; i < totalItems; i++)
            {
                var x_offset = ((i % ItemsPerRow)*ItemsSeparation.x)-initialOffset_X;
                var y_offset = ((i / ItemsPerRow) * -ItemsSeparation.y)+initialOffset_Y;

                var display = ItemDisplays.GetNewObject().GetComponent<RectTransform>();
                display.parent = ScrollContent;
                display.anchoredPosition = new Vector2(x_offset, y_offset);
                display.GetComponent<PoolableObject>().Spawn();
            }
        }
        private void InitializeItemsDisplays(Storage storage) {
            var items = storage.GetStoredItems();
            for (int i = 0; i < items.Count; i++)
            {
                int index = i;
                var display = ScrollContent.GetChild(i);
                display.GetComponent<StorageItem_UI>().Initialze(items[index], storage.CountItem(items[index]));
                var button = display.GetComponent<Button>();
                button.onClick.RemoveListener(() =>  DescibeItem(items[index]));
                button.onClick.AddListener(() =>  DescibeItem(items[index]));
            }
        }
        private void DespawnAllItemDisplays() {
            for (int i = 0; i < ScrollContent.childCount; i++)
            {
                var child = ScrollContent.GetChild(i);
                var poolable = child.GetComponent<PoolableObject>();
                poolable.Despawn();
            }
        }
        private void ResizeContentBox(int totalItems)
        {
            var rows = Mathf.CeilToInt((float)totalItems / (float)ItemsPerRow);
            var height = rows * ItemsSeparation.y;
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, height);
        }
        private void DescibeItem(uint id) {
            ItemDescription.text = GameItemsArchive.Instance.GetItem(id).Description;
        }
        #endregion
    }
}