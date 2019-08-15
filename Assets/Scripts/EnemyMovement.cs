using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 10f; //enemy speed
    private Transform target;
    private int waypointIndex = 0;

   

    void Start()
    {
        target = WayPoints.wayPoints[0];
    }

    void Update ()
    {
        Vector3 dir = target.position - transform.position; //direction vector
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //translate towards the target at a normalized speed

        if (Vector3.Distance(transform.position, target.position) < 0.2 )
            {
            FetchNextWayPoint();
            }
    }

    void FetchNextWayPoint()
    {
        if (waypointIndex >= WayPoints.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = WayPoints.wayPoints[waypointIndex];
    }
}

