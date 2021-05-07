using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Events;


namespace Swatantra.Inputs
{
    public class InputManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] float RaymaxDistance;
        #endregion

        #region Static Variables
        public static Vector3 MovementVector;
        #endregion

        #region cache references
        Camera mainCamera;
        #endregion

        #region Default Unity functions
        void Start()
        {
            mainCamera = Camera.main;
        }

        void Update()
        {
            #region MouseButton click check
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
            #endregion

            #region Axis Inputs
            float lh = Input.GetAxis("Horizontal");
            float lv = Input.GetAxis("Vertical");

            MovementVector.x = lh;
            MovementVector.z = lv;
            #endregion
        }
        #endregion
    }
}
