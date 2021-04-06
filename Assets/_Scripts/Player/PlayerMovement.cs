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

        NavMeshAgent agent;
        Animator anim;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();

        }

       public void SetAgentDestination(Vector3 destination)
        {
            agent.SetDestination(destination);
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            anim.SetFloat("speed", agent.velocity.magnitude);
        }
    }
}
