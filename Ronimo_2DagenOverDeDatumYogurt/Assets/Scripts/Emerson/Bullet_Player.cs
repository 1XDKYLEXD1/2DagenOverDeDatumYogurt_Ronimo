using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Player : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody rb;
    //List<Collider> colliders = new List<Collider>();
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
