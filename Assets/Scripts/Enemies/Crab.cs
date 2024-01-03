public class Crab : BaseEnemy {

  void Start() {
    float moveSpeed = 5f;
    float attackTimeout = 1f;
    float attackDamage = 2.5f;
    float health = 20f;
    float armor = 0f;
    Setup(moveSpeed, attackTimeout, attackDamage, health, armor);
  }

  
}
