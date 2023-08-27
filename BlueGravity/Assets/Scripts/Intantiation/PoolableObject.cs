using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue.Instantiation
{
    public class PoolableObject : MonoBehaviour
    {
        #region VARIABLES
        public bool Active { get; private set; } = false;
        public Action OnSpawn, OnDespawen;
        #endregion

        #region PUBLIC METHODS
        public void Spawn()
        {
            if (Active) return;
            Active = true;
            OnSpawn?.Invoke();
        }
        public void Despawn() {
            if (!Active) return;
            Active = false;
            OnDespawen?.Invoke();
        }
        #endregion
    }
}