using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private AudioSource audio;

    void Start(){
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D()
    {
        audio.Play();
    }
}
