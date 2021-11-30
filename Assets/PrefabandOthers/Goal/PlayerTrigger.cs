using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private AudioSource audioSE;
    public AudioClip sound01;
    private bool killSEflag = true;

    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 0.5f);
        audioSE = gameObject.AddComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("ごーる");
            this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
            audioSE.PlayOneShot(sound01);
            killSEflag = false;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
        }
    }
}
