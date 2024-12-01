using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpScript : MonoBehaviour
{
    public float RiseY;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") && LevelTransitionStart.isInTransition == false) || collision.gameObject.layer == 8)
        {
            collision.gameObject.transform.position = gameObject.transform.position + new Vector3(0, RiseY, 0);
        }
    }
}
