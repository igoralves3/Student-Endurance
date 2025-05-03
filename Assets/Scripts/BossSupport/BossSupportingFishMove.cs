using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSupportingFishMove : MonoBehaviour
{


    SpriteRenderer m_SpriteRenderer;

    Rigidbody2D m_rigidBody;

    public int health, speed, damage;

    public float force = 10;
    public float groundForce = 2;
    private bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();

        var grounds = GameObject.FindGameObjectsWithTag("Ground");
        foreach (var g in grounds) {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), g.GetComponent<BoxCollider2D>(), true);
        }
        foreach (var g in GameObject.FindGameObjectsWithTag("EnemyStudent"))
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), g.GetComponent<BoxCollider2D>(), true);
        }
        foreach (var g in GameObject.FindGameObjectsWithTag("OrangeItem"))
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), g.GetComponent<BoxCollider2D>(), true);
        }
        foreach (var g in GameObject.FindGameObjectsWithTag("OtherEnemy"))
        {
            if (g != this) {
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), g.GetComponent<BoxCollider2D>(), true);
            }
        }
        var water = GameObject.FindWithTag("DeepWater");
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), water.GetComponent<BoxCollider2D>(), true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
        if (m_rigidBody.velocity.y >= 0)
        {
            m_SpriteRenderer.flipY = false;
        }
        else
        {
            m_SpriteRenderer.flipY = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Orange")
        {
            
            Destroy(gameObject);
            
        }else if (collision.gameObject.tag == "EnemyStudent")
        {

            Destroy(gameObject);

        }
        else if (collision.gameObject.tag == "Player")
        {

            attacking = true;
        }
       
    }
}
