using Unity.VisualScripting;
using UnityEngine;

public class ChickenTower : BaseTower
{
  public ChickenTower() : base(1, 1, 7, 1, 6, 17, Resources.Eggs, 1)
  {
  }

  public void LevelUpOffense()
  {
    this.OffenseLevel++;
    this.Damage = this.Damage + this.OffenseLevel * 3;
  }

  // public void UpgradeResourceLevel()
  // {
  //   this.ResourceLevel++;
  //   this.ResourceYield++;
  // }
}
