using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Swatantra.MovementSystems;


namespace Swatantra.Stats.characterStats
{
    public class CharacterStats : MonoBehaviour
    {
        public CharacterStats_SO CharacterDefinition;

        private Movement agentmovement;

        private void Start()
        {
            agentmovement = GetComponent<Movement>();
            CharacterDefinition = Instantiate(CharacterDefinition);
            Tasks.CharacterTaskManager.AddStatToTheCharactersList(this);
        }


        public void AddTask(Task task)
        {
            CharacterDefinition.currentTask = task;
        }

        public void SetDestination(Vector3 pos)
        {
            agentmovement.SetAgentDestination(pos);
        }
    }
}