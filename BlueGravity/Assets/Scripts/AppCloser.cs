using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue
{
    public class AppCloser : MonoBehaviour
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
        private int varA = 0;
        #endregion

        #region PUBLIC METHODS
        public void CloseApplication()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}