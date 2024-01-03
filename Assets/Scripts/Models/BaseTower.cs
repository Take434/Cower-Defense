public class BaseTower
{
  public int Level { get; set; }
  public int Damage { get; set; }
  public double AttackSpeed { get; set; }
  public double Range { get; set; }
  public int Cost { get; set; }
  public Resources Resource { get; set;}
  public int ResourceYield { get; set;}
  public bool isAoe { get; set; }
  
  public BaseTower(int Level, int Damage, double AttackSpeed, double Range, int Cost, Resources Resource, int ResourceYield, bool isAoe) {
    this.Level = Level;
    this.Damage = Damage;
    this.AttackSpeed = AttackSpeed;
    this.Range = Range;
    this.Cost = Cost;
    this.Resource = Resource;
    this.ResourceYield = ResourceYield;
  }
}