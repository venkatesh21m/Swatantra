using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Swatantra.Stats.characterStats
{
    [CreateAssetMenu(fileName = "character stats", menuName = "Swatantra/stats/character stats", order = 1)]
    public class CharacterStats_SO : ScriptableObject
    {
        // Holds the data of every single stat information of the character.

        /// <summary>
        /// Name of the Character
        /// </summary>
        [Header("Name")]
        public string CharacterName;

        /// <summary>
        /// Gender of the character
        /// </summary>
        [Header("Gender")]
        [Tooltip("The Gender of the Character")]
        public Gender gender;

        /// <summary>
        /// for Health
        /// </summary>
        [Header("Health")]
        [Tooltip("The max Health of the Character")]
        public float MaxHealth;
        [Tooltip("The current Health of the Character")]
        public float currentHealth;

        /// <summary>
        /// for stamina
        /// </summary>
        [Header("Stamina")]
        [Tooltip("The max Stamina of the Character")]
        public float maxStamina;
        [Tooltip("The current Stamina of the Character")]
        public float CurrentStamina;

        /// <summary>
        /// for Damage
        /// </summary>
        [Header("Damage")]
        [Tooltip("The max Damage of the Character")]
        public float maxDamageAmount;
        [Tooltip("The current Damage of the Character")]
        public float currentDamageAmount;

        /// <summary>
        /// for defence
        /// </summary>
        [Header("Defence")]
        [Tooltip("The max Defence of the Character")]
        public float MaxDefence;
        [Tooltip("The current Defence of the Character")]
        public float currentDefence;



        /// <summary>
        /// for oxygen amount
        /// </summary>
        [Header("Oxygen")]
        [Tooltip("The max Oxygen Capacity of the Character")]
        public float MaxOxygen;
        [Tooltip("The current Oxygen amount of the Character")]
        public float currentOxygen;


        [Header("Wealth")]
        [Tooltip("The amount of money the Character has")]
        public float Wealth;


        /// <summary>
        /// basic stats
        /// </summary>
        [Header("Basic Stats")]
        [Tooltip("The Hunger value of the Character")]
        public float Hunger;
        [Tooltip("The thirst value of the Character")]
        public float thirst;
        [Tooltip("The Mood value of the Character")]
        public float Mood;

        /// <summary>
        /// effeciency of doing the work affected by the Mood
        /// </summary>
        [Space]
        [Tooltip("The Efficiency of doing the work by the Character")]
        public float Efficiency;

        /// <summary>
        /// Related to movement and exploration
        /// </summary>
        [Header("Exploration")]
        [Tooltip("How much speed the character should move")]
        public float movementSpeed;
        [Tooltip("How much far the character can see")]
        public float lineofSight;

        /// <summary>
        /// Related to shelter
        /// </summary>
        [Header("Shelter")]
        public bool sheltered;
        public string shelterID;

        [Header("Current Task")]
        public Task currentTask = Task.Idle;
    }


    [System.Serializable]
    public enum Gender
    {
        Male,
        Female
    }

    [System.Serializable]
    public enum Task
    {
        Idle,
        Building,
        Eating
    }
}