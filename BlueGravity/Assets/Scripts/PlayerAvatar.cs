using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue
{
    public class PlayerAvatar: MonoBehaviour
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
        public static PlayerAvatar Instance => instance;
        private static PlayerAvatar instance;

        [SerializeField]
        private SpriteRenderer render;
        #endregion

        #region PUBLIC METHODS
        public void SetOutfit(Sprite outfit)
        {
            render.sprite = outfit;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}