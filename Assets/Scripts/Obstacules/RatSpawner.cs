using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{

    public GameObject labRatOrange;
    public GameObject labRat;
    public GameObject sewerLabRat;
    private int frames = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frames++;
        if (frames >= 300)
        {
            frames = 0;
            var sorteio = Random.Range(1,10);
            if (sorteio >= 5)
            {
                var novoRato = Instantiate(labRat, new Vector3(transform.position.x,transform.position.y,0), transform.rotation) as GameObject;
                var novaLaranja = Instantiate(labRatOrange, new Vector3(transform.position.x, transform.position.y, 0) + new Vector3(0,0.5f,0), transform.rotation) as GameObject;
                novaLaranja.GetComponent<LabRatOrange>().labRat = novoRato;
            }
            else
            {
                var novoRato = Instantiate(sewerLabRat, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation) as GameObject;
            }
        }
    }
}
