using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabRatOrange : MonoBehaviour
{

    public GameObject labRat;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (labRat == null)
        {
            Destroy(gameObject);

        }
        else
        {
            transform.position = labRat.transform.position + new Vector3(0, 0.5f, 0);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MainStudent.oranges = MainStudent.oranges + 1;
            
            Destroy(gameObject);
        }
    }
}
