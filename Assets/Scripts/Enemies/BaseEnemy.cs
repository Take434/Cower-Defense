using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour
{
  //stats
  public float moveSpeed;
  public float attackTimeout;
  public float attackDamage;
  private float maxHealth;
  public float health;
  public float difficultyRating;
  public float healthFactor;
  public float speedFactor;
  public float healthCapFactor;
  public float speedCapFactor;

  //internal

  public GameObject healthbar;
  private Transform[] waypoints = new Transform[15];
  [SerializeField] private Animator animator;
  private int wayPointIndex = 0;
  private bool isAttacking = false;
  private float nextAttack = 0f;
  private FarmManager farmManager;
  private GridController gridController;
  private GameState gameState;

  public void Start()
  {
    gameState = GameObject.Find("GameState").GetComponent<GameState>();


    health *= Mathf.Min(1 + (gameState.Round * healthFactor), healthCapFactor);
    moveSpeed *= Mathf.Min(1 + (gameState.Round * speedFactor), speedCapFactor);

    maxHealth = health;

    gridController = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>();

    farmManager = GameObject.Find("UI Canvas").GetComponent<FarmManager>();

    for(int i = 0; i < waypoints.Length; i++)
    {
        waypoints[i] = GameObject.Find("Waypoint  (" + i + ")").transform;
    }

    if (waypoints.Length > 0)
    {
        transform.position = waypoints[wayPointIndex].position;
    }
  }

  protected void Update()
  {
    if(gameState.state == GameStateEnum.GAMEOVER || gameState.state == GameStateEnum.PAUSED) {
      return;
    }

    if(health <= 0) {
      gridController.enemies.Remove(gameObject);
      Destroy(gameObject);
    }

    if (isAttacking)
    {
      if(Time.time >= nextAttack) {
        nextAttack = Time.time + attackTimeout;
        Attack();
      }
    }
    else
    {
      Move();
    }
  }

  private void Move()
  {
    if (wayPointIndex < waypoints.Length)
    {
      transform.position = Vector3.MoveTowards(transform.position,
        waypoints[wayPointIndex].position,
        moveSpeed * Time.deltaTime);

      if (Vector3.Distance(transform.position, waypoints[wayPointIndex].position) < 0.001f)
      {
        wayPointIndex++;
      }
    } else {
      isAttacking = true;
    }
  }

  private void Attack() {
    animator.SetTrigger("playHit");

    farmManager.TakeDamage((int)attackDamage);
  }

  public void TakeDamage(float damage)
  {
    health -= damage;

    healthbar.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = health / maxHealth;
  }
}
