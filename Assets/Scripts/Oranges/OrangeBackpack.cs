using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBackpack : MonoBehaviour
{

    public int oranges;

    // Start is called before the first frame update
    void Start()
    {
        oranges = Random.Range(1,15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
