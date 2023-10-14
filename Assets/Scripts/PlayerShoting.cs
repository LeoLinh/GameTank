using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoting : MonoBehaviour
{
    
    public float bulletSpeed = 10f; 

    void Update()
    {
      
    }

    private void Start()
    {
        Destroy(gameObject, 3);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            LevelManager.instance.AddScore(1);
            
        }

    }
}
