using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMove : MonoBehaviour
{
    public int minDelta = -50;
    public int maxDelta = 50;
    public int curDelta = 0;

    public Transform player;

    int frames = 0;
    public int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        curDelta = 0;
        minDelta = -50;
        maxDelta = 50;
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if (frames >= 60) {
            frames = 0;
            var sorteioLado = Random.Range(1, 10);
            if (sorteioLado <= 5)
            {
                var delta = Random.Range(1, 50);
                if (curDelta - delta >= minDelta)
                {
                    curDelta -= delta;
                    transform.position -= Vector3.right * speed * delta * Time.deltaTime;
                }
            } else
            {
                var delta = Random.Range(1, 50);
                if (curDelta + delta <= maxDelta)
                {
                    curDelta += delta;
                    transform.position += Vector3.right * speed * delta * Time.deltaTime;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            transform.position = new Vector3(col.transform.position.x,transform.position.y,col.transform.position.z);
        }
    }
}
