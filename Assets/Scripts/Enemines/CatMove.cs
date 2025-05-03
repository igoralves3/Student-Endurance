using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{

    SpriteRenderer m_SpriteRenderer;

    Rigidbody2D m_rigidBody;

    private int curDir = -1;

    private int hp;
    public int speed = 3;

    public AudioClip catNoise;

    // Start is called before the first frame update
    void Start()
    {
        curDir = -1;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        hp = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dogs = GameObject.FindGameObjectsWithTag("Dog");
        foreach (var d in dogs)
        {
            var distancia = Vector2.Distance(transform.position, d.transform.position);
            if (distancia < 5)
            {
                if (transform.position.x < d.transform.position.x)
                {
                    transform.position -= Vector3.right * speed * Time.deltaTime;
                    curDir = -1;
                }
                else if (transform.position.x > d.transform.position.x)
                {
                    transform.position += Vector3.right * speed * Time.deltaTime;
                    curDir = 1;
                }
                break;
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
            //AudioSource.PlayClipAtPoint(catNoise, transform.position, (float)MenuManager.soundVolume);
            SoundFXManager.instance.PlaySoundFXClip(catNoise, transform, (float)MenuManager.soundVolume * 1.0F);
        }

        if (collision.gameObject.tag == "Orange")
        {
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
