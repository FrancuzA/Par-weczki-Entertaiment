using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left *0.001f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 0.001f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * 0.001f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * 0.001f);
        }

       
    }
    
}

