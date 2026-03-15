using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
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
                    newX = 2;
                    newY = 1;
                    var newPosition1 = new Vector3(newX,newY,0);
                    var newEnemy1 = Instantiate(inimigo1, newPosition1, transform.rotation) as GameObject;

                    etapa++;

                    break;

                case 2:
                    newX = -10;
                    newY = 6;
                    var newPosition2 = new Vector3(newX, newY, 0);
                    var newEnemy2 = Instantiate(inimigo1, newPosition2, transform.rotation) as GameObject;

                    etapa++;

                    break;

                case 3:
                    newX = 10;
                    newY = 6;
                    var newPosition3 = new Vector3(newX, newY, 0);
                    var newEnemy3 = Instantiate(inimigo1, newPosition3, transform.rotation) as GameObject;

                    etapa++;

                    break;
                case 4:
                    newX = -10;
                    newY = 6;
                    var newPosition4a = new Vector3(newX, newY, 0);
                    var newEnemy4a = Instantiate(inimigo1, newPosition4a, transform.rotation) as GameObject;
                    newX = 10;
                    newY = 6;
                    var newPosition4b = new Vector3(newX, newY, 0);
                    var newEnemy4b = Instantiate(inimigo1, newPosition4b, transform.rotation) as GameObject;

                    etapa++;

                    break;
                case 5:
                    for (int i = 0; i < 4; i++)
                    {
                        newX = i - 2;
                        if (newX < 0) {
                            newX-=5;
                        }
                        else
                        {
                            newX+=5;
                        }
                        newY = 2;
                        var newPositionI = new Vector3(newX, newY, 0);
                        var newEnemyI = Instantiate(inimigo1, newPositionI, transform.rotation) as GameObject;
                    }

                    etapa++;

                    break;
                case 6:
                    var novaEntrada = Instantiate(entry, new Vector3(0,0,0), transform.rotation) as GameObject;
                    break;
            }
        }
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(20, 90, 1000, 100), "Collect oranges from water and avoid fishes to defeat enemines", style);
    }
}
