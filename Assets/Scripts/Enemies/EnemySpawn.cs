using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private List<GameObject> possibleEnemies;
    private GridController gridController;
    private GameObject healthBar;
    private GameState gameState;
    float a = 0.5f;
    void Start()
    {
        healthBar = UnityEngine.Resources.Load("Prefabs/healthbar") as GameObject;
        possibleEnemies = UnityEngine.Resources.LoadAll("Prefabs/enemies").Cast<GameObject>().ToList();
        gridController = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>();
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= a) {
            a += UnityEngine.Random.Range(5f, 7f);

            if(GameStateEnum.PLAYING != gameState.state) {
                return;
            }

            GameObject enemyPrefab = possibleEnemies[UnityEngine.Random.Range(0, possibleEnemies.Count)];
            GameObject instance = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0, 0, 0));
            GameObject healthBar = Instantiate(this.healthBar, instance.transform.position, Quaternion.Euler(90, 0, 0));
            healthBar.transform.SetParent(instance.transform);
            instance.GetComponent<BaseEnemy>().healthbar = healthBar;

            gridController.enemies.Add(instance);
        }
    }
}
