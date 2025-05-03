using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerBag : MonoBehaviour
{

    public GameObject partner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var newX = transform.position.x;
            var newY = transform.position.y;
            var newPosition = new Vector3(newX, newY, 0);
            var parceiroNovo = Instantiate(partner,newPosition,transform.rotation) as GameObject;
            Destroy(gameObject);

        }
    }
}
