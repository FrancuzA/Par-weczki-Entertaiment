using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip backround;
    void Start()
    {
        musicSource.clip = backround;
        musicSource.Play();
    }
}
