using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryDogMove : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    Rigidbody2D m_rigidBody;
    public Transform player;
    public bool supporting = false;

    public int speed = 5;

    public AudioClip dogNoise;


    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        supporting = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (supporting)
        {
            if (transform.position.x < player.position.x)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                m_SpriteRenderer.flipX = true;
            }
            else if (transform.position.x > player.position.x)
            {
                transform.position -= Vector3.right * speed * Time.deltaTime;
                m_SpriteRenderer.flipX = false;
            }
        }
        else
        {

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyStudent")
        {
            supporting = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //AudioSource.PlayClipAtPoint(dogNoise, transform.position, (float)MenuManager.soundVolume);
            SoundFXManager.instance.PlaySoundFXClip(dogNoise, transform, (float)MenuManager.soundVolume * 1.0F);
        }
        if (collision.gameObject.tag == "EnemyStudent")
        {
            supporting = true;
        }else if (collision.gameObject.tag == "Orange")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


}
