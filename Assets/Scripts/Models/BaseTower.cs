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
  public int ResourceLevel { get; set; }
  public int ResourceUpgradeCost { get; set; }
  public int OffenseUpgradeCost { get; set; }
  protected GameObject attackPrefab;

  public BaseTower(int OffenseLevel, int ResourceLevel, int Damage, double AttackSpeed, double Range, int Cost, Resources Resource, int ResourceYield)
  {
    this.OffenseLevel = OffenseLevel;
    this.ResourceLevel = ResourceLevel;
    this.Damage = Damage;
    this.AttackSpeed = AttackSpeed;
    this.Range = Range * 6;
    this.Cost = Cost;
    this.Resource = Resource;
    this.ResourceYield = ResourceYield;
    this.ResourceUpgradeCost = 25;
    this.OffenseUpgradeCost = 25;
  }

  public bool Attack(List<GameObject> enemies, GameObject towerGameObject)
  {
    GameObject closestEnemy = getClosestEnemy(enemies, towerGameObject);
    if (closestEnemy != null)
    {
      if(this.attackPrefab != null) {
        GameObject attack = GameObject.Instantiate(this.attackPrefab, towerGameObject.transform.position, quaternion.identity);
        attack.GetComponent<AttackScript>().target = closestEnemy.transform.position;
      }
      closestEnemy.GetComponent<BaseEnemy>().TakeDamage(this.Damage);
      return true;
    }
    return false;
  }

  public string GetResourceLevelUpPreview() {
    return "Resource yield: " + this.ResourceYield + " -> " + (this.ResourceYield + 1);
  }

  public string GetResourceLevelUpCost() {
    return this.ResourceUpgradeCost.ToString() + " $";
  }

  public string GetOffenseLevelUpPreview() {
    return "Damage: " + this.Damage + " -> " + (this.Damage + 1) + "\n" +
    "Attack speed: " + this.AttackSpeed + " -> " + (this.AttackSpeed - 0.1) + "\n" +
    "Range: " + this.Range + " -> " + (this.Range + 0.1);
  }

  public string GetOffenseLevelUpCost() {
    return this.OffenseUpgradeCost.ToString() + " $";
  }

  public void UpgradeResourceLevel() {
    this.ResourceYield += 1;
    this.ResourceLevel += 1;
    this.ResourceUpgradeCost += 25;
  }

  public void UpgradeOffenseLevel() {
    this.Damage += 1;
    this.AttackSpeed -= 0.1;
    this.Range += 0.1;
    this.OffenseLevel += 1;
    this.OffenseUpgradeCost += 25;
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
      if (distance < closestDistance && distance <= this.Range)
      {
        closestDistance = distance;
        closestEnemy = enemy;
      }
    }
    return closestEnemy;
  }
}
