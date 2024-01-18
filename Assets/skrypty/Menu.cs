using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public Animator animator;
    public float timer = 0.0f;
    private bool isPlayClicked = false;

    private void Update()
    {
        if (isPlayClicked)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                SceneManager.LoadScene(1);
            }
            
        }
    }
    public void LoadLevel(int index)
    {
        isPlayClicked = true;
        animator.Play("menu 0");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
  


}
