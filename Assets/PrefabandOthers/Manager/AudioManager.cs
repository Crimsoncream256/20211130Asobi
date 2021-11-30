using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    private GameObject player;
    private AudioSource audioSE;
    public AudioClip sound01;
    private bool killSEflag = true;
    void Start()
    {
        audioSE = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null && killSEflag == true)
        {
            audioSE.PlayOneShot(sound01);
            killSEflag = false;
        }
    }
}