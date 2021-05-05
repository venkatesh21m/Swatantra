using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Events;
using Swatantra;

namespace Swatantra.Inputs.Selection
{
    public class SelectableObject : MonoBehaviour
    {
        #region Variables
        private bool selected = false;
        private bool singlePlayerControl = false;
        #endregion

        #region cached References
        private Outline outline;
        private LineRenderer lineRenderer;
        private Stats.characterStats.CharacterStats characterStats;
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

            lineRenderer = GetComponent<LineRenderer>();
            Helpers.CircleDrawer.DrawCircle(lineRenderer, 0.75f, 0.05f);
            lineRenderer.enabled = false;

            characterStats = GetComponent<Stats.characterStats.CharacterStats>();
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
            if (!selected)
                EnableOutline();
            else
                changeOutlineColor(Color.white);

            //Rise event to show character details on the UI
            EventManager.OnHoverOnCharacterEvent.Invoke(characterStats.CharacterDefinition);
        }

        void OnMouseExit()
        {

            if (!selected)
                DisableOutline();
            else
                changeOutlineColor(Color.green);

            //Rise event to disable character details on the UI
            EventManager.onHoverExitOnCharacterEvent.Invoke();
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
            lineRenderer.enabled = true;
        }

        public void DeselectEffect()
        {
            // SelectionIndicator.enabled = false;
            DisableOutline();
            changeOutlineColor(Color.white);
            lineRenderer.enabled = false;
        }
        #endregion

        #region Outline
        public void OutlineEffect(Color color, float width = 2.5f)
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
