using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBullyMove : MonoBehaviour
{
    public Transform player;
    public int speed = 2;
    public int normalSpeed = 2;
    public int boost = 4;
    Rigidbody2D m_rigidBody;
    int boostFrames;
    bool boosting;

    GUIStyle style;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        speed = normalSpeed;
        boostFrames = 0;
        boosting = false;

        style = new GUIStyle();
        style.fontSize = 24;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var distancePlayer = transform.position.x - player.position.x;
        if (distancePlayer < -7.5f || distancePlayer > 7.5f)
        {
            speed = boost;
        }
        else
        {
            speed = normalSpeed;
        }

        if (boosting)
        {
            boostFrames++;
            if (boostFrames >= 180) {
                boosting = false;
                boostFrames = 0;
                speed = normalSpeed;
            }
        }


        transform.position += Vector3.right * speed * Time.deltaTime;
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Hurdlebackpack") {
            Destroy(collision.gameObject,0.5f);
            
        }else if (collision.gameObject.tag == "HurdleWall")
        {
            m_rigidBody.AddForce(Vector2.up * (50f * collision.transform.localScale.y), ForceMode2D.Impulse);
        }
    
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hurdlebackpack")
        {

            speed = boost;
            boosting = true;
        }

    }

    void OnGUI()
    {
        //GUI.Label(new Rect(20, 90, 1000, 100), "Run, dodge hurdles and escape from the bully", style);
    }
}
