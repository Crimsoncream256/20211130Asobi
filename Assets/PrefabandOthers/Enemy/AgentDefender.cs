using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentDefender : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public GameObject target;
    private bool inArea = false;
    public float chaspeed = 0.05f;
    public Color origColor;

    public Material[] _matters;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        this.GetComponent<Renderer>().material = _matters[0];
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
    public void EneChasing()
    {
        transform.position += transform.forward * chaspeed;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inArea = true;
            target = other.gameObject;
            GetComponent<Renderer>().material.color = new Color(255f / 255f, 65f / 255f, 26f / 255f, 255f / 255f);
            this.GetComponent<Renderer>().material = _matters[1];
            EneChasing();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inArea = false;
            GetComponent<Renderer>().material.color = origColor;
            this.GetComponent<Renderer>().material = _matters[0];
            GotoNextPoint();
        }
    }


    void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
        if (target.activeInHierarchy == false)
        {
            GetComponent<Renderer>().material.color = origColor;
            this.GetComponent<Renderer>().material = _matters[0];
        }
        if (inArea == true && target.activeInHierarchy == true)
        {
            agent.destination = target.transform.position;
            EneChasing();
        }
    }
}
