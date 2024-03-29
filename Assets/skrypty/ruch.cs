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
    public Rigidbody2D RB;
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
    public GameObject exit;
    [System.Obsolete]
    public GameObject _wallhitbox;
    public GameObject _exit;
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            spajt.flipX = true;

           GameObject closestObject = findclosest();
            if (closestObject != null)
            {
                Rotateindicator(closestObject.transform.position);
            }
            else
            {
                closestObject = exit;
                Rotateindicator(closestObject.transform.position);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            spajt.flipX = false;
            

            GameObject closestObject = findclosest();
            if (closestObject != null)
            {
                Rotateindicator(closestObject.transform.position);
            }
            else
            {
                closestObject = exit;
                Rotateindicator(closestObject.transform.position); ;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            GameObject closestObject = findclosest();
            if (closestObject != null)
            {
                Rotateindicator(closestObject.transform.position);
            }
            else
            {
                closestObject = exit;
                Rotateindicator(closestObject.transform.position);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            GameObject closestObject = findclosest();
            if (closestObject != null)
            {
                Rotateindicator(closestObject.transform.position);
            }
            else
            {
                closestObject = exit;
                Rotateindicator(closestObject.transform.position);
            }
        }
        soulText.text = souls.ToString();
        soulsall.text = allsouls.ToString();
        if( souls == allsouls)
        {
            exit.SetActive(true);
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
            _exit.SetActive(false);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.H)) {
            _wallhitbox.GetComponent<PolygonCollider2D>().enabled = false;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.H)){
            Playerspeed = 60;
        }
    }

    public void FixedUpdate()
    {
        PlayerMovement();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("soul"))
        {
            other.gameObject.SetActive(false);
            souls++;
        }
        if (other.gameObject.CompareTag("EXIT"))
        {
            SceneManager.LoadScene(2);
            Debug.Log("exit");
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


    public void PlayerMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        RB.AddForce(new Vector2(moveX, moveY).normalized * Playerspeed, ForceMode2D.Force);
    }
}

