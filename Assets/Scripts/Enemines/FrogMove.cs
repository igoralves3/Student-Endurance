using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{

    SpriteRenderer m_SpriteRenderer;

    Rigidbody2D m_rigidBody;


    public int health, speed, damage;

    public float force = 10;
    private bool attacking = false;

    public AudioClip frogNoise;
    private AudioSource frogAudio;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        frogAudio = GetComponent<AudioSource>();
        frogAudio.volume = (float)MenuManager.soundVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        


        if (collision.gameObject.tag == "Orange")
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "Player")
        {

            attacking = true;
        } else if (collision.gameObject.tag == "Ground") {
            
            var player = GameObject.FindGameObjectWithTag("Player");
            var deltaX = player.transform.position.x - transform.position.x;
            var deltaY = player.transform.position.y - transform.position.y;

            if (deltaX < 0)
            {
                deltaX = -deltaX;
            }
            if (deltaY < 0)
            {
                deltaY = -deltaY;
            }
            if (deltaX <= 10 && deltaY <= 5)
            {
                //AudioSource.PlayClipAtPoint(frogNoise, transform.position, (float)MenuManager.soundVolume);
                SoundFXManager.instance.PlaySoundFXClip(frogNoise, transform, (float)MenuManager.soundVolume * 1.0F);
                //frogAudio.Play();
            }
            

            
            m_rigidBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }


}
