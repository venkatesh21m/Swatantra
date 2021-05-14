using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Swatantra.UI
{
    public class HoveredCharacterDetailsShower : MonoBehaviour
    {
        #region References
       
        [SerializeField] TMP_Text CharacterName;
        [SerializeField] TMP_Text CharacterRank;

        [SerializeField] TMP_Text Health;
        [SerializeField] TMP_Text Stamina;
        [SerializeField] TMP_Text Wealth;
        [Space]
        [SerializeField] Image GenderIcon;

        #endregion

        #region Default unity events
        private void Start()
        {
            Events.EventManager.OnHoverOnCharacterEvent.AddListener(ShowCharacterDetails);
            Events.EventManager.onHoverExitOnCharacterEvent.AddListener(DisableCharacterDetails);
            //    if(gameObject.activeSelf)
            //        gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            Events.EventManager.OnHoverOnCharacterEvent.RemoveListener(ShowCharacterDetails);
            Events.EventManager.onHoverExitOnCharacterEvent.RemoveListener(DisableCharacterDetails);
        }

        #endregion

        #region enable and disable Methods
        void ShowCharacterDetails(Stats.characterStats.CharacterStats_SO characterDetails)
        {
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);

            SetCharacterName(characterDetails.CharacterName);
            SetCharacterGender(characterDetails.gender);
            SetCharacterHealth(characterDetails.currentHealth.ToString());
            SetCharacterStamina(characterDetails.CurrentStamina.ToString());
            SetCharacterWealth(characterDetails.Wealth.ToString());
        }

        private void DisableCharacterDetails()
        {
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
        }

        #endregion

        #region individual detail setter methods

        void SetCharacterName(string name)
        {
            CharacterName.text = name;
        }
        void SetCharacterHealth(string health)
        {
            Health.text = "Health :" + health;
        }
        void SetCharacterStamina(string stamina)
        {
            Stamina.text = "Stamina :" + stamina;
        }
        void SetCharacterWealth(string wealth)
        {
            Wealth.text = "Wealth :" + wealth;
        }

        void SetCharacterGender(Stats.characterStats.Gender gender)
        {
            switch (gender)
            {
                case Stats.characterStats.Gender.Male:
                    GenderIcon.color = Color.cyan;
                    break;
                case Stats.characterStats.Gender.Female:
                    GenderIcon.color = Color.magenta;
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
