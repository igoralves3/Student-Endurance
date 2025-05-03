using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    struct DialogText
    {
        public string person { get; set; }
        public string text { get; set; }
        public DialogText(string person,string text)
        {
            this.person = person;
            this.text = text;
        }
    }

    GUIStyle dialogStyle;

    private DialogText[] dialogs;

    private int maxPhases = 9;
    private int curPhase;
    // Start is called before the first frame update
    void Start()
    {
        dialogStyle = new GUIStyle();
        dialogStyle.fontSize = 30;

        dialogs = new DialogText[9];
        curPhase = 0;
        dialogs[0] = new DialogText(
        person: "Player",
        text: "Good morning, director."
        );
        dialogs[1] =new DialogText(
        person: "Director",
        text: "Good morning."
        );
        dialogs[2] = new DialogText(
        person: "Player",
        text: "Some students are making bullying with me."
        );
        dialogs[3] = new DialogText(
        person: "Director",
        text: "What they are doing with you?"
        );
        dialogs[4] = new DialogText(
        person: "Player",
        text: "They want to hit me."
        );
        dialogs[5] = new DialogText(
        person: "Director",
        text: "Who are doing this?"
        );
        dialogs[6] =new DialogText(
        person: "Player",
        text: "7 people."
        );
        dialogs[7] = new DialogText(
        person: "Director",
        text: "Thank you to advice me. \nI will bring them to my room."
        );
        dialogs[8] =new DialogText(
        person: "Game",
        text: "You completed the game. \nPress SPACE bar to return to the menu. \nBut don't throw oranges on people in the real life." 
        );
    
        

    }

    // Update is called once per frame
    void Update()
    {
        if (curPhase < maxPhases-1)
        {
            if (Input.GetKeyDown("space"))
            {
                curPhase++;
            }
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                MainStudent.lifes = 3;
                MainStudent.hp = 100;
                MainStudent.oranges = 5;
                MainStudent.previousOranges = 5;
                MainStudent.cenaAtual = "Stage0";
                SceneManager.LoadScene("Menu");
            }
        }
    }

    void OnGUI()
    {
        if (dialogs[curPhase].person == "Player")
        {
            GUI.Label(new Rect(Screen.width / 4, 80, 10, 10), dialogs[curPhase].person, dialogStyle);
            GUI.Label(new Rect(Screen.width / 4, 110, 100, 100), dialogs[curPhase].text+"\nPress SPACE",dialogStyle);

        }else if (dialogs[curPhase].person == "Director")
        {
            GUI.Label(new Rect(Screen.width /4*2, 80, 10, 10), dialogs[curPhase].person, dialogStyle);
            GUI.Label(new Rect(Screen.width / 4*2, 110, 100, 100), dialogs[curPhase].text + "\nPress SPACE", dialogStyle);
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 3, 80, 10, 10), dialogs[curPhase].person, dialogStyle);
            GUI.Label(new Rect(Screen.width / 3, 110, 100, 100), dialogs[curPhase].text, dialogStyle);
        }

        

    }
}
