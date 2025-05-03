using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPoo : MonoBehaviour
{

    int frames;

    // Start is called before the first frame update
    void Start()
    {
        frames = 0;
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
}
