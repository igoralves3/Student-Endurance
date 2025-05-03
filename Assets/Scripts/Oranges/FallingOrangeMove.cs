using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingOrangeMove : MonoBehaviour
{

    private int destroyFrames = 0;
    private bool canDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        destroyFrames = 0;
        canDestroy = false;
    }

   
    void FixedUpdate()
    {
        if (canDestroy)
        {
            destroyFrames++;
            if (destroyFrames >= 60)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.tag == "Ground") {
            canDestroy = true;
            //Destroy(this.gameObject,1f);
        }else if (collision.gameObject.tag == "EnemyStudent")
        {
            Destroy(this.gameObject);
        }
        
    }
}
