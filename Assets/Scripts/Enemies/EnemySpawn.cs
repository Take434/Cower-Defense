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
    float a = 0.5f;
    void Start()
    {
        healthBar = UnityEngine.Resources.Load("prefabs/healthbar") as GameObject;
        possibleEnemies = UnityEngine.Resources.LoadAll("prefabs/enemies").Cast<GameObject>().ToList();
        gridController = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= a) {
            GameObject enemyPrefab = possibleEnemies[UnityEngine.Random.Range(0, possibleEnemies.Count)];
            GameObject instance = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(90, 0, 0));
            GameObject healthBar = Instantiate(this.healthBar, instance.transform.position, Quaternion.Euler(90, 0, 0));
            healthBar.transform.SetParent(instance.transform);

            gridController.enemies.Add(instance);
            a += UnityEngine.Random.Range(10f, 15f);
            //a += 1f;
        }
    }
}
