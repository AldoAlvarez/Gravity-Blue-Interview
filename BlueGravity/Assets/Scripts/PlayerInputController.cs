using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GravityBlue.Movement;

namespace GravityBlue
{
    public class PlayerInputController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            if (instance != null) Destroy(this);
            else instance = this;
        }
        private void OnEnable()
        {
            if (controls == null)
            {
                controls = new PlayerControls();
            }
            controls.Enable();

            controls.PlayerUI.Disable();

            controls.Player.Move.performed += input => movement.SetMovementDirection(input.ReadValue<Vector2>());
            controls.Player.Move.canceled += input => movement.SetMovementDirection(input.ReadValue<Vector2>());

            controls.Player.Interact.performed += input => { interaction.InteractWithObject(); };
            controls.Player.Inventory.performed += input => { storageUI.DisplayStorage(); storageUI.UpdateStorageDisplay(PlayerStorage.Instance.storage); };

            controls.PlayerUI.Inventory.performed += input => { storageUI.HideStorage(); };
        }
        private void OnDisable()
        {
            controls.Disable();
            controls.Player.Move.performed -= input => movement.SetMovementDirection(input.ReadValue<Vector2>());
            controls.Player.Move.canceled -= input => movement.SetMovementDirection(input.ReadValue<Vector2>());

            controls.Player.Interact.performed -= input => { interaction.InteractWithObject(); };
            controls.Player.Inventory.performed -= input => { storageUI.DisplayStorage(); storageUI.UpdateStorageDisplay(PlayerStorage.Instance.storage); };

            controls.PlayerUI.Inventory.performed -= input => { storageUI.HideStorage(); };
        }

        private void Update()
        {

        }
        #endregion

        #region VARIABLES
        public static PlayerInputController Instance => instance;
        private static PlayerInputController instance;

        [SerializeField] private MovementController movement;
        [SerializeField] private Interaction.InteractionController interaction;
        [SerializeField] private StorageDisplay storageUI;

        private PlayerControls controls;
        #endregion

        #region PUBLIC METHODS
        public void DisableGeneralControls()
        {
            controls.Player.Disable();
            controls.PlayerUI.Enable();

        }
        public void EnableGeneralControls()
        {
            controls.Player.Enable();
            controls.PlayerUI.Disable();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {

        }
        #endregion
    }
}