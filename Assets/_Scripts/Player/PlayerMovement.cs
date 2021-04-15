using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Events;
using System;
using UnityEngine.AI;

namespace Swatantra.MovementSystems
{
    public class PlayerMovement : MonoBehaviour
    {
        #region References
        private NavMeshAgent agent;
        private Animator anim;
        #endregion

        #region Unity Default Functions
        
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();

        }
       
        void FixedUpdate()
        {
            anim.SetFloat("speed", agent.velocity.magnitude);
        }

        #endregion

        #region Event Handles
        public void SetAgentDestination(Vector3 destination)
        {
            agent.SetDestination(destination);
        }

        #endregion
    }
}
