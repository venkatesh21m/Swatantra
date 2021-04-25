using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Events;


namespace Swatantra.Inputs
{

    public class MousePointerInput : MonoBehaviour
    {
        [SerializeField] float RaymaxDistance;
        Camera mainCamera;
        // Start is called before the first frame update
        void Start()
        {
            mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, RaymaxDistance))
                {
                    if (hit.collider.CompareTag("Walkable"))
                    {
                        EventManager.OnMoveTothisLocationEvent.Invoke(hit.point);
                    }
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, RaymaxDistance))
                {
                    if (hit.collider.CompareTag("Walkable"))
                    {
                        if(!Input.GetKey(KeyCode.LeftControl))
                            Selection.SelectionManager.DeselectAll();
                    }
                }
            }
        }
    }
}
