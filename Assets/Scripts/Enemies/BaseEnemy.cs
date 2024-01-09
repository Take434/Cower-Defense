using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
  //stats
  private float moveSpeed;
  private float attackTimeout;
  private float attackDamage;
  public float health;
  private float armor;

  //internal
  private Transform[] waypoints = new Transform[15];
  [SerializeField] private Animator animator;
  private int wayPointIndex = 0;
  private bool isAttacking = false;
  private float nextAttack = 0f;
  private FarmManager farmManager;

  public void Setup(float moveSpeed, float attackTimeout, float attackDamage, float health, float armor)
  {
    this.moveSpeed = moveSpeed;
    this.attackTimeout = attackTimeout;
    this.attackDamage = attackDamage;
    this.health = health;
    this.armor = armor;

    farmManager = GameObject.Find("UI Canvas").GetComponent<FarmManager>();

    for(int i = 0; i < waypoints.Length; i++)
    {
        waypoints[i] = GameObject.Find("Waypoint (" + i + ")").transform;
    }

    if (waypoints.Length > 0)
    {
        transform.position = waypoints[wayPointIndex].position;
    }
  }

  protected void Update()
  {
    if(health <= 0) {
      GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>().enemies.Remove(gameObject);
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
}
