using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Swatantra;


namespace Swatantra.Inputs.Selection
{
    public class DragSelectionHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler,IPointerClickHandler
    {
        [SerializeField] Image SelectionBox;
        Vector2 StartPosition;
        Rect SelectionRect;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
            {
                SelectionManager.DeselectAll();
            }
            SelectionBox.gameObject.SetActive(true);
            StartPosition = eventData.position;
            SelectionRect = new Rect();
        }

        public void OnDrag(PointerEventData eventData)
        {


            if (eventData.position.x < StartPosition.x)
            {
                SelectionRect.xMin = eventData.position.x;
                SelectionRect.xMax = StartPosition.x;
            }
            else
            {
                SelectionRect.xMin = StartPosition.x;
                SelectionRect.xMax = eventData.position.x;
            }

            if (eventData.position.y < StartPosition.y)
            {
                SelectionRect.yMin = eventData.position.y;
                SelectionRect.yMax = StartPosition.y;
            }
            else
            {
                SelectionRect.yMin = StartPosition.y;
                SelectionRect.yMax = eventData.position.y;
            }

            SelectionBox.rectTransform.offsetMin = SelectionRect.min;
            SelectionBox.rectTransform.offsetMax = SelectionRect.max;
        }

        public void OnEndDrag(PointerEventData eventData)
        {

            SelectionBox.gameObject.SetActive(false);
            foreach (SelectableObject item in SelectionManager.AllSelectables)
            {
                if (SelectionRect.Contains(Camera.main.WorldToScreenPoint(item.transform.position)))
                {
                    item.OnSelect();
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            float minDistance = 0;

            foreach (RaycastResult item in results)
            {
                if(item.gameObject == gameObject)
                {
                    minDistance = item.distance;
                    break;
                }
            }

            GameObject nextObject = null;
            float maxDistance = Mathf.Infinity;

            foreach (var item in results)
            {
                if(item.distance > minDistance && item.distance < maxDistance)
                {
                    nextObject = item.gameObject;
                    maxDistance = item.distance;
                }
            }

            if (nextObject)
            {
                ExecuteEvents.Execute<IPointerClickHandler>(nextObject, eventData, (x, y) => { x.OnPointerClick((PointerEventData)y); });
            }
        }
    }

}