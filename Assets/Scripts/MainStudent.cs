using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro;
using System.Globalization;
using System.Reflection;

public class MainStudent : MonoBehaviour
{
    private PauseSystem pauseSystem;
    
    

    SpriteRenderer m_SpriteRenderer;

    Rigidbody2D m_rigidBody;

    public GameObject orange;

    public Sprite[] leftFrames = new Sprite[4];
    public Sprite[] rightFrames = new Sprite[4];

    private int leftDir = -1;
    private int rightDir = 1;
    private int curDir;

    private int frame = 0;
    private int curFrame = 0;
    private int maxFrames = 4;

    private bool moved = false;
    public int speed = 2;
    float jumpFrames = 0f;
    int maxJumpFrames = 10;
    bool canJump = false;
    bool jumping = false;

    public float jumpForce = 1f;
    public bool isGround = false;

    public static int hp = 100;
    public static int lifes = 3;
    public static int oranges = 5;
    public static int previousOranges = 5;
    public static string cenaAtual = "Stage0";
    public static int level = 0;
    bool canThrow = true;
    int resistence;

    public Font font;


    GUIStyle style;
    GUIStyle style2;

    public AudioClip impact1;

    public Texture lifeUITexture;
    public Texture orangeUITexture;
    public Texture blueTexture;

    public GameObject textoDor;
    private bool textoAtivo = true;

    private bool canThrowAtStage = true;

    public TextMeshProUGUI textLifes, textOranges, extraText;

    public Image healthFill;

    public Canvas partnerCanvas;

    private GameObject partner;

    // Start is called before the first frame update
    void Start()
    {
        
        previousOranges = oranges;

        speed = 5;
        frame = 0;

        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        curDir = rightDir;
        resistence = 0;

        style = new GUIStyle();
        style.fontSize = 24;
        textoDor.active = false;

        if (cenaAtual == "Stage6" || cenaAtual == "Stage14" || cenaAtual == "Stage18")
        {
            canThrowAtStage = false;
        }
        else
        {
            canThrowAtStage = true;
        }

        partner = GameObject.FindGameObjectWithTag("PartnerStudent");

        UpdateUI();
        SetExtraText();

        UpdatePartnerCanvas();
    }

