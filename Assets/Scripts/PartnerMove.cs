using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerMove : MonoBehaviour
{

    SpriteRenderer m_SpriteRenderer;

    public Transform player;

    Rigidbody2D m_rigidBody;

    public GameObject orange;

    private int leftDir = -1;
    private int rightDir = 1;
    private int curDir;

    public GameObject textoParceiro;

    private bool textoAtivo = true;
    private int framesTextoAtivo = 0;

    public float speed = 5f;

    public bool isGround = false;
    

    public static int hp = 20;

    bool canJump = false;
    bool jumping = false;
    int maxJumpFrames = 10;
    bool canThrow = true;
    int nextThrow;
    int resistence;

    public Texture blueTexture;

    public GameObject restartVoid;

    GUIStyle style;

    // Start is called before the first frame update
    void Start()
    {
        textoAtivo = true;

        framesTextoAtivo = 0;

        hp = 20;

        player = GameObject.FindWithTag("Player").transform;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        resistence = 0;
        nextThrow = 0;

        var playerBox = player.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), playerBox, true);

        restartVoid = GameObject.FindGameObjectWithTag("Void");

        style = new GUIStyle();
        style.fontSize = 16;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (textoAtivo)
        {
            framesTextoAtivo++;
            if (framesTextoAtivo >= 300)
            {
                textoParceiro.active = false;
                textoAtivo = false;
            }
        }



        if (restartVoid != null)
        {
            var distance = Vector3.Distance(transform.position, restartVoid.transform.position);
            if (distance <= 10)
            {
                if (transform.position.x > restartVoid.transform.position.x)
                {
                    transform.position -= Vector3.right * speed * Time.deltaTime;
                    curDir = leftDir;
                }
                else if (transform.position.x < restartVoid.transform.position.x)
                {
                    transform.position += Vector3.right * speed * Time.deltaTime;
                    curDir = rightDir;
                }
            }
            else
            {
                AtualizaParceiro();
            }
        }
        else
        {
            AtualizaParceiro();
            
        }
        
    }

    private void AtualizaParceiro()
    {
        if (transform.position.x > player.position.x + 2)
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
            curDir = leftDir;
        }
        else if (transform.position.x < player.position.x - 2)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            curDir = rightDir;
        }
        if (player.position.y > transform.position.y + 1 && canJump)
        { //pula

            if (m_rigidBody.velocity.y == 0)
            {
                m_rigidBody.AddForce(Vector2.up * maxJumpFrames, ForceMode2D.Impulse);
                jumping = true;
                canJump = false;
            }
        }


        var inimigos = GameObject.FindGameObjectsWithTag("EnemyStudent");
        foreach (var i in inimigos)
        {
            float distance = Vector2.Distance(transform.position, i.transform.position);
            if (distance <= 10)
            {//atira laranja 
                if (canThrow)
                {

                    canThrow = false;

                    nextThrow = 0;
                    var newPosition = transform.position + new Vector3(curDir, 0, 0);
                    var novaLaranja = Instantiate(orange, newPosition, transform.rotation) as GameObject;

                    Physics2D.IgnoreCollision(novaLaranja.GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>(), true);

                    var range = curDir * 300;



                    novaLaranja.GetComponent<Rigidbody2D>().AddForce(new Vector2(range, 1));

                }
                else
                {
                    nextThrow++;
                    if (nextThrow >= 180)
                    {
                        canThrow = true;
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            
                isGround = true;
                canJump = true;
                jumping = false;
            
        }
        else if (collision.gameObject.tag == "OrangeItem")
        {

        }
        else if (collision.gameObject.tag == "Orangebackpack")
        {
           
                canJump = true;
            


        }
        else if (collision.gameObject.tag == "EnemyStudent")
        {
           
        }
        else if (collision.gameObject.tag == "DeepWater")
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyStudent")
        {
            if (resistence < 60)
            {
                resistence++;
            }
            else
            {
                resistence = 0;
                hp -= collision.gameObject.GetComponent<EnemyStudentMove>().damage;
                if (hp <= 0)
                {
                    hp = 0;
                    Destroy(gameObject);
                }
            }
        } else if (collision.gameObject.tag == "OtherEnemy") {
            if (resistence < 30)
            {
                resistence++;
            }
            else
            {
                resistence = 0;
                hp -= Random.Range(1,10);
                if (hp <= 0)
                {
                    hp = 0;
                    Destroy(gameObject);
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
            canJump = false;
            
        }
        else if (collision.gameObject.tag == "EnemyStudent" || collision.gameObject.tag == "OtherEnemy")
        {
            
            resistence = 0;
        }
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(200, 20, 1000, 20), "Partner HP:", style);
        //GUI.DrawTexture(new Rect(200, 40, hp*5, 25), blueTexture, ScaleMode.StretchToFill);
        //GUI.Label(new Rect(200, 40, 100, 20), hp.ToString(),style);
    }

}
