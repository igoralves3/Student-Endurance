using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PauseSystem : MonoBehaviour
{
    public bool GetIsPaused() { return isPaused; }
    bool isPaused;

    GUIStyle style;

    public Canvas pauseCanvas;
    public Button resumeButton;
    public Button giveUpButton;

    public TextMeshProUGUI textPause;

    // Start is called before the first frame update
    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 24;


        var t = transform;

        var ps = transform.Find("PauseCanvas");

        isPaused = false;

       // pauseCanvas.gameObject.SetActive(false);
       /*
        resumeButton = pauseCanvas.transform.Find("ButtonResume")
                                  .GetComponentInChildren<Button>(true);

        giveUpButton = pauseCanvas.transform.Find("ButtonGiveUp")
                                  .GetComponentInChildren<Button>(true);
       */
        SetMenuEnabled(false);

        //resumeButton.onClick.AddListener(PauseResumeGame);
        //giveUpButton.onClick.AddListener(GiveUpGame);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SetMenuEnabled(bool enabled)
    {
        textPause.enabled = enabled;
        resumeButton.gameObject.SetActive(enabled);
        giveUpButton.gameObject.SetActive(enabled);

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isPaused = false;

        var t = transform;

        var ps = transform.Find("PauseCanvas");

       
        

        /*
        resumeButton = pauseCanvas.transform.Find("ButtonResume")
                                   .GetComponent<Button>();

        giveUpButton = pauseCanvas.transform.Find("ButtonGiveUp")
                                  .GetComponent<Button>();
        */
        
        SetMenuEnabled(false);

        //resumeButton.onClick.RemoveAllListeners();
        // giveUpButton.onClick.RemoveAllListeners();

        resumeButton.onClick.AddListener(PauseResumeGame);
        giveUpButton.onClick.AddListener(GiveUpGame);
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
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

        // }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //pauseCanvas.gameObject.SetActive(true);
            PauseResumeGame();
            //if (Input.GetKeyDown(KeyCode.S))
            //{
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
            //}
            //}
        }
       
    }

    public void PauseResumeGame()
    {
       
        isPaused = !isPaused;
        
        Time.timeScale = isPaused ? 0 : 1;


        if (isPaused)
        {


            // resumeButton.gameObject.SetActive(true);
            // giveUpButton.gameObject.SetActive(true);

            //pauseCanvas.gameObject.SetActive(true);
        }
        else
        {

            // resumeButton.gameObject.SetActive(false);
            // giveUpButton.gameObject.SetActive(false);
            //pauseCanvas.gameObject.SetActive(false);
        }
        SetMenuEnabled(isPaused);

        UnityEvent unityEvent = resumeButton.onClick;
        int count = unityEvent.GetPersistentEventCount();
        Debug.Log("Número de listeners: " + count);

    }

    public void GiveUpGame()
    {
        isPaused = false;

        //pauseCanvas.enabled = false;

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

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //DontDestroyOnLoad(pauseCanvas.gameObject);
       //DontDestroyOnLoad(resumeButton.gameObject);
        //DontDestroyOnLoad(giveUpButton.gameObject);

        var t = transform;

        var ps = transform.Find("Canvas");
        isPaused = false;

        pauseCanvas.gameObject.SetActive(false);

        //var botoes = ps.GetComponentsInChildren<Button>(true);
        /*
        resumeButton = transform.Find("ButtonResume")
                                  .GetComponent<Button>();

        giveUpButton = transform.Find("ButtonGiveUp")
                                  .GetComponent<Button>();
        */
        resumeButton.onClick.RemoveAllListeners();
        giveUpButton.onClick.RemoveAllListeners();

        resumeButton.onClick.AddListener(PauseResumeGame);
        giveUpButton.onClick.AddListener(GiveUpGame);

       // resumeButton.gameObject.SetActive(false);
       // giveUpButton.gameObject.SetActive(false);

    }
}
