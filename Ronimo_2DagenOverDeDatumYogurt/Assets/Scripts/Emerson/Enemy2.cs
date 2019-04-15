using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 30f)]
    private float m_Raylength;
    public float m_Timer = 1.0f;

    private bool m_Walking;
    public int health = 5;

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
        gameObject.layer = LayerMask.NameToLayer("Enemy");
        m_Walking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Walking == true)
        {
            transform.position += transform.right * +speed * Time.deltaTime;
        }



        int layermask = 1 << 9; //Enemy Layer into layermask


        Vector3 _right = m_Enemy.transform.TransformDirection(Vector3.right);
        //raycast 
        bool result = Physics.Raycast(transform.position, _right, out m_hit, m_Raylength, layermask);
        Debug.DrawRay(transform.position, _right * m_Raylength, Color.red);



        if (state == PlayerBehavior.walking)
        {
            if (result == true)
            {
                //check hit raycast
                print("tag is: " + m_hit.transform.tag + " name: " + m_hit.transform.name);

                if (m_hit.transform.CompareTag("Player"))
                {
                    state = PlayerBehavior.attacking;
                }
                else if (m_hit.transform.CompareTag("Enemy") && m_Raylength < 1)
                {
                    state = PlayerBehavior.waiting;
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
        }
    }

    //attacking
    private void IsAttacking()
    {

        m_Timer -= Time.deltaTime;

        if (m_Timer <= 0)
        {
            GameObject go = Instantiate(m_Bullet, m_FirePoint.position, m_FirePoint.rotation);
            go.layer = LayerMask.NameToLayer("EnemyProjectiles");
            if (m_Timer == 0 || m_Timer < 0)
            {
                m_Timer = 1;
            }
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
