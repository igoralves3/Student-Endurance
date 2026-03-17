using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour
{
    public bool GetIsPaused() { return isPaused; }
    bool isPaused;

    GUIStyle style;

    public Canvas pauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 24;

        pauseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            /*
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            //pauseMenu.SetActive(isPaused);

            if (!isPaused)
            {
                pauseCanvas.enabled = false;
            }
            else
            {
                pauseCanvas.enabled = true;
            }
            */
            PauseResumeGame();
        }
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                /*
                isPaused = false;
                Time.timeScale = 1;

                MainStudent.hp = 100;
                MainStudent.oranges = 5;
                MainStudent.previousOranges = 5;
                MainStudent.cenaAtual = "Stage0";
                MainStudent.lifes = 3;
                SceneManager.LoadScene("Menu");
                */
            }
        }
    }


    public void PauseResumeGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        //pauseMenu.SetActive(isPaused);

        if (!isPaused)
        {
            pauseCanvas.enabled = false;
        }
        else
        {
            pauseCanvas.enabled = true;
        }

    }

    public void GiveUpGame()
    {
        isPaused = false;

        pauseCanvas.enabled = false;

        Time.timeScale = 1;

        MainStudent.hp = 100;
        MainStudent.oranges = 5;
        MainStudent.previousOranges = 5;
        MainStudent.cenaAtual = "Stage0";
        MainStudent.lifes = 3;
        SceneManager.LoadScene("Menu");
    }

    void OnGUI()
    {
        if (isPaused)
        {
           // GUI.Label(new Rect(Screen.width/2-3, Screen.height/2-1, 1000, 100), "Paused.\nPress ESC to resume\nPress S to return to menu", style);

           // GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 1000, 100), "Press Esc again to resume or S to return to menu.", style);

        }
    }
}
