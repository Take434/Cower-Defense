public class ChickenTower : BaseTower
{

  public ChickenTower() : base(1, 1, 7, 1, 6, 17, Resources.Eggs, 1, true)
  {

  }

  public void LevelUpOffense()
  {
    this.OffenseLevel++;
    this.Damage = this.Damage + this.OffenseLevel * 3;
  }

  public void LevelUpRessource()
  {
    this.ResourceLevel++;
    this.ResourceYield++;
  }
}