using GravityBlue.Data;
using GravityBlue.Instantiation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue
{
    public class GameItemsController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            if (instance != null) Destroy(this);
            else instance = this;
        }

        private void Update()
        {
        }
        #endregion

        #region VARIABLES
        public static GameItemsController Instance => instance;
        private static GameItemsController instance;

        [SerializeField] private Transform spawnPoint;
        [SerializeField] private ObjectPool itemsPool;
        #endregion

        #region PUBLIC METHODS
        public void SpawnItem(GameItemData config, Transform point) {
            var item = itemsPool.GetNewObject();
            item.transform.position = point.position;
            item.GetComponent<GameItem>().Initialize(config);
            item.Spawn();
        }
        public void SpawnItem(GameItemData config)
        {
            SpawnItem(config, spawnPoint);
        }
        public void DespawnAll()
        {
            var spawnedItems = FindObjectsOfType<PoolableObject>();
            foreach (var item in spawnedItems)
                item.Despawn();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}