using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioClip soundTest;
    //private AudioSource aud;

    const int TitleState = 0;
    const int RulesState = 1;
    const int OptionsState = 2;
    const int CreditsState = 3;
    const int QuitState = 4;
    int curState = 0;
    private double musicVolume = 0.5;
    public static double soundVolume = 0.5;

    GUIStyle style;
    GUIStyle style2;

    public Texture gameLogo;

    public Texture playIcon;
    public Texture tutorialIcon;
    public Texture optionsIcon;
    public Texture creditsIcon;
    public Texture musicIcon;
    public Texture soundIcon;



    // Start is called before the first frame update
    void Start()
    {
        audioSource2 = GetComponent<AudioSource>();

        var lista = GameObject.FindGameObjectsWithTag("Audio");
        for (int i = 0; i < lista.Length - 1; i++)
        {
            Destroy(lista[i]);
        }

        musicVolume = audioSource.volume;
        soundVolume = 0.5;

        curState = TitleState;

        style = new GUIStyle();
        style.fontSize = 24;

        //style.alignment = TextAnchor.MiddleCenter;

        style2 = new GUIStyle();
        style2.fontSize = 16;
        //style2.alignment = TextAnchor.MiddleCenter;
    }

    // Update is called once per frame
    void Update()
    {
        switch (curState)
        {
            case TitleState:
                if (Input.GetKey("1"))
                {
                    MainStudent.hp = 100;
                    MainStudent.lifes = 3;
                    MainStudent.oranges = 5;
                    MainStudent.cenaAtual = "Stage0";



                    SceneManager.LoadScene(MainStudent.cenaAtual);
                    

                }
                else if (Input.GetKey("2"))
                {
                    curState = RulesState;
                }
                else if (Input.GetKey("3"))
                {
                    curState = OptionsState;
                }
                else if (Input.GetKey("4"))
                {
                    curState = CreditsState;
                }else if (Input.GetKey("5"))
                {
                    Application.Quit();
                }
                break;
            case RulesState:
                if (Input.GetKey(KeyCode.Space))
                {
                    curState = TitleState;
                }
                break;
            case OptionsState:
                Debug.Log(soundVolume);
                if (Input.GetKey(KeyCode.Space))
                {
                    curState = TitleState;
                }
                if(Input.GetKeyDown("left"))
                {
                    if (musicVolume > 0)
                    {
                        musicVolume -= 0.1;
                        if (musicVolume < 0.1)
                        {
                            musicVolume = 0;
                        }
                        audioSource.volume = (float)musicVolume*1.0F;
                    }
                }else if (Input.GetKeyDown("right"))
                {
                    if (musicVolume < 1.0)
                    {
                        musicVolume += 0.1;
                        if (musicVolume > 1)
                        {
                            musicVolume = 1;
                        }
                        audioSource.volume =(float)musicVolume*1.0F;
                    }
                }
                if (Input.GetKeyDown("a"))
                {
                    if (soundVolume > 0)
                    {
                        soundVolume -= 0.1;

                        if (soundVolume < 0.1)
                        {
                            soundVolume = 0;
                        }
                        audioSource2.volume = (float)soundVolume * 1.0F;
                    }
                }
                else if (Input.GetKeyDown("d"))
                {
                    if (soundVolume < 1.0)
                    {
                        soundVolume += 0.1;
                        if (soundVolume > 1)
                        {
                            soundVolume = 1;
                        }
                        audioSource2.volume = (float)soundVolume * 1.0F;
                    }
                }
                if (Input.GetKeyDown("s"))
                {
                    audioSource2.Play();
                }
                break;
            case CreditsState:
                if (Input.GetKey(KeyCode.Space))
                {
                    curState = TitleState;
                }
                break;
            default:
                break;

        }
    }

    void OnGUI()
    {
        string menuOption1 = "Start Game (Press 1)";
        string menuOption2 = "Tutorial (Press 2)";
        string menuOption3 = "Options (Press 3)";
        string menuOption4 = "Credits (Press 4)";
        string menuOption5 = "Exit Game (Press 5)";


        switch (curState)
        {
            case TitleState:

                //GUI.Label(new Rect(Screen.width / 2, 20, 1000, 100), "Student Endurance", style);
                GUI.DrawTexture(new Rect(Screen.width / 2-150, Screen.height/2-(100+125), 400, 150), gameLogo, ScaleMode.StretchToFill);

                GUI.DrawTexture(new Rect(Screen.width / 2 - 100, Screen.height/2, 50, 50), playIcon, ScaleMode.ScaleToFit);
                GUI.Label(new Rect(Screen.width / 2-25, Screen.height / 2, 24* menuOption1.Length, 24), menuOption1, style);

                GUI.DrawTexture(new Rect(Screen.width / 2 - 100, Screen.height/2+50, 50, 50), tutorialIcon, ScaleMode.ScaleToFit);
                GUI.Label(new Rect(Screen.width / 2-25, Screen.height/2+50, 24, 24*menuOption2.Length), menuOption2, style);

                GUI.DrawTexture(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 50, 50), optionsIcon, ScaleMode.ScaleToFit);
                GUI.Label(new Rect(Screen.width / 2-25, Screen.height / 2 + 100, 24*menuOption3.Length, 24), menuOption3, style);

                GUI.DrawTexture(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 150, 50, 50), creditsIcon, ScaleMode.ScaleToFit);
                GUI.Label(new Rect(Screen.width / 2-25, Screen.height / 2 + 150, 24*menuOption4.Length, 24), menuOption4, style);

                GUI.Label(new Rect(Screen.width / 2-25, Screen.height / 2 + 200, 24*menuOption5.Length, 24), menuOption5, style);

                break;
            case RulesState:

                string rule1 = "You are going to the school and the bullies wants to hit you!";
                string rule2 = "Escape from them and find the director to help you out!";
                string rule3 = "In case of emergency, you can defend yourself throwing oranges on those bullies!";
                string control1 = "Move left and right with the arrow keys.";
                string control2= "Press Z to jump and X to throw oranges.";
                

                GUI.Label(new Rect(Screen.width / 2, Screen.height/2-(100+125), 24*"Game Rules:".Length, 24), "Game Rules:", style);
                GUI.Label(new Rect(Screen.width / 2-175, Screen.height / 2 - (100+125-24-10), 16*rule1.Length, 16), rule1, style2);
                GUI.Label(new Rect(Screen.width / 2-175, Screen.height / 2 - (100 + 125 - 24 - 10-30), 16*rule2.Length, 16), rule2, style2);
                GUI.Label(new Rect(Screen.width / 2-175, Screen.height / 2 - (100 + 125 - 24 - 10 - 30*2), 16*rule3.Length, 16), rule3, style2);
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 - (100 + 125 - 24 - 10 - 30 * 2-30), 24*"Controls:".Length, 24), "Controls:", style);
                GUI.Label(new Rect(Screen.width / 2-75, Screen.height / 2 - (100 + 125 - 24 - 10 - 30 * 2-30-30), 16*control1.Length, 16), control1, style2);
                GUI.Label(new Rect(Screen.width / 2-75, Screen.height / 2 - (100 + 125 - 24 - 10 - 30 * 2-30-30-30), 16*control2.Length, 16), control2, style2);
                GUI.Label(new Rect(Screen.width / 2- ("Return to title (Press Space bar)".Length), Screen.height / 2 - (100 + 125 - 24 - 10 - 30*2-30-30-30-30), 24* "Return to title (Press Space bar)".Length, 24), "Return to title (Press Space bar)", style);
                break;
            case OptionsState:
                GUI.Label(new Rect(Screen.width / 2, Screen.height/2-(225), 24* "Options:".Length, 24), "Options:", style);

                GUI.DrawTexture(new Rect(Screen.width / 2-100, Screen.height / 2 - 175, 50, 50), musicIcon, ScaleMode.ScaleToFit);
                GUI.Label(new Rect(Screen.width / 2-100+75, Screen.height / 2 - 175, 1000, 100), "Music (Adjust with arrow keys): " + ((musicVolume * 10F)).ToString(), style2);
                //GUI.Label(new Rect(Screen.width / 4 + 150, 50, 1000, 100), ((musicVolume * 10F)).ToString(), style2);

                GUI.DrawTexture(new Rect(Screen.width / 2-100, Screen.height / 2-125, 50, 50), soundIcon, ScaleMode.ScaleToFit);
                GUI.Label(new Rect(Screen.width / 2-100+75, Screen.height / 2-125, 1000, 100), "Sound (Adjust with A and D): "+ ((soundVolume * 10F)).ToString(), style2);
                //GUI.Label(new Rect(350, 100, 1000, 100), ((soundVolume * 10F)).ToString(), style2);

                GUI.Label(new Rect(Screen.width / 2-100+75, Screen.height / 2 -75, 1000, 100), "Sound Test (Press S)", style2);
                GUI.Label(new Rect(Screen.width / 2-100+75, Screen.height / 2 -25, 1000, 100), "Return to title (Press Space bar)", style);
                break;
            case CreditsState:
                GUI.Label(new Rect(Screen.width / 2-4, Screen.height/2-225, 1000, 100), "Credits:", style);
                GUI.Label(new Rect(Screen.width / 2-75, Screen.height/2-175, 1000, 100), "Created by Igor Giusti Cardona Alves.", style);
                GUI.Label(new Rect(Screen.width / 2-75, Screen.height/2-125, 1000, 100), "Return to title (Press Space bar)", style);
                break;
            default:


                break;

        }
    }

    void Awake()
    {
        
        DontDestroyOnLoad(audioSource.gameObject);
    }
    
}
