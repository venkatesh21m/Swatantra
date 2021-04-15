using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Swatantra.Events;

namespace Swatantra.Inputs.Selection
{
    public class SelectionManager : MonoBehaviour
    {
        #region Variables
        
        [Header("Choose type of Mode")]
        [SerializeField] bool SingleCharacterControl;
        [SerializeField] bool multiPlayerControl;

        [SerializeField] MovementSystems.PlayerMovement currentPlayer;

        public static HashSet<SelectableObject> AllSelectables = new HashSet<SelectableObject>();
        public static HashSet<SelectableObject> CurrentlySelected = new HashSet<SelectableObject>();

        #endregion

        private void Start()
        {
            CheckSelectionMode();
        }

        void CheckSelectionMode()
        {
            if (SingleCharacterControl)
            {
                EventManager.OnSingleCharacterController.Invoke(true);
                EventManager.OnMoveTothisLocationEvent.AddListener(SetDestinationToMainCharacter);

            }
            else if (multiPlayerControl)
            {
                EventManager.OnMultiCharacterController.Invoke(true);
                EventManager.OnMoveTothisLocationEvent.AddListener(HandleMultiMovetoThisLocationEvent);
            }
        }


        #region Events Handle

        private static void HandleMultiMovetoThisLocationEvent(Vector3 targetlocation)
        {
            foreach (SelectableObject item in CurrentlySelected)
            {
               item.GetComponent<MovementSystems.PlayerMovement>().SetAgentDestination(targetlocation);
            }
        }

        public void SetDestinationToMainCharacter(Vector3 targetPos)
        {
            currentPlayer.SetAgentDestination(targetPos);
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
