using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject tankPrefab;
    public float timeDuration;
    private float countdown;
    public int health = 1;

    private void Awake()
    {
        countdown = timeDuration;
    }
    private void Update()
    {

        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            Instantiate(tankPrefab, new Vector3(Random.Range(-2, 2), 5, 0), Quaternion.identity);
            countdown = timeDuration;
        }
    }
    public void TakenDamage(int damage)
    {
        health -= damage;
        if ( health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(tankPrefab);
    }
}
