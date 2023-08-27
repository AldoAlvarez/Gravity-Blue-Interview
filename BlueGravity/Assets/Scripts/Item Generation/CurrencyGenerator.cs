using GravityBlue.Data;
using GravityBlue.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue
{
    public class CurrencyGenerator : MonoBehaviour, IInteractible
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
        [SerializeField] private Transform SpawnPoint;
        [SerializeField] private GameItemData itemConfig;
        #endregion

        #region PUBLIC METHODS
        public void Interact()
        {
            if (!CanSpawn()) return;
            GameItemsController.Instance.SpawnItem(itemConfig, SpawnPoint);
        }
        #endregion

        #region PRIVATE METHODS
        private bool CanSpawn()
        {
            //Gizmos.DrawSphere(SpawnPoint.position, 0.3f);
            return !Physics2D.OverlapCircle(SpawnPoint.position, 0.3f);
        }
        #endregion
    }
}