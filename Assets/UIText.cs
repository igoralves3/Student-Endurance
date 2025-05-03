using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{


    Canvas m_canvas;

    // Start is called before the first frame update
    void Start()
    {
        m_canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        var m_text = m_canvas.GetComponent<Text>();
        m_text.text = "HP: "+ MainStudent.hp.ToString() + "\nLifes: "+ MainStudent.lifes.ToString();
        m_text.text += "\nOranges: " + MainStudent.oranges.ToString();
        
    }

    /*
    void OnGUI()
    {

        GUI.Label(new Rect(10, 20, 200, 60), m_canvas.GetComponent<TextMesh>().text.ToString());
        
    }*/

}
