using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalUI : MonoBehaviour
{
    public Text goalText;
    public Text textLose;
    private bool gameOn;

    void Start()
    {
        goalText.enabled = false;
        textLose.enabled = false;
        gameOn = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rival" && gameOn == true)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
            textLose.enabled = true;
            gameOn = false;
        }
        if (other.gameObject.tag == "Player" && gameOn == true)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
            GameObject.Find("Player").GetComponent<PlayerController>().goalOn = true;
            goalText.enabled = true;
            gameOn = false;
        }
    }

}
