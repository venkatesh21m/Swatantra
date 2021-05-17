using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Stats.characterStats;
using Swatantra.Stats.BuildingStats;

namespace Swatantra.Tasks
{
    public class CharacterTaskManager 
    {
        public static List<CharacterStats> characters = new List<CharacterStats>();

        public static void AddStatToTheCharactersList(CharacterStats character)
        {
            characters.Add(character);
        }

        public static List<CharacterStats> GetIdleCharacters(int number)
        {
            List<CharacterStats> IdleCharacters = characters.FindAll(e => e.CharacterDefinition.currentTask == Task.Idle);
            List<CharacterStats> returnableIDleCharacters = new List<CharacterStats>();
            for (int i = 0; i < number; i++)
            {
                returnableIDleCharacters.Add(IdleCharacters[i]);
            }
            IdleCharacters.Clear();
            return returnableIDleCharacters;
        }

        public static void AssignBUildingTaskToIdleCharacters(int number,Transform transform)
        {
            List<CharacterStats> IdleCharacters = GetIdleCharacters(number);
            foreach (var character in IdleCharacters)
            {
                character.AddTask(Task.Building);
                Vector3 pos;
                pos.x = Mathf.Cos(Random.Range(0,360)) * 1 + transform.position.x;
                pos.y = transform.position.y;
                pos.z = Mathf.Sin(Random.Range(0, 360)) * 1 + transform.position.z;
                character.SetDestination(pos);
            }
        }
    }
}
