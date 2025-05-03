using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(AudioSource))]
public class EnemyStudentMove : MonoBehaviour
{

    SpriteRenderer m_SpriteRenderer;

    Rigidbody2D m_rigidBody;

    public Transform player;
    public int health, damage, speed;
    private bool attacking = false;
    private bool withSupport = false;

    public AudioClip impact1;
   private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;

        audioSource = GetComponent<AudioSource>();
        audioSource.volume =(float) MenuManager.soundVolume;
        audioSource.clip = impact1;
        
        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= 20 && !attacking && !withSupport)
        {

            if (player.position.x < transform.position.x)
            {
                transform.position -= Vector3.right * speed * Time.deltaTime;
                
            }
            else if (player.position.x > transform.position.x)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                
            }

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attacking = false;
        }
        else if (collision.gameObject.tag == "EnemySupport")
        {
            collision.gameObject.GetComponent<AngryDogMove>().supporting = false;
            withSupport = false;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Orange")
        {
            //Destroy(gameObject);
            health--;
            if (health <= 0)
            {

                //AudioSource.PlayClipAtPoint(impact1,transform.position,(float)MenuManager.soundVolume * 1.0F);
                SoundFXManager.instance.PlaySoundFXClip(impact1,transform, (float)MenuManager.soundVolume * 1.0F);

                withSupport = false;
                if (Random.Range(0.0f,10.0f) > 7.0f) {
                    int recover = (int)Random.Range(0, 4);

                    if (MainStudent.hp + recover >= 100)
                    {
                        MainStudent.hp = 100;
                    }
                    else {
                        MainStudent.hp += recover;
                    }
                }

                Destroy(gameObject);
                var suportes = GameObject.FindGameObjectsWithTag("EnemySupport");
                foreach (var s in suportes)
                {
                    var distance = Vector3.Distance(transform.position,s.transform.position);
                    if (distance <= 5)
                    {
                        s.GetComponent<AngryDogMove>().supporting = false;
                    }
                }
            }
        }
        else if (collision.gameObject.tag == "Player")
        {

            attacking = true;
        }
        else if (collision.gameObject.tag == "DeepWater")
        {
            Destroy(gameObject);
        }else if (collision.gameObject.tag == "EnemySupport")
        {
            withSupport = true;
            collision.gameObject.GetComponent<AngryDogMove>().supporting = true;
            //transform.position = collision.gameObject.transform.position + new Vector3(0,1,0);

        }
    }

    
}

