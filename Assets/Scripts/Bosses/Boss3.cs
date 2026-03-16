using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{

    private int etapa;
    private int inimigosNaEtapa;
    public GameObject inimigo1;
    public GameObject entry;

    GUIStyle style;

    // Start is called before the first frame update
    void Start()
    {
        etapa = 1;
        style = new GUIStyle();
        style.fontSize = 24;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(etapa);

        var inimigos = GameObject.FindGameObjectsWithTag("EnemyStudent");
        if (inimigos == null || inimigos.Length == 0)
        {
            var newX = 0;
            var newY = 0;

            switch (etapa)
            {
                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        newX = i * 10 - 10;
                        newY = 2;
                        var newPositionI = new Vector3(newX, newY, 0);
                        var newEnemyI = Instantiate(inimigo1, newPositionI, transform.rotation) as GameObject;
                    }

                    etapa++;

                    break;
                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        newX = i*10 - 10;
                        newY = 5;
                        var newPositionI = new Vector3(newX, newY, 0);
                        var newEnemyI = Instantiate(inimigo1, newPositionI, transform.rotation) as GameObject;
                    }

                    etapa++;

                    break;
                case 3:
                    for (int i = 0; i < 2; i++)
                    {
                        newX = i*20 - 10;
                        newY = 2;
                        var newPositionI = new Vector3(newX, newY, 0);
                        var newEnemyI = Instantiate(inimigo1, newPositionI, transform.rotation) as GameObject;
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        newX = i*10-10;
                        newY = 5;
                        var newPositionI = new Vector3(newX, newY, 0);
                        var newEnemyI = Instantiate(inimigo1, newPositionI, transform.rotation) as GameObject;
                    }
                    newX = -18;
                    newY = 8;
                    var PositionSecondLast = new Vector3(newX, newY, 0);
                    var PositionLast = Instantiate(inimigo1, PositionSecondLast, transform.rotation) as GameObject;
                    newX = 18;
                    newY = 8;
                    PositionSecondLast = new Vector3(newX, newY, 0);
                    PositionLast = Instantiate(inimigo1, PositionSecondLast, transform.rotation) as GameObject;

                    etapa++;

                    break;

                default:
                    var novaEntrada = Instantiate(entry, new Vector3(-5, 6, 0), transform.rotation) as GameObject;
                    break;
            }
        }
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(20, 90, 1000, 100), "Collect oranges from lab rats and avoid sewer rats to defeat enemines", style);
    }
}
