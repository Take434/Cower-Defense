using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowTowerScript : MonoBehaviour
{
  private List<GameObject> enemies;
  private double a;
  public BaseTower tower;
  private GameState gameState;

  CowTowerScript()
  {
    tower = new CowTower();
  }
  // Start is called before the first frame update
  void Start()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        enemies = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>().enemies;
        a = gameState.roundTime;
        tower.gameState = GameObject.Find("GameState");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.roundTime >= a)
        {
            if (tower.Attack(enemies, gameObject))
            {
                a += tower.AttackSpeed;
            }
            a += Time.deltaTime;
        }
    }
}
