using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    GUIStyle style;

    // Start is called before the first frame update
    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 36;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            MainStudent.hp = 100;
            MainStudent.oranges = 5;
            MainStudent.previousOranges = 5;
            MainStudent.cenaAtual = "Stage0";
            MainStudent.lifes = 3;
            SceneManager.LoadScene("Menu");
        }*/
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(Screen.width/2-144, Screen.height/2-2, 1000, 100), "Oh no! The bullies defeated you!\nPress Space bar to return to the menu.", style);

    }
}
