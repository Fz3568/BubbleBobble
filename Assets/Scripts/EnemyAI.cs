using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 400f;
    public float nextWaypointD = 4f;

    public Transform enemyFX;

    Path path;
    int waypointCurrent = 0;
    bool endReached = false;

    Seeker seeker;
    Rigidbody2D rb;


    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .25f);

    }

    void UpdatePath()
    {
        if (target == null)
            return;
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            waypointCurrent = 0;
        }
    }

    void Update()
    {
        if (target == null)
            return;
        
        if (path == null)
            return;

        if (waypointCurrent >= path.vectorPath.Count)
        {
            endReached = true;
            return;
        }
        else
        {
            endReached = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[waypointCurrent] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[waypointCurrent]);

        if (distance < nextWaypointD)
        {
            waypointCurrent++;
        }

        if (rb.velocity.x >= 0.01f)
        {
            enemyFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x <= -0.0f)
        {
            enemyFX.localScale = new Vector3(1f, 1f, 1f);
        }

    }


}
