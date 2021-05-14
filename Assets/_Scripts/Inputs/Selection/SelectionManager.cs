using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Swatantra.Events;
using Swatantra.MovementSystems;
using System;

namespace Swatantra.Inputs.Selection
{
    public class SelectionManager : MonoBehaviour
    {
        #region Variables
        
        [Header("Choose type of Mode")]
        [SerializeField] bool SingleCharacterControl;
        [SerializeField] bool multiPlayerControl;

        [Space]
        public MovementSystems.Movement currentPlayer;

        public static HashSet<SelectableObject> AllSelectables = new HashSet<SelectableObject>();
        public static HashSet<SelectableObject> CurrentlySelected = new HashSet<SelectableObject>();

        #endregion

        #region Default Unity Functions
        private void Start()
        {
            CheckSelectionMode();
            Events.EventManager.OnCurrentCharacterSelection.AddListener(HandleCurrentCharacterSelection);
        }

      
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (multiPlayerControl)
                    OnsingleModeControlSelection();
                else
                    OnMultiModeControlSelection();
            }
        }
        #endregion

        #region control mode selection functions
        void CheckSelectionMode()
        {
            if (SingleCharacterControl)
            {
                EventManager.OnSingleCharacterController.Invoke();
                EventManager.OnMoveTothisLocationEvent.AddListener(SetDestinationToMainCharacter);
                EventManager.OnMoveTothisLocationEvent.RemoveListener(HandleMultiMovetoThisLocationEvent);
                currentPlayer.GetComponent<LineRenderer>().enabled = true;
            }
            else if (multiPlayerControl)
            {
                EventManager.OnMultiCharacterController.Invoke();
                EventManager.OnMoveTothisLocationEvent.AddListener(HandleMultiMovetoThisLocationEvent);
                EventManager.OnMoveTothisLocationEvent.RemoveListener(SetDestinationToMainCharacter);
                currentPlayer.GetComponent<LineRenderer>().enabled = false;
            }
        }

        public void OnsingleModeControlSelection()
        {
            DeselectAll();

            SingleCharacterControl = true;
            multiPlayerControl = false;
            CheckSelectionMode();
        }

        public void OnMultiModeControlSelection()
        {
            SingleCharacterControl = false;
            multiPlayerControl = true;
            CheckSelectionMode();
        }

        public void Ontogglemultiselection(bool toggle)
        {
            if(toggle)
            {
                multiPlayerControl = true;
                SingleCharacterControl = false;
            }
            else
            {
                DeselectAll();

                SingleCharacterControl = true;
                multiPlayerControl = false;
            }
            CheckSelectionMode();
        }

        #endregion

        #region Events Handle

        private static void HandleMultiMovetoThisLocationEvent(Vector3 targetlocation)
        {
            foreach (SelectableObject item in CurrentlySelected)
            {
               item.GetComponent<MovementSystems.Movement>().SetAgentDestination(targetlocation);
            }
        }

        public void SetDestinationToMainCharacter(Vector3 targetPos)
        {
            currentPlayer.SetAgentDestination(targetPos);
        }

        private void HandleCurrentCharacterSelection(Movement CurrentCharacter)
        {
            Destroy(currentPlayer.gameObject.GetComponent<MainPlayerMovement>());
            currentPlayer.GetComponent<SelectableObject>().SingleCharacterOnDeSelection();

            currentPlayer = CurrentCharacter;
            if (!currentPlayer.gameObject.GetComponent<MainPlayerMovement>())
            {
                currentPlayer.gameObject.AddComponent<MainPlayerMovement>().movementSpeed = 8;
               // currentPlayer.GetComponent<MainPlayerMovement>().enabled = false;
            }

            currentPlayer.GetComponent<SelectableObject>().SingleCharacterOnSelection();
        }

        #endregion

        #region selection and deselection Functions
        /// <summary>
        /// To cler all currently selected objects
        /// </summary>
        /// <param name="eventData"></param>
        public static void DeselectAll()
        {
            foreach (SelectableObject item in CurrentlySelected)
            {
                item.OnDeselect();
            }

            CurrentlySelected.Clear();
        }

        /// <summary>
        /// to deselect a single character
        /// </summary>
        /// <param name="objectToDeselect"></param>
        public static void Deselect(SelectableObject objectToDeselect)
        {
            if (CurrentlySelected.Count == 0) return;

            foreach (SelectableObject item in CurrentlySelected)
            {
                if (item == objectToDeselect)
                {
                    CurrentlySelected.Remove(item);
                    item.OnDeselect();
                    return;
                }
            }
        }

        #endregion
    }
}
