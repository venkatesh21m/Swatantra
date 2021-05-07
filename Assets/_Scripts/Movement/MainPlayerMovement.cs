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


        private Vector3 velocity;
        private bool usingthis;
        #endregion

        #region Cache variables
      
        private NavMeshAgent agent;
        private Animator anim;
        private Rigidbody rb;
        
        #endregion

        #region Unity Default Functions
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();
            rb = GetComponent<Rigidbody>();

            EventManager.OnMultiCharacterController.AddListener(HandleMultiCharSelection);
            EventManager.OnSingleCharacterController.AddListener(HandleSingleCharSelection);
        }

        // Update is called once per frame
        void Update()
        {
            if(InputManager.MovementVector.magnitude > 0)
            {
                usingthis = true;
                velocity = Vector3.Slerp(velocity,InputManager.MovementVector, .02f);
                agent.enabled = false;
            }
            else
            {
                velocity = Vector3.Slerp(velocity, Vector3.zero, .002f);

                if(velocity.magnitude < 1f)
                {
                    usingthis = false;
                    agent.enabled = true;
                }
                return;
            }
        }

        private void FixedUpdate()
        {
            if (!usingthis) return;

            rb.velocity = velocity * movementSpeed * Time.deltaTime;
           
            velocity.Normalize();
            Quaternion rot = Quaternion.LookRotation(velocity);
            rb.rotation = Quaternion.Slerp(transform.rotation, rot, .5f);
            
            anim.SetFloat("speed", rb.velocity.magnitude);
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
