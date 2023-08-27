using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue.Instantiation
{
    public class ObjectPool : MonoBehaviour
    {
        #region VARIABLES
        [SerializeField] private GameObject prefab;
        private Queue<PoolableObject> inactiveObjects = new Queue<PoolableObject>();
        #endregion

        #region PUBLIC METHODS
        public PoolableObject GetNewObject()
        {
            if (inactiveObjects.Count > 0) return inactiveObjects.Dequeue();
            var newObj = CreateNewObject();
            SetupPoolableObject(newObj);
            return newObj;
        }
        #endregion

        #region PRIVATE METHODS
        private PoolableObject CreateNewObject()
        {
            var newObj = Instantiate(prefab);
            var poolable = newObj.GetComponent<PoolableObject>();
            if (poolable == null) poolable = newObj.AddComponent<PoolableObject>();
            return poolable;
        }
        private void SetupPoolableObject(PoolableObject obj) {
            obj.OnDespawen += () =>
            {
                inactiveObjects.Enqueue(obj);
            };
        }
        #endregion
    }
}