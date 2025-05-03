using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabRat : MonoBehaviour
{

    SpriteRenderer m_SpriteRenderer;

    Rigidbody2D m_rigidBody;

    private int leftDir = -1;
    private int rightDir = 1;

    private int curDir = -1;
    public int speed;


    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (curDir == -1)
        {
            m_SpriteRenderer.flipX = false;
        }
        else
        {
            m_SpriteRenderer.flipX = true;
        }
        transform.position += Vector3.right * speed * curDir * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OtherEnemy" || collision.gameObject.tag == "LabRat"
            || collision.gameObject.tag == "Player" || collision.gameObject.tag == "EnemyStudent"
            || collision.gameObject.tag == "Wall")
        {
            if (curDir == -1)
            {
                curDir = 1;
            }
            else
            {
                curDir = -1;
            }
        }
    }
}
