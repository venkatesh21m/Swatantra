using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Events;
using Swatantra.Inputs;
using System;
//using UnityEngine.InputSystem;

namespace Swatantra.Inputs
{
    public class CameraTargetMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] float CameraMovementSpeed = 10;
        [SerializeField] float PixelXGap = 100;
        [SerializeField] float PixelYGap = 75;
        [SerializeField] bool ScreenEdgeCameraMovement = false;

        #endregion

        #region cache references
        Transform cameraTransform;
        #endregion


        #region Unity Default Functions

        private void Start()
        {
            cameraTransform = Camera.main.transform;

            EventManager.OnMultiCharacterController.AddListener(HandleMultiCharSelection);
            EventManager.OnSingleCharacterController.AddListener(HandleSingleCharSelection);

        }

        void Update()
        {
            float lh = InputManager.MovementVector.x;
            float lv = InputManager.MovementVector.z;

            if (ScreenEdgeCameraMovement)
            {
                if (Input.mousePosition.x > Screen.width - PixelXGap)
                {
                    lh = 1;
                }
                else if (Input.mousePosition.x < PixelXGap)
                {
                    lh = -1;
                }
                else if (Input.mousePosition.y > Screen.height - PixelYGap)
                {
                    lv = 1;
                }
                else if (Input.mousePosition.y < PixelYGap)
                {
                    lv = -1;
                }
            }
            
            Vector3 movement = new Vector3(lh, 0, lv);
            movement.Normalize();
            
            Vector3 cameraForward = cameraTransform.forward;
            cameraForward.y = 0;
            Quaternion cameraRelativeRotation = Quaternion.FromToRotation(Vector3.forward, cameraForward);
            Vector3 lookToward = cameraRelativeRotation * movement;

            if(movement.sqrMagnitude > 0)
            {
                Ray lookRay = new Ray(transform.position, lookToward);
                transform.LookAt(lookRay.GetPoint(1));
                
                transform.Translate(transform.forward* CameraMovementSpeed * Time.deltaTime,Space.World);
            }
        }

        #endregion

        #region Event Handles
        private void HandleSingleCharSelection()
        {
            enabled = false;
        }

        private void HandleMultiCharSelection()
        {
            enabled = true;
        }
        #endregion
    }
}
