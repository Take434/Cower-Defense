using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public int health = 250;
    public int maxHealth = 250;
    public TextMeshProUGUI dispalyHealth;
    public Image healthBar;

    private float step;
    private Sprite[] healthStates;

    // Start is called before the first frame update
    void Start()
    {
        healthStates = UnityEngine.Resources.LoadAll<Sprite>("Sprites/Healthbar/");

        step = maxHealth / 8;
        TakeDamage(0);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        dispalyHealth.text = health.ToString() + " / " + maxHealth.ToString();
        healthBar.sprite = healthStates[Mathf.Min(8 - Mathf.CeilToInt(health / step), 8)];
    }
}
