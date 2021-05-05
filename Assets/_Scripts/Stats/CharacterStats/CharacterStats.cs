using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Swatantra.Stats.characterStats
{
    public class CharacterStats : MonoBehaviour
    {
        public CharacterStats_SO CharacterDefinition;

        private void Start()
        {
            CharacterDefinition = Instantiate(CharacterDefinition);
        }
    }
}