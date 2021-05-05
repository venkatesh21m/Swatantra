using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Events;
using System;

namespace Swatantra.Inputs
{
    public class CameraMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] float CameraMovementSpeed = 10;
        [SerializeField] float PixelXGap = 100;
        [SerializeField] float PixelYGap = 75;
        [SerializeField] bool ScreenEdgeCameraMovement = false;

        #endregion

        #region Unity Default Functions

        private void Start()
        {
            EventManager.OnMultiCharacterController.AddListener(HandleMultiCharSelection);
            EventManager.OnSingleCharacterController.AddListener(HandleSingleCharSelection);
        }

        void Update()
        {
            float lh = Input.GetAxis("Horizontal");
            float lv = Input.GetAxis("Vertical");
            float ld = Input.GetAxis("Depth");
          
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
            
            Vector3 movement = new Vector3(lh, ld, lv);

            movement.Normalize();
            transform.Translate(movement * CameraMovementSpeed * Time.deltaTime,Space.World);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 10, 40), transform.position.z);
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
