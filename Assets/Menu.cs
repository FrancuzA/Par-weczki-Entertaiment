using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Update()
    {
       
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
