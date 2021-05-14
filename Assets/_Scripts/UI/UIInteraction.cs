using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Inputs.Selection;

namespace Swatantra.UI
{
    public class UIInteraction : MonoBehaviour
    {

        [SerializeField] bool CharacterSelectionButton;
        [SerializeField] MovementSystems.Movement character;

        public void OnPointerClick()
        {
            if (CharacterSelectionButton)
            {
                Events.EventManager.OnCurrentCharacterSelection.Invoke(character);
            }
        }

        public void OnPointerEnter()
        {
            if (CharacterSelectionButton)
                character.GetComponent<SelectableObject>().OnHover();
        }

        public void OnPointerExit()
        {
            if (CharacterSelectionButton)
                character.GetComponent<SelectableObject>().OnHoverExit();
        }

    }

}
  

