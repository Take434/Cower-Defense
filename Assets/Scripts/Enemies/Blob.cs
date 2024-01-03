public class Blob : BaseEnemy {
  void Start() {
    float moveSpeed = 7.5f;
    float attackTimeout = 0.75f;
    float attackDamage = 7.5f;
    float health = 30f;
    float armor = 20f;
    Setup(moveSpeed, attackTimeout, attackDamage, health, armor);
  }
}
