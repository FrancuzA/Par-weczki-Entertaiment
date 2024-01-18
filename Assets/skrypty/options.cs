using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    [SerializeField] private GameObject canva;
    [SerializeField] private AudioMixer audioMixer;
    public void PlayGame()
    {
        SceneManager.LoadScene(0);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canva.SetActive(!canva.activeInHierarchy);
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void AdjustRadioVolume(float value)
    {
        audioMixer.SetFloat("Volume", value);
    }
}
