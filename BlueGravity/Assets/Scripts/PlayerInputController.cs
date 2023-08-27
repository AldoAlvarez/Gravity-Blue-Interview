using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GravityBlue
{
    public class PlayerInputController : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnEnable()
        {
            controls = new PlayerControls();
            controls.Enable();

            controls.Player.Move.performed += input=> movement.SetMovementDirection(input.ReadValue<Vector2>());
            controls.Player.Move.canceled += input=> movement.SetMovementDirection(input.ReadValue<Vector2>());
        }
        private void OnDisable()
        {
            controls.Disable();
            controls.Player.Move.performed -= input => movement.SetMovementDirection(input.ReadValue<Vector2>());
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private MovementController movement;
        private PlayerControls controls;
        private int varA = 0;
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