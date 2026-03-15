using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class Boss1 : MonoBehaviour
{

    private int etapa;
    private int inimigosNaEtapa;
    public GameObject inimigo1;
    public GameObject entry;

    GUIStyle style;

    public List<Vector3> spawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        etapa = 1;
        inimigosNaEtapa = 3;
        style = new GUIStyle();
        style.fontSize = 24;

        for (int i = 0; i < 5; i++)
        {
            spawnPoints.Add(new Vector3(4f + i * 4, 2.25f, 0f));
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var inimigos = GameObject.FindGameObjectsWithTag("EnemyStudent");
        if (inimigos == null || inimigos.Length == 0) {
            if (etapa <= 3) {
                for (int i = 0; i < inimigosNaEtapa; i++) {
                    var newX = transform.position.x + (i - ((inimigosNaEtapa * 1.0f) / 2.0f)) * 2;
                    var newY = transform.position.y;
                    var newPosition = spawnPoints[i];
                    

                        /*
                        var newX = transform.position.x + (i - ((inimigosNaEtapa * 1.0f) / 2.0f)) * 2;
                        var newY = transform.position.y;
                        var newPosition = new Vector3(newX, newY, 0);
                        */
                        var newEnemy = Instantiate(inimigo1, newPosition, transform.rotation) as GameObject;
                }

                etapa++;
                inimigosNaEtapa++;
            }
            else
            {
                var newEntry = Instantiate(entry, transform.position, transform.rotation) as GameObject;
                Destroy(gameObject);
            }
        }
    }


    void OnGUI()
    {

        
            //GUI.Label(new Rect(20, 90, 1000, 100), "Collect the falling oranges to defeat enemines.", style);
        
    }
}
