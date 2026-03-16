using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss4 : MonoBehaviour
{

    GUIStyle style;

    // Start is called before the first frame update
    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 24;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var inimigos = GameObject.FindGameObjectsWithTag("ThrowerStudent");
        if (inimigos == null || inimigos.Length == 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name.StartsWith("Stage"))
            {
                if (scene.name == "Stage20")
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
                    MainStudent.cenaAtual = "Stage" + (scene.buildIndex-3).ToString();
                    SceneManager.LoadScene(MainStudent.cenaAtual);
                }
            }
        }
    }


    void OnGUI()
    {
        //GUI.Label(new Rect(20, 90, 1000, 100), "Defeat enemines without fall and avoid his apples.", style);
        //GUI.Label(new Rect(20, 110, 1000, 100), "You can grab his oranges.", style);
    }
}
