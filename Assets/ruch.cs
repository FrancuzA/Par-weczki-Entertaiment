using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class ruch : MonoBehaviour
{
    private int souls;
    public int soulsCount;
    public TextMeshProUGUI soulText;
    public int Playerspeed;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left *Playerspeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right *Playerspeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Playerspeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Playerspeed);
        }
        Debug.Log("DUSZE: " + souls);
        soulText.text = souls.ToString();


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("soul"))
        {
            other.gameObject.SetActive(false);
            souls++;
        }
    }

}

