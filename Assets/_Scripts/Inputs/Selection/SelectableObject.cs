using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Events;
using System;

namespace Swatantra.Inputs.Selection
{
    public class SelectableObject : MonoBehaviour
    {
        public static bool isactive = true;
       
        bool selected = false;

        private void Awake()
        {
            // adding this selectable to AllSelectables in SelectionManager
            SelectionManager.AllSelectables.Add(this);
        }
        private void Start()
        {
            EventManager.OnMultiCharacterController.AddListener(HandleMultiCharSelection);
            EventManager.OnSingleCharacterController.AddListener(HandleSingleCharSelection);
        }

        private void HandleMultiCharSelection(bool arg0)
        {
            this.enabled = true;
        }

        private void HandleSingleCharSelection(bool arg0)
        {
            this.enabled = false;
        }

        void OnMouseDown()
        {
            if (!enabled) return;
            
            if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
            {
                if (!selected)
                {
                    SelectionManager.DeselectAll();
                    OnSelect();
                }
                else
                {
                    SelectionManager.Deselect(this);
                }
            }
            else
            {
                OnSelect();
            }
        }

        public void OnSelect()
        {
            if (!selected)
            {
                SelectionManager.CurrentlySelected.Add(this);
                selected = true;
                SelectionEffect();
            }
            else
            {
                SelectionManager.Deselect(this);
            }
        }

        public void OnDeselect()
        {
            selected = false;
            DeselectEffect();
        }


        #region Effects

        public void SelectionEffect()
        {
            // SelectionIndicator.enabled = true;
            var outline = gameObject.AddComponent<Outline>();

            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.green;
            outline.OutlineWidth = 3.5f;

        }

        public void DeselectEffect()
        {
            // SelectionIndicator.enabled = false;
            Destroy(GetComponent<Outline>());
        }
        #endregion



    }
}
