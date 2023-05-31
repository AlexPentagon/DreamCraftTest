using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealth : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] Image healthBar;

    private void Start()
    {
        playerHealth.OnDamaged += UpdateUI;
    }

    private void UpdateUI()
    {
        healthBar.fillAmount = playerHealth.CurrentHealth / (float)playerHealth.MaxHealth;
    }
}
