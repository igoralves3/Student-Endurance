using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "Player")
        {

            attacking = true;
        }
        else if (collision.gameObject.tag == "DeepWater" || collision.gameObject.tag == "ShallowWater")
        {

            m_rigidBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        } else if (collision.gameObject.tag == "Ground") {
            m_rigidBody.AddForce(Vector2.up * groundForce, ForceMode2D.Impulse);

        }
    }
}
