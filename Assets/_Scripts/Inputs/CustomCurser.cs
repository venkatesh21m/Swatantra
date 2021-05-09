//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using Swatantra.Inputs;

//public class CustomCurser : MonoBehaviour
//{
//    [SerializeField] float CursorMovementSpeed = 5;

//    Mouse mouse;

//    public static bool gamepad = false;
    
    
//    private void Start()
//    {
//        mouse = Mouse.current;

//        Cursor.visible = false;
//        Cursor.lockState = CursorLockMode.Confined;

//    }

//    private void Update()
//    {
//        if (gamepad)
//        {
//            Vector2 pos = transform.position;
//            pos.x += InputManager.CurserInput.x * CursorMovementSpeed * Time.deltaTime;
//            pos.y += InputManager.CurserInput.y * CursorMovementSpeed * Time.deltaTime;
//            pos.x = Mathf.Clamp(pos.x, 0, Screen.width);
//            pos.y = Mathf.Clamp(pos.y, 0, Screen.height);
//            transform.position = pos;

//            mouse.WarpCursorPosition(transform.position);
//        }
//        else
//        {
//             transform.position = mouse.position.ReadValue();
//        }
//    }

//}
