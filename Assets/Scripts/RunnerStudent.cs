using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerStudent : MonoBehaviour
{

    public Transform player, chaser;


    public int force = 10;
    public int speed = 2;
    Rigidbody2D m_rigidBody;
    bool canJump = true;
    bool jumping = false;

    public GameObject text;

    private int frames = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("TextRunning");

        text.active = false;

        m_rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        chaser = GameObject.FindWithTag("ChaserStudent").transform;
        canJump = true;
        jumping = false;
        var outrosFugitivos = GameObject.FindGameObjectsWithTag("RunnerStudent");
        foreach (var o in outrosFugitivos)
        {
            if (o != this)
            {
                var oBox = o.GetComponent<BoxCollider2D>();
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), oBox, true);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > chaser.position.x && transform.position.x < player.position.x-2) {

            transform.position += Vector3.right * speed * Time.deltaTime;
            if (!text.active && frames == 0) {
                text.active = true;
                
            }
            else
            {
                frames++;
                if (frames >= 60)
                {
                    frames = 60;
                    text.active = false;
                }

            }
        }
        var mochilas = GameObject.FindGameObjectsWithTag("Hurdlebackpack");
        foreach (var m in mochilas) {
            var distance = Vector3.Distance(transform.position, m.transform.position);
            if (distance <= 3 && canJump) {
                
                var forceTemp = m_rigidBody.velocity.y + force;
                if (forceTemp >= force)
                {
                    forceTemp = force;
                }

                m_rigidBody.AddForce(Vector2.up * forceTemp, ForceMode2D.Impulse);
                canJump = false;
                jumping = true;
                break;
            }
        }
        var paredesNoMeio = GameObject.FindGameObjectsWithTag("HurdleWall");
        foreach (var p in paredesNoMeio)
        {
            var distance = Vector3.Distance(transform.position, p.transform.position);
            if (distance <= 3 && canJump)
            {

                var forceTemp = m_rigidBody.velocity.y + force;
                if (forceTemp >= force)
                {
                    forceTemp = force;
                }

                m_rigidBody.AddForce(Vector2.up * forceTemp, ForceMode2D.Impulse);
                canJump = false;
                jumping = true;
                break;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.tag == "ChaserStudent")
        {
                Destroy(gameObject);
            
        }else if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            jumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
            jumping = true;
        }
    }
}
