using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System.Globalization;

public class PartnerBag : MonoBehaviour
{

    public GameObject partner;

    public GameObject text;

    private int frames = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("TextHelp");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frames++;
        if (frames >= 60)
        {
            frames = 0;
            text.active = !text.active;
        }
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
