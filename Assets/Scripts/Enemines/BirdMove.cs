using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{

    public Transform player;
    SpriteRenderer m_SpriteRenderer;

    Rigidbody2D m_rigidBody;

    public GameObject poo;

    public int health, speed, damage;
    public bool flap;
    int curDir = 1;
    int steps = 0;

    bool canDrop;
    int waitDrop = 0;

    public AudioClip birdNoise;
    private AudioSource birdAudio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        flap = false;
        canDrop = true;
        birdAudio = GetComponent<AudioSource>();
        birdAudio.volume = (float)MenuManager.soundVolume;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        steps += curDir;
        if (steps < -60 || steps > 60)
        {
            curDir = -curDir;
            m_SpriteRenderer.flipX = !m_SpriteRenderer.flipX;
        }
        if (flap)
        {
            transform.Translate(Vector2.up * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.up * Time.deltaTime);
        }
        flap = !flap;
        var distancePlayer = transform.position.x - player.position.x;
        if (distancePlayer >= -10 && distancePlayer <= 10) {
            
            if ( canDrop)
            {
                //birdAudio.Play();
                SoundFXManager.instance.PlaySoundFXClip(birdNoise, transform, (float)MenuManager.soundVolume * 1.0F);

                canDrop = false;
                waitDrop = 0;
                var newX = transform.position.x;
                var newY = transform.position.y - 1;
                var newPosition = new Vector3(newX, newY, 0);
                var novoPoo = Instantiate(poo, newPosition, transform.rotation) as GameObject;
            }
            else
            {
                waitDrop++;
                if (waitDrop >= 120)
                {
                    canDrop = true;
                }
            }
        }
        

        transform.position -= Vector3.right * speed * curDir * Time.deltaTime;
    }

    void OnColllisionEnter(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            curDir = -curDir;
            m_SpriteRenderer.flipX = !m_SpriteRenderer.flipX;
        }
        else if (collision.gameObject.tag == "Orange")
        {
           
                Destroy(gameObject);
            
        }
    }
}
