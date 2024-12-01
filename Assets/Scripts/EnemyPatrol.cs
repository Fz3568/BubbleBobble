using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Initalizing Variables
    public GameObject pA;
    public GameObject pB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        // Setting rb to objects Rigidbody and making current point equal to pB's transform
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pB.transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;


        if (currentPoint == pB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pB.transform)
        {
            flip();
            currentPoint = pA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pA.transform)
        {
            flip();
            currentPoint = pB.transform;
        }
    }

    private void flip ()
    {
        Vector3 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pB.transform.position, 0.5f);
        Gizmos.DrawLine(pA.transform.position, pB.transform.position);
    }
}
