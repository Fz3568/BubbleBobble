using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameObject DropObj;
    public GameObject DeadObj;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drop()
    {
        if (DropObj != null)
        {
            Instantiate(DropObj, transform.position, Quaternion.identity);
        }
        if (DeadObj != null)
        {
            Destroy(Instantiate(DeadObj, transform.position, Quaternion.identity), 5f);
            
        }
        Destroy(gameObject);
    }
}
