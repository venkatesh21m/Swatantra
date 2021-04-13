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
        public bool SingleCharacterControl;
        public bool multiPlayerControl;

        public MovementSystems.PlayerMovement currentPlayer;

        public static HashSet<SelectableObject> AllSelectables = new HashSet<SelectableObject>();
        public static HashSet<SelectableObject> CurrentlySelected = new HashSet<SelectableObject>();

        private void Start()
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
    }
}
