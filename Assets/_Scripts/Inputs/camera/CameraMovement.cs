using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Swatantra.Inputs
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] float CameraMovementSpeed = 10;
        
        void Update()
        {
            float lh = Input.GetAxis("Horizontal");
            float lv = Input.GetAxis("Vertical");
            float ld = Input.GetAxis("Depth");

            Vector3 movement = new Vector3(lh, ld, lv);
            movement.Normalize();
            transform.Translate(movement * CameraMovementSpeed * Time.deltaTime,Space.World);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 10, 40), transform.position.z);
        }
    }
}
