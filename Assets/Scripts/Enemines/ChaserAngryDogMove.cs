using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserAngryDogMove : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    Rigidbody2D m_rigidBody;

    public Transform cat, player;

    private int curDir = -1;

    private int hp;

    public int speed = 2;

    public AudioClip dogNoise;

    // Start is called before the first frame update
    void Start()
    {
        curDir = -1;
        hp = 3;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        var gatos = GameObject.FindGameObjectsWithTag("Cat");
        var actualDistance = 10f;
        foreach (var g in gatos)
        {
            var distance1 = Vector2.Distance(transform.position, g.transform.position);
            if (actualDistance > distance1)
            {
                actualDistance = distance1;
                cat = g.transform;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cat != null)
        {

            if (transform.position.x > cat.position.x)
            {
                transform.position -= Vector3.right * 2 * Time.deltaTime;
                curDir = -1;
            }
            else if (transform.position.x < cat.position.x)
            {
                transform.position += Vector3.right * 2 * Time.deltaTime;
                curDir = 1;
            }
        }
        else
        {
            if (transform.position.x > player.position.x)
            {
                transform.position -= Vector3.right * speed * Time.deltaTime;
                curDir = -1;
            }
            else if (transform.position.x < player.position.x)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                curDir = 1;
            }
        }
        if (curDir == -1)
        {
            m_SpriteRenderer.flipX = false;
        }
        else
        {
            m_SpriteRenderer.flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //AudioSource.PlayClipAtPoint(dogNoise, transform.position, (float)MenuManager.soundVolume);
            SoundFXManager.instance.PlaySoundFXClip(dogNoise, transform, (float)MenuManager.soundVolume * 1.0F);
        }

        if (collision.gameObject.tag == "Cat")
        {
            Destroy(collision.gameObject);
        }else if (collision.gameObject.tag == "Orange")
        {
            Destroy(collision.gameObject);
            if (hp > 1)
            {
                hp--;
            }
            else
            {
                hp = 0;
                Destroy(gameObject);
            }
        }
    }
}
