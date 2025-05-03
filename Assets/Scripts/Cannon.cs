using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject apple;
    int frames = 0;

    int curDir = -1;

    // Start is called before the first frame update
    void Start()
    {
        frames = 0;
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if (frames >= 120)
        {
            frames = 0;
            var newPosition = transform.position + new Vector3(curDir, 0, 0);
            var novaMaca = Instantiate(apple, newPosition, transform.rotation) as GameObject;
            var range = curDir * 300;
            novaMaca.GetComponent<Rigidbody2D>().AddForce(new Vector2(range, 0));
        }
    }
}
