using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeFall : MonoBehaviour
{
    private int frames;
    public GameObject orange;

    // Start is called before the first frame update
    void Start()
    {
        frames = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frames++;
        if (frames >= 60)
        {
            frames = 0;

            var newX = Random.Range(transform.position.x - 10, transform.position.x + 10);
            var newY = transform.position.y;
            var newPosition = new Vector3(newX, newY, 0);
            var novaLaranja = Instantiate(orange, newPosition, transform.rotation) as GameObject;
            var gravity = 300;
            novaLaranja.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, gravity));
        }
    }

    

}
