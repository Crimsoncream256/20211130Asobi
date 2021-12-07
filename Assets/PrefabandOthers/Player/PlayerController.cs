using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    //public Text goalText;
    public Text failText;
    public Text makeOshimiText;

    public bool goalOn;
    public float speed = 2.0f;
    public float brake = 0.5f;
    public float jumpForce = 20.0f;
    public float turboForce = 2.0f;

    private Rigidbody rB;
    private Vector3 rbVelo;
    public ParticleSystem explosion;
    private Vector3 height;

    void Start()
    {
        rB = GetComponent<Rigidbody>();
        //goalText.enabled = false;
        goalOn = false;
        failText.enabled = false;
        makeOshimiText.enabled = false;
    }
    void Update()
    {

        if (goalOn == false)
        {
            rbVelo = Vector3.zero;
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            rbVelo = rB.velocity;
            rB.AddForce(x * speed - rbVelo.x * brake, 0, z * speed - rbVelo.z * brake, ForceMode.Impulse);
        }

        height = this.GetComponent<Transform>().position;
        if (height.y <= -3.0f)
        {
            explosion.transform.position = this.transform.position;
            explosion.Play();
            failText.enabled = true;
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            //other.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
            rB.AddForce(-rbVelo.x * 0.8f, 0, -rbVelo.z * 0.8f, ForceMode.Impulse);
            //goalText.enabled = true;
            goalOn = true;
        }

        if (other.gameObject.tag == "Jump")
        {
            rB.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Kill")
        {
            explosion.transform.position = other.transform.position;
            explosion.Play();
            failText.enabled = true;
            if(goalOn == true)
            {
                makeOshimiText.enabled = true;
            }
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Bounce")
        {
            StartCoroutine("WaitKeyInput");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Turbo")
        {
            Vector3 vel = rB.velocity;
            rB.AddForce(vel.x * turboForce, 0, vel.z * turboForce, ForceMode.Impulse);
        }
    }

    IEnumerator WaitKeyInput()
    {
        this.gameObject.GetComponent<PlayerController>().enabled = false;
        {
            yield return new WaitForSeconds(0.5f);
        }
        this.gameObject.GetComponent<PlayerController>().enabled = true;
    }
}
