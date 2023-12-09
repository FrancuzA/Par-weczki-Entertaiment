using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using Unity.Mathematics;

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
    public Transform player;
    public Transform indicator;
    public GameObject triangle;
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

           GameObject closestObject = findclosest();
            if (closestObject != null)
            {
                Rotateindicator(closestObject.transform.position);
            }
            else
            {
                triangle.SetActive(false);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right *Playerspeed);
            spajt.flipX = false;
            

            GameObject closestObject = findclosest();
            if (closestObject != null)
            {
                Rotateindicator(closestObject.transform.position);
            }
            else
            {
                triangle.SetActive(false);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Playerspeed);

            GameObject closestObject = findclosest();
            if (closestObject != null)
            {
                Rotateindicator(closestObject.transform.position);
            }
            else
            {
                triangle.SetActive(false);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Playerspeed);

            GameObject closestObject = findclosest();
            if (closestObject != null)
            {
                Rotateindicator(closestObject.transform.position);
            }
            else
            {
                triangle.SetActive(false);
            }
        }
        
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

    GameObject findclosest()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("soul");
        float closestDistance = Mathf.Infinity;
        GameObject closestObject = null;

        foreach (GameObject obj in objectsWithTag)
        {
            float distance = Vector3.Distance(player.position, obj.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj;
            }
        }

        return closestObject;
    }

    void Rotateindicator(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - indicator.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        indicator.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }

}

