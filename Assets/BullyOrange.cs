using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyOrange : MonoBehaviour
{


    int frames;
    // Start is called before the first frame update
    void Start()
    {
        frames = 0;
        foreach (var b in GameObject.FindGameObjectsWithTag("Orangebackpack"))
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), b.GetComponent<BoxCollider2D>(), true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frames++;
        if (frames >= 120)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            MainStudent.oranges = MainStudent.oranges + 1;
            Destroy(gameObject);
        }
    }
}
