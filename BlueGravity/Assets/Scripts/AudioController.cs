using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue
{
    public class AudioController : MonoBehaviour
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
        public static AudioController Instance => instance;
        private static AudioController instance;

        [SerializeField] private AudioSource sfx;
        #endregion

        #region PUBLIC METHODS
        public void PlaySound(AudioClip sound)
        {
            if (sound == null) return;
            sfx.Stop();
            sfx.clip = sound;
            sfx.Play();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}