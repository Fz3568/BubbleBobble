using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject SpriteObj;
    public ParticleSystem Particles;

    Rigidbody2D rb;
    public int Direction;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(new Vector3(Speed * Direction * Time.deltaTime, 0) + transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyDrop>().Drop();
        }
        
        Destroy(SpriteObj);
        gameObject.GetComponent<Collider2D>().enabled = false;
        Speed = 0;
        Particles.Play();
        Destroy(gameObject, 0.4f);
    }
}
