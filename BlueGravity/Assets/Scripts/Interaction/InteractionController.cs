using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue.Interaction
{
    [RequireComponent(typeof(Collider2D))]
    public class InteractionController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            collision = GetComponent<Collider2D>();
        }

        private void Update()
        {
            
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            var interactible = other.GetComponent<IInteractible>();
            if (interactible != null) { currentInteraction = interactible; }
        }
        #endregion

        #region VARIABLES
        private Collider2D collision;
        private IInteractible currentInteraction;
        #endregion

        #region PUBLIC METHODS
        public void InteractWithObject()
        {
            if (currentInteraction == null) return;
            currentInteraction.Interact();
        }
        public void Enable() { collision.enabled = true; }
        public void Disable() { collision.enabled = false; ClearInteraction(); }
        public void ClearInteraction() { currentInteraction = null; }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}