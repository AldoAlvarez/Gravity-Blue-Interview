using GravityBlue.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue.Movement
{
    public class MovementController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            animTime.OnFinish = () => {
                PrepareMovement();
            };
        }

        private void Update()
        {
            animTime.Tick(Time.deltaTime);

            MoveAvatar();
            var radians = Mathf.Atan2(direction.y, direction.x);
            float degrees = radians * Mathf.Rad2Deg;
            var rotation = Quaternion.AngleAxis(degrees, Vector3.forward);
            foreach (var element in rotatableElements)
                element.rotation = rotation;
        }
        #endregion

        #region VARIABLES
        [SerializeField, Range(1, 5)]
        private int speed = 1;
        [SerializeField] private Timer animTime = new Timer(0.6f);
        [SerializeField] private Transform avatar;
        [SerializeField] private Transform[] rotatableElements;

        private Vector3 direction;
        private Vector3 currentPos;
        private Vector3 endingPos;
        #endregion

        #region PUBLIC METHODS
        public void SetMovementDirection(Vector2 input)
        {
            direction = input;
            PrepareMovement();      
        }
        public void StopMovement() {
            direction = Vector2.zero;
            avatar.position = currentPos;
            endingPos = currentPos;
        }
        #endregion

        #region PRIVATE METHODS
        private void PrepareMovement()
        {
            currentPos = avatar.position;
            endingPos = currentPos + (direction * speed);
            animTime.Restart();
        }
        private void MoveAvatar() {
            var percent = 1f - (animTime.Remaining / animTime.Target);
            var pos = Vector3.Lerp(currentPos, endingPos, percent);
            avatar.position = pos;
        }
        #endregion
    }
}