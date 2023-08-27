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
            if (Input.GetKeyDown(KeyCode.P)) {
                var item = itemsPool.GetNewObject();
                item.transform.position = spawnPoint.position;
                item.GetComponent<GameItem>().Initialize(gold);
                item.Spawn();
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                var item = itemsPool.GetNewObject();
                item.transform.position = spawnPoint.position;
                item.GetComponent<GameItem>().Initialize(diamond);
                item.Spawn();
            }
            if (Input.GetKeyDown(KeyCode.Backspace)) DespawnAll();
        }
        #endregion

        #region VARIABLES
        public static GameItemsController Instance { get; private set; }
        private static GameItemsController instance;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private ObjectPool itemsPool;
        [SerializeField] private GameItemData gold;
        [SerializeField] private GameItemData diamond;
        #endregion

        #region PUBLIC METHODS
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