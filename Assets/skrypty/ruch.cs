using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class ruch : MonoBehaviour
{
    private int souls;
    public int soulsCount;
    public TextMeshProUGUI soulText;

    public TextMeshProUGUI soulsall;
    public TextMeshProUGUI endlvl;
    public float Playerspeed;
    public int allsouls;
    private float timer = 0;
    public int tipTime = 5;
    public SpriteRenderer spajt;

    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left *Playerspeed);
            spajt.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right *Playerspeed);
            spajt.flipX = false;
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
        soulsall.text = allsouls.ToString();
        if( souls == allsouls)
        {
            if (timer <= tipTime)
            {
                if (timer < 3)
                {
                    endlvl.text = ("You collected all souls!!");
                    timer += Time.deltaTime;
                }
                else
                {
                    endlvl.text = ("Find the exit!!");
                    timer += Time.deltaTime;
                }
            }
            else {
                endlvl.text = ("");
            }
        }
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

