using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUIScript : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount;
    public EnemyHealthPointScript enemyHP;
    // Start is called before the first frame update
    void Start()
    {
        enemyHP = GetComponent<EnemyHealthPointScript>();
    }

    public void IncreaseHealthBar()
    {
        healthAmount = enemyHP.currentHealth;
        healthBar.fillAmount = (healthAmount / 30f);
    }
    private void Update()
    {
        IncreaseHealthBar();
    }
}
