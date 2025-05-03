using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartVoid : MonoBehaviour
{

    public GameObject entry;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (MainStudent.lifes > 1)
            {
                MainStudent.lifes = MainStudent.lifes - 1;
                MainStudent.hp = 100;
                SceneManager.LoadScene(MainStudent.cenaAtual);
            }
            else
            {
                MainStudent.cenaAtual = "Stage0";
                MainStudent.lifes = 3;
                SceneManager.LoadScene("Stage0");
            }
        }
        else if (col.gameObject.tag == "PartnerStudent")
        {
            var newPosition = transform.position;
            var novaEntrada = Instantiate(entry, newPosition, transform.rotation) as GameObject;
            Destroy(gameObject);
        }
    }
}
