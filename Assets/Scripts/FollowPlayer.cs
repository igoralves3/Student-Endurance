using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public float minX, maxX, minY, maxY;
    public float timeLerp;

    private Color outsideSchool = new Color(0.0f,1.0f,1.0f);
    private Color insideSchool = new Color(0.196f,0.804f,0.196f);
    private Color stormSchool = new Color(0xB5 / 255.0f, 0x7E / 255.0f, 0xDC/255.0f);

    private Color[] levelBackgrounds;

    // Start is called before the first frame update
    void Start()
    {
        levelBackgrounds = new Color[]{
            outsideSchool,
            insideSchool,
            insideSchool,
            insideSchool,
            outsideSchool,
            outsideSchool,
            insideSchool,
            stormSchool,
            stormSchool,
            outsideSchool,
           insideSchool,
           insideSchool,
                insideSchool,
                insideSchool,
                insideSchool,
                insideSchool,
                insideSchool,
                insideSchool,
                insideSchool,
                insideSchool,
                insideSchool
        };


        player = GameObject.FindWithTag("Player").transform;

        var cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;

        Scene scene = SceneManager.GetActiveScene();

        cam.backgroundColor = levelBackgrounds[scene.buildIndex-1];
        /*
        if (scene.buildIndex == 0 || scene.buildIndex == 4)
        {
            
                cam.backgroundColor = new Color(0.0f,1.0f,1.0f);

        }
        if (scene.buildIndex == 1 || scene.buildIndex == 2 || scene.buildIndex == 3)
        {
            cam.backgroundColor = new Color(1.0f, 1.0f, 0.0f);
        }
        if (scene.buildIndex == 5)
        {

            cam.backgroundColor = new Color(0.0f, 1.0f, 1.0f);

        }
        if (scene.buildIndex == 6)
        {
            cam.backgroundColor = new Color(1.0f, 1.0f, 0.0f);
        }
        if (scene.buildIndex == 7 || scene.buildIndex == 8 || scene.buildIndex == 9)
        {

            cam.backgroundColor = new Color(0.0f, 1.0f, 1.0f);

        }*/
    }

   


    void Update() {
        Vector3 newPosition = player.position + new Vector3(0, 0, -10);
        
        newPosition = Vector3.Lerp(transform.position, newPosition,timeLerp);
        transform.position = newPosition;
        transform.position = new Vector3(Mathf.Clamp(
            transform.position.x, transform.position.x-minX, transform.position.x+maxX), 
            Mathf.Clamp(transform.position.y, transform.position.y - minY, transform.position.y + maxY),
            transform.position.z);
    }
}

