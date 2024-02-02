using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private Dictionary<float, GameObject> possibleEnemies;
    private GridController gridController;
    private GameObject healthBar;
    private GameState gameState;
    private float roundLength;
    private float roundTime;
    private int difficultyModifier;
    private List<GameObject> enemiesToSpawn = new List<GameObject>();
    private float spawnOffset = 0.5f;
    private float a = 0.5f;

    private float[][] spawnPatterns = new[] {
        new [] {0.2f, 0.2f, 0.2f, 0.2f, 0.2f},
        new [] {0.8f, 0.2f},
        new [] {0.2f, 0.8f},
        new [] {0.4f, 0.4f, 0.2f},
    };

    private Vector2Int currentSpawnPattern = new Vector2Int(0, 0);

    void Start()
    {
        healthBar = UnityEngine.Resources.Load("Prefabs/healthbar") as GameObject;
        possibleEnemies = UnityEngine.Resources.LoadAll("Prefabs/enemies").Cast<GameObject>()
                            .ToDictionary(a => a.GetComponent<BaseEnemy>().difficultyRating);
        gridController = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>();
        gameState = GameObject.Find("GameState").GetComponent<GameState>();

        roundTime = 0;
        roundLength = RoundLength();
        difficultyModifier = DifficultyModifier();
        currentSpawnPattern = new Vector2Int(UnityEngine.Random.Range(0, spawnPatterns.Length), 0);
    }

    void Update()
    {
        if (GameStateEnum.PLAYING != gameState.state)
        {
            return;
        }

        if (currentSpawnPattern.y >= spawnPatterns[currentSpawnPattern.x].Length && gridController.enemies.Count == 0 && enemiesToSpawn.Count == 0)
        {
            gameState.RoundFinished();
            spawnOffset = Mathf.Min(0.5f, Mathf.Max(0.1f, 4f / gameState.Round));
            Debug.Log(spawnOffset);
            roundTime = 0;
            roundLength = RoundLength();
            difficultyModifier = DifficultyModifier();
            currentSpawnPattern = new Vector2Int(UnityEngine.Random.Range(0, spawnPatterns.Length), 0);
            return;
        }

        if (roundTime <= 0 && currentSpawnPattern.y < spawnPatterns[currentSpawnPattern.x].Length)
        {
            Spawn();
            roundTime += roundLength * spawnPatterns[currentSpawnPattern.x][currentSpawnPattern.y];
            currentSpawnPattern.y++;
        }

        if(enemiesToSpawn.Count > 0 && Time.time > a) 
        {
            GameObject enemyPrefab = enemiesToSpawn[0];
            enemiesToSpawn.RemoveAt(0);
            SpawnEnemy(enemyPrefab);
            a = Time.time + spawnOffset;
        }

        roundTime -= Time.deltaTime;
    }

    private void Spawn() 
    {
        int difficultyLeft = (int)Mathf.Ceil(difficultyModifier * spawnPatterns[currentSpawnPattern.x][currentSpawnPattern.y]);

        while(difficultyLeft >= 1) 
        {
            int difficulty = UnityEngine.Random.Range(0, difficultyLeft - 1) % possibleEnemies.Count + 1;
            difficultyLeft -= difficulty;
            enemiesToSpawn.Add(possibleEnemies[difficulty]);
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        if (GameStateEnum.PLAYING != gameState.state)
        {
            return;
        }

        GameObject instance = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        GameObject healthBar = Instantiate(this.healthBar, instance.transform.position, Quaternion.Euler(0, 0, 0));
        healthBar.transform.SetParent(instance.transform);
        instance.GetComponent<BaseEnemy>().healthbar = healthBar;

        gridController.enemies.Add(instance);
    }

    private int DifficultyModifier() 
    {
        return (int)Mathf.Ceil(0.1f * Mathf.Pow(gameState.Round, 0.8f * 2.71828f) + 3);
    }

    private float RoundLength()
    {
        return roundLength + 0.5f;
    }
}
