using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints = new Transform[15];
    [SerializeField] private float moveSpeed = 2f;
    private int wayPointIndex = 0;

    void Start()
    {
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
        }
    }
}
