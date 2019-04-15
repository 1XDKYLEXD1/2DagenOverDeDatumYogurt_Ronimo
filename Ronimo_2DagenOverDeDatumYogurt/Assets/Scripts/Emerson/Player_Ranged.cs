using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerBehavior
{
    walking = 0,
    attacking,
    waiting
}

public class Player_Ranged : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 30f)]
    private float m_Raylength;
    private float m_Timer = 1.0f;


    public int health = 5;

    public bool m_Walking;

    private RaycastHit m_hit;

    public GameObject m_Enemy;
    public GameObject m_Bullet;
    public Transform m_FirePoint;

    public int speed;

    [SerializeField] private PlayerBehavior state;

    // Start is called before the first frame update
    void Start()
    {
        state = PlayerBehavior.walking;
        gameObject.layer = LayerMask.NameToLayer("Player");
        m_Walking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Walking == true)
        {
            transform.position += transform.right * +speed * Time.deltaTime;
        }

        if (m_Timer == 0 || m_Timer < 0)
        {
            m_Timer = 1;
        }
        int layermask = 1 << 10; //Enemy Layer into layermask


        Vector3 _right = m_Enemy.transform.TransformDirection(Vector3.right);
        //raycast 
        bool result = Physics.Raycast(transform.position, _right, out m_hit, m_Raylength, layermask);

        if (result == true && m_hit.transform.CompareTag("Player"))
        {
            state = PlayerBehavior.waiting;
            Debug.Log("beep");
        }

        if (state == PlayerBehavior.walking)
        {
            if (result == true)
            {
                Debug.DrawRay(transform.position, _right * m_Raylength, Color.red);
                //check hit raycast
                print("tag is: " + m_hit.transform.tag + " name: " + m_hit.transform.name);

                if (m_hit.transform.CompareTag("Enemy"))
                {
                    state = PlayerBehavior.attacking;
                }
            }


            m_Walking = true;
        }
        else if (state == PlayerBehavior.attacking)
        {
            m_Walking = false;

            print("collided: " + result);

            if (result == false)
            {
                state = PlayerBehavior.walking;
            }
            else
            {
                IsAttacking();
            }
        }
        else if (state == PlayerBehavior.waiting)
        {
            m_Walking = false;

            print("collided: " + result);

            if (result == false)
            {
                state = PlayerBehavior.walking;
            }
            else
            {
                state = PlayerBehavior.waiting;
            }
        }
    }

    //attacking
    private void IsAttacking()
    {
        m_Timer -= Time.deltaTime;

        if (m_Timer <= 0)
        {
            GameObject go = Instantiate(m_Bullet, m_FirePoint.position, m_FirePoint.rotation);
            go.layer = LayerMask.NameToLayer("PlayerProjectiles");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
