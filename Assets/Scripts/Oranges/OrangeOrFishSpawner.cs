using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeOrFishSpawner : MonoBehaviour
{

    private int frames;
    public GameObject orange;
    public GameObject peixe;

    // Start is called before the first frame update
    void Start()
    {
        frames = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frames++;
        if (frames >= 180)
        {
            frames = 0;

            var newX = Random.Range(-5,5);
            var newY = transform.position.y;
            var newPosition = new Vector3(newX, newY, 1);
            var itemGerado = Random.Range(0,11);
            if (itemGerado <= 7) {
                var novaLaranja = Instantiate(orange, newPosition, transform.rotation) as GameObject;
               
                novaLaranja.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            }
            else
            {
                var novoPeixe = Instantiate(peixe, newPosition, transform.rotation) as GameObject;
                
                novoPeixe.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            }
        }
    }
}
