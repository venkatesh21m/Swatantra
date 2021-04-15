using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Events;

namespace Swatantra.Inputs.Selection
{
    public class SelectableObject : MonoBehaviour
    {
        #region Variables
        private bool selected = false;
        
        private Outline outline;
        
        #endregion

        #region Unity Default Functions

        private void Awake()
        {
            // adding this selectable to AllSelectables in SelectionManager
            SelectionManager.AllSelectables.Add(this);
        }
       
        private void Start()
        {
            EventManager.OnMultiCharacterController.AddListener(HandleMultiCharSelection);
            EventManager.OnSingleCharacterController.AddListener(HandleSingleCharSelection);

            OutlineEffect(Color.white);
            outline.enabled = false;

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

        void OnMouseEnter()
        {
            EnableOutline();
        }

        void OnMouseExit()
        {
            if (!selected)
                DisableOutline();
        }

        #endregion

        #region Event Hadles
        private void HandleMultiCharSelection(bool arg0)
        {
            this.enabled = true;
        }

        private void HandleSingleCharSelection(bool arg0)
        {
            this.enabled = false;
        }

        #endregion

        #region Selection Functions
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

        #endregion

        #region Effects

        public void SelectionEffect()
        {
            // SelectionIndicator.enabled = true;
            changeOutlineColor(Color.green);
        }

        public void DeselectEffect()
        {
            // SelectionIndicator.enabled = false;
            DisableOutline();
            changeOutlineColor(Color.white);

        }
        #endregion

        #region Outline
        public void OutlineEffect(Color color, float width = 3.5f)
        {
            outline = gameObject.AddComponent<Outline>();

            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = color;
            outline.OutlineWidth = width;
        }

        void changeOutlineColor(Color color)
        {
            outline.OutlineColor = color;
        }

        void ChangeOutlineWidth(float width)
        {
            outline.OutlineWidth = width;
        }

        public  void EnableOutline()
        {
            outline.enabled = true;
        }

        public void DisableOutline()
        {
            outline.enabled = false;
        }

        #endregion

    }
}
