using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BaseTower
{
  public int OffenseLevel { get; set; }
  public int Damage { get; set; }
  public double AttackSpeed { get; set; }
  public double Range { get; set; }
  public int Cost { get; set; }
  public Resources Resource { get; set; }
  public int ResourceYield { get; set; }
  public bool isAoe { get; set; }
  public int ResourceLevel { get; set; }

  public BaseTower(int OffenseLevel, int ResourceLevel, int Damage, double AttackSpeed, double Range, int Cost, Resources Resource, int ResourceYield, bool isAoe)
  {
    this.OffenseLevel = OffenseLevel;
    this.ResourceLevel = ResourceLevel;
    this.Damage = Damage;
    this.AttackSpeed = AttackSpeed;
    this.Range = Range * 6;
    this.Cost = Cost;
    this.Resource = Resource;
    this.ResourceYield = ResourceYield;
    this.isAoe = isAoe;
  }

  public bool Attack(List<GameObject> enemies, GameObject towerGameObject)
  {
    GameObject closestEnemy = getClosestEnemy(enemies, towerGameObject);
    if (closestEnemy != null)
    {
      closestEnemy.GetComponent<BaseEnemy>().health -= this.Damage;
      Debug.Log("Health:" + closestEnemy.GetComponent<BaseEnemy>().health);
      return true;
    }
    return false;
  }

  private GameObject getClosestEnemy(List<GameObject> enemies, GameObject towerGameObject)
  {
    GameObject closestEnemy = null;
    float closestDistance = Mathf.Infinity;
    Vector3 position = towerGameObject.transform.position;
    foreach (GameObject enemy in enemies)
    {
      Vector3 diff = enemy.transform.position - position;
      float distance = diff.sqrMagnitude;
      Debug.Log("distance: " + distance);
      if (distance < closestDistance && distance <= this.Range)
      {
        closestDistance = distance;
        closestEnemy = enemy;
      }
    }
    return closestEnemy;
  }
}