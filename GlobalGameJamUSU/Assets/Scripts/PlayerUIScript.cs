using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIScript : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount;
    private PlayerHealthPointScript playerHP;
    public TextMeshProUGUI playerHPValueText;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = GetComponent<PlayerHealthPointScript>();
    }

    public void IncreaseHealthBar()
    {
        healthAmount = playerHP.currentHealth;
        healthBar.fillAmount = (healthAmount / 30f);
        playerHPValueText.text = (30 - playerHP.currentHealth).ToString();
    }

    private void Update()
    {
        IncreaseHealthBar();
    }
}
