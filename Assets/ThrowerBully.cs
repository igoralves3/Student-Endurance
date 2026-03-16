using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerBully : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    Rigidbody2D m_rigidBody;

    public Transform player;
    public int health, damage, speed;
    private bool attacking = false;

    bool isNearPlayer = true;
    public GameObject orange;
    public GameObject apple;
    int frames;

    public AudioClip impact1;

    private int curDir = -1;

    public GameObject blockade;

    // Start is called before the first frame update
    void Start()
    {
        frames = 0;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        isNearPlayer = true;

        curDir = -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isNearPlayer = true;
        var throwers = GameObject.FindGameObjectsWithTag("ThrowerStudent");
        if (player.position.x < transform.position.x) {
            foreach (var t in throwers)
            {
                if (t != this)
                {
                    if (transform.position.x > t.transform.position.x)
                    {
                        isNearPlayer = false;
                        break;
                    }
                }
            }
        }
        else
        {
            for (int i = throwers.Length - 1; i >= 0; i--)
            {
                var t = throwers[i];
                if (t != this)
                {
                    if (transform.position.x < t.transform.position.x)
                    {
                        isNearPlayer = false;
                        break;
                    }
                }

            }
        }
        if (isNearPlayer) {
            frames++;
            if (frames >= 60) {

                if (player.position.x < transform.position.x)
                {
                    curDir = -1;
                }
                else
                {
                    curDir = 1;
                }

                frames = 0;
                var sorteioTiro = Random.Range(1, 9);

                if (sorteioTiro <= 3)
                {


                    var newPosition = transform.position + new Vector3(curDir, 0, 0);
                    var novaLaranja = Instantiate(orange, newPosition, transform.rotation) as GameObject;
                    var rangeX = (curDir) * (Random.Range(1, 100) * 10 - 20);
                    var rangeY = Random.Range(1, 20) * 5;
                    novaLaranja.GetComponent<Rigidbody2D>().AddForce(new Vector2(rangeX, rangeY));
                }
                else if (sorteioTiro <= 6)
                {
                    var newPosition = transform.position + new Vector3(curDir, 0, 0);
                    var novaMaca = Instantiate(apple, newPosition, transform.rotation) as GameObject;
                    var rangeX = (curDir) * (Random.Range(1, 100) * 10 - 20);
                    var rangeY = Random.Range(1, 20) * 5;
                    novaMaca.GetComponent<Rigidbody2D>().AddForce(new Vector2(rangeX, rangeY));

                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attacking = false;
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Orange")
        {
            health--;
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(impact1, transform.position, (float)MenuManager.soundVolume*1.0F);

                if (blockade != null)
                {
                    Destroy(blockade);
                }

                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "Player")
        {

            attacking = true;
        }
        else if (collision.gameObject.tag == "Street")
        {
            Destroy(gameObject);
        }
        
    }


}
