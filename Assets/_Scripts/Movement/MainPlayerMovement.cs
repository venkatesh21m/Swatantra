using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Swatantra.Inputs;
using Swatantra.Events;
using System;

namespace Swatantra.MovementSystems
{
    public class MainPlayerMovement : MonoBehaviour
    {
        #region variables
        [SerializeField] float movementSpeed;


        private Vector3 movementInput;
        private bool usingthis;
        private float speed;
        #endregion

        #region Cache variables
      
        private NavMeshAgent agent;
        private Animator anim;
        private Movement movement;

        private Transform cameraTransform;

        #endregion

        #region Unity Default Functions
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();
            movement = GetComponent<Movement>();
            cameraTransform = Camera.main.transform;
            EventManager.OnMultiCharacterController.AddListener(HandleMultiCharSelection);
            EventManager.OnSingleCharacterController.AddListener(HandleSingleCharSelection);
        }

        // Update is called once per frame
        void Update()
        {
            if(InputManager.MovementVector.magnitude > 0.25f)
            {
                if (agent.enabled)
                {
                    movement.enabled = false;
                    speed = agent.velocity.magnitude;
                    agent.enabled = false;
                    usingthis = true;
                }
                movementInput = Vector3.Slerp(movementInput,InputManager.MovementVector, .02f);
                speed = Mathf.Lerp(speed, movementSpeed, 0.005f);
            }
            else
            {
                movementInput = Vector3.Slerp(movementInput, Vector3.zero,0.002f);
                speed = Mathf.Lerp(speed, 0, 0.02f);

                if(InputManager.MovementVector.magnitude < 0.025f)
                {
                    usingthis = false;
                    agent.enabled = true;
                    movement.enabled = true;
                }
                return;
            }

            Vector3 cameraForward = cameraTransform.forward;
            cameraForward.y = 0;

            Quaternion cameraRelativeRotation = Quaternion.FromToRotation(Vector3.forward, cameraForward);
            Vector3 lookToward = cameraRelativeRotation * movementInput;

            if (speed > 0)
            {
                Ray lookRay = new Ray(transform.position, lookToward);

                //transform.LookAt(lookRay.GetPoint(1));
                Vector3 relativepostion = lookRay.GetPoint(1) - transform.position;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(relativepostion),0.02f) ;

                transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
                anim.SetFloat("speed", speed);
            }
        }
        #endregion

        #region Event Handlers
        private void HandleSingleCharSelection()
        {
            enabled = true;
        }

        private void HandleMultiCharSelection()
        {
            enabled = false;
        }
        #endregion
    }
}
