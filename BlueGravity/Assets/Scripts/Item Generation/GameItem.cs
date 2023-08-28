using GravityBlue.Data;
using GravityBlue.Instantiation;
using GravityBlue.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue
{
    public class GameItem : PoolableObject, IInteractible
    {
        #region UNITY METHODS
        private void Awake()
        {
            PrepareRenderer();
        }
        private void OnEnable()
        {
            OnSpawn += () => ShowObject();
            OnDespawen += () => HideObject();
        }
        private void OnDisable()
        {
            OnSpawn -= () => ShowObject();
            OnDespawen -= () =>  HideObject();
        }
        #endregion

        #region VARIABLES
        public uint ID { get; private set; } = 0;

        [SerializeField]
        private SpriteRenderer spriteRender;
        [SerializeField] private AudioClip sound;
        #endregion

        #region PUBLIC METHODS
        public void Initialize(GameItemData data)
        {
            PrepareRenderer();
            spriteRender.sprite = data.Visual;
            sound = data.sound;
            ID = data.ID;
        }
        public virtual void Interact() {
            Despawn();
            AudioController.Instance.PlaySound(sound);
        /*
         * if(Storage.HasSpace())
         * {
         *      Storage.Add(this);
         * }
         */
        }
        #endregion

        #region PRIVATE METHODS
        private void PrepareRenderer()
        {
            if (spriteRender != null) return;
            spriteRender = gameObject.AddComponent<SpriteRenderer>();
        }
        private void HideObject() { gameObject.SetActive(false); }
        private void ShowObject() { gameObject.SetActive(true); }
        #endregion
    }
}