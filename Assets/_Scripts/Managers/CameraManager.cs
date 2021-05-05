using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Swatantra.Events;
using System;

namespace Swatantra.Managers
{
    public class CameraManager : MonoBehaviour
    {
        #region references
        public CinemachineVirtualCamera MultiCharacterControlCamera;
        public CinemachineVirtualCamera SingleCharacterControlCamera;
        #endregion

        #region Unity Default Functions
        private void Start()
        {
            EventManager.OnMultiCharacterController.AddListener(HandleMultiCharSelection);
            EventManager.OnSingleCharacterController.AddListener(HandleSingleCharSelection);
        }
        #endregion

        #region Event Handlers

        private void HandleSingleCharSelection()
        {
            SingleCharacterControlCamera.enabled = true;
            MultiCharacterControlCamera.enabled = false;
        }

        private void HandleMultiCharSelection()
        {
            SetMultiCharacterControlCameraPosition();
            SingleCharacterControlCamera.enabled = false;
            MultiCharacterControlCamera.enabled = true;
        }

        #endregion

        #region Normal functions

        void SetMultiCharacterControlCameraPosition()
        {
            Vector3 pos = SingleCharacterControlCamera.transform.position;
            pos.y = 25f;
            MultiCharacterControlCamera.transform.position = pos;
        }
        #endregion
    }
}
