using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    private Vector2 Velocity;
    private Rigidbody2D rb;
    public float speed;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 pos = new Vector2(x, y);
        Velocity = pos.normalized * speed;


        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void FixedUpdate()
    {
        Vector2 rbPos = rb.position;
        rbPos += Velocity * Time.fixedDeltaTime;
        Vector2 leftEdge = Camera.main.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        rbPos.x = Mathf.Clamp(rbPos.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);
        rbPos.y = Mathf.Clamp(rbPos.y, leftEdge.y + 0.5f, rightEdge.y - 0.5f);
        rb.MovePosition(rbPos);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            LevelManager.instance.gameOverPanel.SetActive(true);
        }
    }
}
