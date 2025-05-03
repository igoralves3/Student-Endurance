using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppingOrangeMove : MonoBehaviour
{
    private int destroyFrames = 0;
    private bool canDestroy = false;

    private int canDestroyNow = 0;
    // Start is called before the first frame update
    void Start()
    {
        destroyFrames = 0;
        canDestroyNow = 0;
        canDestroy = false;
        foreach (var e in GameObject.FindGameObjectsWithTag("EnemyStudent"))
        {
            Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), e.GetComponent<BoxCollider2D>());
        }
        foreach (var e in GameObject.FindGameObjectsWithTag("OtherEnemy"))
        {
            Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), e.GetComponent<BoxCollider2D>());
        }
        foreach (var e in GameObject.FindGameObjectsWithTag("OrangeItem"))
        {
            Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), e.GetComponent<BoxCollider2D>());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canDestroyNow >= 2)
        {
            destroyFrames++;
            if (destroyFrames >= 60)
            {
                Destroy(this.gameObject);
            }
        }

        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //if (canDestroy) {
            //  Destroy(this.gameObject, 1f);
            //}
            //else
            //{
            //canDestroy = true;
            //}
            canDestroyNow++;
        }
        else if (collision.gameObject.tag == "EnemyStudent")
        {
            Destroy(this.gameObject);
        }

    }
}
