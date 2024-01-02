using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform[] waypoints = new Transform[15];
    public float moveSpeed = 2f;
    [SerializeField] private Animator animator;
    private int wayPointIndex = 0;

    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint").Select(x => x.transform).Reverse().ToArray();

        if (waypoints.Length > 0)
        {
            transform.position = waypoints[wayPointIndex].position;
        }
    }

    void Update()
    {
        Move();
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
            animator.SetTrigger("playHit");
        }
    }
}
