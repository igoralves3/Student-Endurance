using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    int frames = 0;

    // Start is called before the first frame update
    void Start()
    {
        frames = 0;
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if (frames >= 300)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
