using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerRatMove : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    Rigidbody2D m_rigidBody;

    private int leftDir = -1;
    private int rightDir = 1;

    private int curDir;

    public int health, speed, damage;
    private bool attacking = false;

    public AudioClip squeack;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();

        var sorteioDir = Random.Range(0,2);
        if (sorteioDir == 0) {
            curDir = leftDir;
            m_SpriteRenderer.flipX = false;
        }
        else
        {
            curDir = rightDir;
            m_SpriteRenderer.flipX = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.Range(0,100) >= 90) {
            var sorteioLado = Random.Range(1, 7);

            if (sorteioLado <= 3) {//vai para esquerda
                if (curDir == rightDir) {
                    curDir = leftDir;
                    m_SpriteRenderer.flipX = false;
                }

            }
            else
            {//vai para direita
                if (curDir == leftDir)
                {
                    curDir = rightDir;
                    m_SpriteRenderer.flipX = true;
                }

            }
        }

        transform.position += Vector3.right * speed * curDir * Time.deltaTime;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attacking = false;
        }
    }


    void OnCollisionEnter2D(Collision2D collision) {
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
            //AudioSource.PlayClipAtPoint(squeack, collision.gameObject.transform.position, (float)MenuManager.soundVolume);
            SoundFXManager.instance.PlaySoundFXClip(squeack, transform, (float)MenuManager.soundVolume * 1.0F);
            attacking = true;
        }
    }
}
