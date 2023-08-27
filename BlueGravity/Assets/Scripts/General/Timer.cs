using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GravityBlue.General
{
    [System.Serializable]
    public class Timer:IRestartable
    {
        #region CONTRUCTORS
        public Timer() { }
        public Timer(float time) { Target = time; }
        #endregion

        #region VARIABLES
        public float Target = 1f;
        public float Remaining { get; private set; }
        public Action OnFinish;
        #endregion

        #region PUBLIC METHODS
        public void Tick(float deltaTime)
        {
            if (Remaining <= 0) return;
                Remaining = Mathf.Max(0, Remaining - deltaTime);
            if (Remaining <= 0) OnFinish.Invoke();
        }
        public void Restart()
        {
            Remaining = Target;
        }
        #endregion
    }
}