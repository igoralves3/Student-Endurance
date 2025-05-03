using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeMove : MonoBehaviour
{

    public Rigidbody2D m_rigidbody;
    private int rangeFrames;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        rangeFrames = 0;

        var player = GameObject.FindWithTag("Player");
        if (player != null) {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>(), true);
        }
        var partner = GameObject.FindWithTag("PartnerStudent");
        if (partner != null)
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), partner.GetComponent<BoxCollider2D>(), true);
        }

        var mochilasComLaranjas = GameObject.FindGameObjectsWithTag("Orangebackpack");
        foreach (var m in mochilasComLaranjas)
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), m.GetComponent<BoxCollider2D>(), true);
        }
        var mochilasComVidas = GameObject.FindGameObjectsWithTag("Lifebackpack");
        foreach (var m in mochilasComVidas)
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), m.GetComponent<BoxCollider2D>(), true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rangeFrames++;
        if (m_rigidbody.velocity == new Vector2(0,0) || rangeFrames >= 180) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyStudent" || collision.gameObject.tag == "ThrowerStudent")
        {
            Destroy(gameObject);
        }
    }
}
