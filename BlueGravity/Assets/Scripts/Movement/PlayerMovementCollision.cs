using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue.Movement
{
    public class PlayerMovementCollision : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Offlimits"))
                movement.StopMovement();           
        }
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Offlimits"))
                movement.StopMovement();
        }
        #endregion

        #region VARIABLES
        [SerializeField] private MovementController movement;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}