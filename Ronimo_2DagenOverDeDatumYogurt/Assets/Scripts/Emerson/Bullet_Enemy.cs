using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody rb;
    //List<Collider> colliders = new List<Collider>();
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * -speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_Melee enemy = collision.collider.GetComponent<Player_Melee>();
            Player_Ranged enemy2 = collision.collider.GetComponent<Player_Ranged>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            } else if (enemy2 != null)
            {
                enemy2.TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