    private void LifeLost()
    {

        hp = 0;
        if (lifes > 1)
        {
            lifes--;
            hp = 100;
            oranges = previousOranges;
            SceneManager.LoadScene(cenaAtual);
        }
        else
        {
            hp = 100;
            oranges = 5;
            previousOranges = 5;
            cenaAtual = "Stage0";
            lifes = 3;
            SceneManager.LoadScene("GameOver");
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        


        if (transform.position.y <= -50)
        {
            LifeLost();

        }

        moved = false;
        if (Input.GetKey("left")) {
            moved = true;
            curDir = leftDir;
            transform.position -= Vector3.right * speed * Time.deltaTime;
        } else if (Input.GetKey("right")) {
            moved = true;
            curDir = rightDir;
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

       

        if (Input.GetKey("z") && canJump) { //pula
            jumpFrames = 0.0f;

            /*
            var force = m_rigidBody.velocity.y+maxJumpFrames;
            if (force >= maxJumpFrames) {
                force = maxJumpFrames;
            }*/
            if (m_rigidBody.velocity.y == 0)
            {
                 m_rigidBody.AddForce(Vector2.up * maxJumpFrames, ForceMode2D.Impulse);

               
                jumpFrames = 0f;
                jumping = true;
                canJump = false;
            }
        }
        if (Input.GetKey("x")) {//atira laranja 
            if (canThrow && canThrowAtStage) {
                if (oranges > 0) {
                    canThrow = false;
                    oranges--;
                    var newPosition = transform.position + new Vector3(curDir, 0, 0);
                    var novaLaranja = Instantiate(orange, newPosition, transform.rotation) as GameObject;
                    var range = curDir * 300;
                    novaLaranja.GetComponent<Rigidbody2D>().AddForce(new Vector2(range, 1));
                } 
            }
        }
        else
        {
            canThrow = true;
        }
        if (moved) {

            frame++;

            if (frame >= 5) {
                frame = 0;
                curFrame = (curFrame + 1) % maxFrames;
                if (curDir == leftDir) {
                    m_SpriteRenderer.sprite = leftFrames[curFrame];
                }
                else
                {
                    m_SpriteRenderer.sprite = rightFrames[curFrame];
                }
            }
        }
        else
        {
            frame = 0;
            curFrame = 0;
            if (curDir == leftDir)
            {
                m_SpriteRenderer.sprite = leftFrames[curFrame];
            }
            else
            {
                m_SpriteRenderer.sprite = rightFrames[curFrame];
            }
        }
        
        if (jumping) {
            jumpFrames += Time.deltaTime;

            if (jumpFrames >= maxJumpFrames) {
                jumping = false;
                jumpFrames = 0.0f;
            }
            
        }
        else
        {
            jumpFrames = 0.0f;
        }

        UpdateUI();
        UpdatePartnerCanvas();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground" )
        {
            
                isGround = true;
                canJump = true;
                //jumping = false;
            
        }
       
        if (collision.gameObject.tag == "EnemyStudent" || collision.gameObject.tag == "EnemySupport" || collision.gameObject.tag == "OtherEnemy"
            || collision.gameObject.tag == "Dog" || collision.gameObject.tag == "Cat")
        {

            Debug.Log("enter");
            canJump = true;
           
            //var deltaY = (collision.gameObject.GetComponent<BoxCollider2D>().size.y/2);
            var deltaY = (collision.gameObject.transform.lossyScale.y / 2); //* 0.32f;
            if (deltaY < 1)
            {
                deltaY = 1;
            }

            if (transform.position.y >= collision.gameObject.transform.position.y+1
                ) {
                //isGround = true;
                //canJump = true;
                //canJump = true;
                //jumping = false;
                Debug.Log(collision.gameObject.transform.lossyScale.y);
                if (collision.gameObject.tag != "EnemyStudent" && collision.gameObject.tag != "ThrowerStudent") {
                    Debug.Log(collision.gameObject.transform.lossyScale.y);
                    Destroy(collision.gameObject);
                }
                else
                {
                    textoDor.active = true;
                    if (collision.gameObject.tag == "EnemyStudent" || collision.gameObject.tag != "ThrowerStudent")
                    {
                        
                        AudioSource.PlayClipAtPoint(impact1, transform.position, (float)MenuManager.soundVolume*1.0F);
                        hp -= collision.gameObject.GetComponent<EnemyStudentMove>().damage;
                    }
                    else
                    {
                        hp -= Random.Range(1, 6);
                    }
                    if (hp <= 0)
                    {
                        LifeLost();
                    }
                }
            }
            else
            {
                textoDor.active = true;
                if (collision.gameObject.tag == "EnemyStudent" || collision.gameObject.tag == "ThrowerStudent")
                {

                    AudioSource.PlayClipAtPoint(impact1, transform.position, (float)MenuManager.soundVolume*1.0F);
                    SoundFXManager.instance.PlaySoundFXClip(impact1, transform, (float)MenuManager.soundVolume * 1.0F);

                    hp -= collision.gameObject.GetComponent<EnemyStudentMove>().damage;
                }
                else
                {
                    hp -= Random.Range(1, 6);
                }
                if (hp <= 0)
                {
                    LifeLost();
                }
            }
            
        }
        if (collision.gameObject.tag == "ChaserStudent" || collision.gameObject.tag == "DeepWater" || collision.gameObject.tag == "Street")
        {

            LifeLost();

        }if (collision.gameObject.tag == "Poo")
        {
            canJump = true;
            hp -= 15;
            if (hp <= 0)
            {
                LifeLost();
            }
            Destroy(collision.gameObject);
        }if (collision.gameObject.tag == "Apple")
        {
            hp -= 2;
            if (hp <= 0)
            {
                LifeLost();
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "OrangeItem")
        {

            oranges++;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "EnemyStudent" || collision.gameObject.tag == "ThrowerStudent" 
            || collision.gameObject.tag == "OtherEnemy" || collision.gameObject.tag == "Cat" || collision.gameObject.tag == "Dog")
        {
            
            canJump = true;
            if (resistence < 30)
            {
                resistence++;
            }
            else
            {
                resistence = 0;
                //textoDor.active = true;
                if (collision.gameObject.tag == "EnemyStudent") {
                    //AudioSource.PlayClipAtPoint(impact1, transform.position, (float)MenuManager.soundVolume*1.0F);
                    SoundFXManager.instance.PlaySoundFXClip(impact1, transform, (float)MenuManager.soundVolume * 1.0F);

                    hp -= collision.gameObject.GetComponent<EnemyStudentMove>().damage;
                }
                else
                {
                    hp -= Random.Range(1,6);
                }
                if (hp <= 0) {
                    LifeLost();
                }
            }
        }if (collision.gameObject.tag == "EnemySupport")
        {
            canJump = true;
            if (collision.gameObject.GetComponent<AngryDogMove>().supporting)
            {
                if (resistence < 30)
                {
                    resistence++;
                }
                else
                {
                    resistence = 0;
                    hp -= Random.Range(1, 11);
                    if (hp <= 0)
                    {
                        LifeLost();
                    }
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
            //canJump = false;
            //jumping = true;

           
        }if (collision.gameObject.tag == "EnemyStudent" || collision.gameObject.tag == "OtherEnemy" || collision.gameObject.tag == "EnemySupport" 
            || collision.gameObject.tag == "Dog" || collision.gameObject.tag == "Cat") {
            //isGround = false;
            textoDor.active = false;
            //canJump = false;
            //jumping = true;
            resistence = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OrangeItem")
        {

            oranges++;
            Destroy(collision.gameObject);

        }



        if (collision.gameObject.tag == "Orangebackpack")
        {

            //canJump = true;

            oranges += collision.gameObject.GetComponent<OrangeBackpack>().oranges;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "Lifebackpack")
        {
            //canJump = true;

            lifes++;
            Destroy(collision.gameObject);
        }



    }

    void UpdateUI()
    {
        healthFill.fillAmount = hp * 1.0f / 100.0f;

        textLifes.text = " x "+lifes.ToString();
        textOranges.text = " x " + oranges.ToString();

        
    }

    void SetExtraText()
    {
        if (cenaAtual == "Stage0")
        {
            extraText.text = "Use left and right arrow keys to move.\nPress Z to Jump and X to throw oranges.";
        }
        else if (cenaAtual == "Stage4")
        {
            extraText.text = "Collect the falling oranges to defeat enemines.";
        }
        else if (cenaAtual == "Stage8")
        {
            extraText.text = "Collect oranges from water and avoid fishes to defeat enemines.";
        }
        else if (cenaAtual == "Stage12")
        {
            extraText.text = "Collect oranges from lab rats and avoid sewer rats to defeat enemines.";
        }else if (cenaAtual == "Stage16")
        {
            extraText.text = "Defeat enemines without fall and avoid his apples.\nYou can grab their oranges.";
        }
        else if (cenaAtual == "Stage6" || cenaAtual == "Stage14" || cenaAtual == "Stage18")
        {
            extraText.text = "Run, dodge hurdles and escape from the bully.";
        }
    }

    void UpdatePartnerCanvas()
    {
        if (partner != null)
        {
            var partnerbar = GameObject.Find("PartnerHealthBar");
            if (partner != null)
            {
                var pi = partnerbar.GetComponent<Image>();

                pi.fillAmount = PartnerMove.hp * 1.0f / 20.0f;
            }
        }
        else
        {
            partnerCanvas.enabled = false;
        }
    }
    
    void OnGUI() {
       // Scene scene = SceneManager.GetActiveScene();
        //GUI.Label(new Rect(20, 20, 1000, 100), "HP: "+hp.ToString(), style);
        //GUI.Label(new Rect(20, 20, hp, 20), Color.blue);

        
        
        //GUI.DrawTexture(new Rect(20, 20, hp, 25), blueTexture, ScaleMode.StretchToFill);
        //GUI.Label(new Rect(20,20,100,20),hp.ToString(),style);

        /*
        GUI.DrawTexture(new Rect(20, 45, 20, 20), lifeUITexture, ScaleMode.ScaleToFit);
        GUI.Label(new Rect(40, 45, 1000, 20), " x " + lifes.ToString(), style);
        GUI.DrawTexture(new Rect(20, 65, 20, 20), orangeUITexture, ScaleMode.ScaleToFit);
        GUI.Label(new Rect(40, 65, 1000, 20), " x " + oranges.ToString(), style);
        
        if (scene.name == "Stage0")
        {
            GUI.Label(new Rect(25, 90, 1000, 100), "Use left and right arrow keys to move.", style);
            GUI.Label(new Rect(25, 110, 1000, 100), "Press Z to Jump and X to throw oranges.", style);
        }
        */
    }
    private void Awake()
    {
        pauseSystem = FindObjectOfType<PauseSystem>();
    }


}