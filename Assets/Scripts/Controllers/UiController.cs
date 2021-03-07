using System;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class UiController : BaseGamerController
    {
        [SerializeField] private Image abilityImage = null;
        [SerializeField] private TextMeshProUGUI abilityText = null;
        
        private void Start()
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAbilityComponent>().AbilityEquippedEvent += UpdateAbilityUI;
        }

        private void UpdateAbilityUI(IAbility ability)
        {
            if (ability == null)
            {
                ResetAbilityInfo();
                return;
            }

            var data = ability.GetAbilityData();
            abilityImage.sprite = data.abilitySprite;
            abilityText.text = data.abilityName;
        }

        private void ResetAbilityInfo()
        {
            abilityImage.sprite = null;
            abilityText.text = string.Empty;
        }
    }
}
