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
        [SerializeField] CinemachineFreeLook MultiCharacterControlCamera;
        [SerializeField] CinemachineVirtualCamera SingleCharacterControlCamera;

        [Space]
        [SerializeField] Transform MulticamTarget;
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

        #region functions

        void SetMultiCharacterControlCameraPosition()
        {
            Vector3 pos = SingleCharacterControlCamera.Follow.position;
            pos.y = 0;
            MulticamTarget.transform.position = pos;
        }

        #endregion
    }
}
