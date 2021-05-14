using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Swatantra.UI
{
    public class UIAnimatorHolder : MonoBehaviour
    {
        [SerializeField] bool MainCharacterPanel;
        private UIAnimator[] UIanimators;

        private void Start()
        {
            UIanimators = GetComponentsInChildren<UIAnimator>();
            if (MainCharacterPanel)
            {
                Events.EventManager.OnMultiCharacterController.AddListener(HandleMultiCharacterSelectionEvent);
                Events.EventManager.OnSingleCharacterController.AddListener(HandlSingleCharacterSelectionEvent);
            }
        }

        private void HandlSingleCharacterSelectionEvent()
        {
            gameObject.SetActive(false);
        }

        private void HandleMultiCharacterSelectionEvent()
        {
            ResetAnimators();
            gameObject.SetActive(true);
        }

        public void ResetAnimators()
        {
            for (int i = 0; i < UIanimators.Length; i++)
            {
                UIanimators[i].ResetAnim();
            }
        }
    }
}
