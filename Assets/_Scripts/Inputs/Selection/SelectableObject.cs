using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Swatantra.Inputs.Selection
{
    public class SelectableObject : MonoBehaviour
    {
        Renderer renderer;
        bool selected = false;
       // [SerializeField] LineRenderer SelectionIndicator;
        [SerializeField] GameObject SelectionIndicator;

        private void Awake()
        {
            // adding this selectable to AllSelectables in SelectionManager
            SelectionManager.AllSelectables.Add(this);
            renderer = GetComponent<Renderer>();
        }

        void OnMouseDown()
        {
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
            SelectionIndicator.SetActive(true);
        }

        public void DeselectEffect()
        {
            // SelectionIndicator.enabled = false;
            SelectionIndicator.SetActive(false);
        }
        #endregion



    }
}
