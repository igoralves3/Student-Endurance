using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    Rigidbody2D m_rigidBody;

    public GameObject poo;

    public int health, speed, damage;

    int curDir = 1;
    int steps = 0;

    bool canDrop;
    int waitDrop = 0;


    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        steps += curDir;
        if (steps < -180 || steps > 180)
        {
            curDir = -curDir;
            m_SpriteRenderer.flipX = !m_SpriteRenderer.flipX;
        }
        if (Random.Range(1,11) >= 4) {
            if (canDrop)
            {
                canDrop = false;
                waitDrop = 0;
                var newX = transform.position.x+curDir;
                var newY = transform.position.y;
                var newPosition = new Vector3(newX, newY, 0);
                var novoPoo = Instantiate(poo, newPosition, transform.rotation) as GameObject;
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(),novoPoo.GetComponent<BoxCollider2D>(),true);
            }
            else
            {
                waitDrop++;
                if (waitDrop >= 120)
                {
                    canDrop = true;
                }
            }
        }
        transform.position -= Vector3.right * speed * curDir * Time.deltaTime;
    }

    void OnColllisionEnter(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            curDir = -curDir;
            m_SpriteRenderer.flipX = !m_SpriteRenderer.flipX;
        }
        else if (collision.gameObject.tag == "Orange")
        {

            Destroy(gameObject);

        }
    }
}
