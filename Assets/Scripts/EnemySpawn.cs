using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    int a = 0;

    // Update is called once per frame
    void Update()
    {
        if(a < 3) {
            GameObject instance = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(90, 0, 0));
            instance.GetComponent<EnemyMovement>().moveSpeed = Random.Range(1, 5);
            a++;
        }
    }
}
