using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public int health = 250;
    public int maxHealth = 250;
    public TextMeshProUGUI displayHealth;
    public Image healthBar;
    public AudioSource dmgSound;

    private float step;
    private Sprite[] healthStates;
    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        healthStates = UnityEngine.Resources.LoadAll<Sprite>("Sprites/Healthbar/");
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        step = maxHealth / 8;
        TakeDamage(0);
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Max(health - damage, 0);
        if (health == 0)
        {
            gameState.GameOver();
        }

        if(damage > 0) {
            dmgSound.Play();
            Camera.main.GetComponent<ScreenShake>().shakeTime = 0.5f;
        }
        displayHealth.text = health.ToString() + " / " + maxHealth.ToString();
        healthBar.sprite = healthStates[Mathf.Clamp(8 - Mathf.CeilToInt(health / step), 0, 8)];
    }
}
