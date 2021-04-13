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
        public static HashSet<SelectableObject> AllSelectables = new HashSet<SelectableObject>();
        public static HashSet<SelectableObject> CurrentlySelected = new HashSet<SelectableObject>();

        private void Start()
        {
             EventManager.OnMoveTothisLocationEvent.AddListener(HandleMovetoThisLocationEvent);
        }

        private static void HandleMovetoThisLocationEvent(Vector3 targetlocation)
        {
            foreach (SelectableObject item in CurrentlySelected)
            {
               item.GetComponent<MovementSystems.PlayerMovement>().SetAgentDestination(targetlocation);
            }
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
