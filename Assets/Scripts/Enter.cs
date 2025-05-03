using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {

            

            Scene scene = SceneManager.GetActiveScene();
            if (scene.name.StartsWith("Stage"))
            {
                if (scene.buildIndex == 21)
                {
                    MainStudent.hp = 100;
                    MainStudent.lifes = 3;
                    MainStudent.oranges = 5;
                    MainStudent.cenaAtual = "Stage0";
                    SceneManager.LoadScene("Stage0");
                }
                else
                {
                    var vitimasResgatadas = GameObject.FindGameObjectsWithTag("RunnerStudent");
                    foreach (var v in vitimasResgatadas)
                    {
                        MainStudent.lifes = MainStudent.lifes + 1;
                    }
                    MainStudent.cenaAtual = "Stage" + (scene.buildIndex).ToString();
                    SceneManager.LoadScene(MainStudent.cenaAtual);
                }
            }
            
        }
    }
}
