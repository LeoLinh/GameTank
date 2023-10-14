using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
