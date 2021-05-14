using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
//using UnityEngine.InputSystem;
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
            
            Cursor.lockState = CursorLockMode.None;
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
                        if (!Input.GetKey(KeyCode.LeftControl))
                            Selection.SelectionManager.DeselectAll();
                    }
                }
            }
            #endregion

            MovementVector.x = Input.GetAxis("Horizontal");
            MovementVector.z = Input.GetAxis("Vertical");
        }

        #endregion

        //#region Input Events
        //public void OnMovement(InputAction.CallbackContext value)
        //{
        //    Vector2 inputMovement = value.ReadValue<Vector2>();
        //    MovementVector.x = inputMovement.x;
        //    MovementVector.z = inputMovement.y;
        //}

        //public static void OnCurserInput(InputAction.CallbackContext value)
        //{
        //    CurserInput = value.ReadValue<Vector2>();
        //}


        //public void onRightMouseButton(InputAction.CallbackContext value)
        //{
        //    if (value.performed)
        //    {
        //        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //        RaycastHit hit;
        //        if (Physics.Raycast(ray, out hit, RaymaxDistance))
        //        {
        //            if (hit.collider.CompareTag("Walkable"))
        //            {
        //                EventManager.OnMoveTothisLocationEvent.Invoke(hit.point);
        //            }
        //        }
        //    }
        //}

        //public void onLeftMouseButton(InputAction.CallbackContext value)
        //{
        //    if (value.performed)
        //    {
        //        selection = true;

        //        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //        RaycastHit hit;
        //        if (Physics.Raycast(ray, out hit, RaymaxDistance))
        //        {
        //            if (hit.collider.CompareTag("Walkable"))
        //            {
        //                if (!Input.GetKey(KeyCode.LeftControl))
        //                    Selection.SelectionManager.DeselectAll();
        //            }
        //        }
        //    }
        //    //if (value.performed)
        //    //{
        //    //    selection = false;
        //    //}
        //}

        //public void OnInputControlChange(PlayerInput playerInput)
        //{
        //    switch (playerInput.currentControlScheme)
        //    {
        //        case "GamePad":
        //            CustomCurser.gamepad = true;
        //            break;
        //        case "KeyboardAndMouse":
        //            CustomCurser.gamepad = false;
        //            break;
        //        default:
        //            break;
        //    }
        //}
        //#endregion
    }
}
