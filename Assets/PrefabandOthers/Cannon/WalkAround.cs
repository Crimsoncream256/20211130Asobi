using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkAround : MonoBehaviour
{
    public GameObject muzzlePoint; // 弾を発射する場所
    public GameObject ball; // 再セットする弾のオブジェクト
    public float speed = 30f; // 弾のスピード
    private int attackTime = 0; // 弾の発射までのカウント
    public int intvalTime = 30; // 弾の発射する間隔

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public GameObject target;
    private bool inArea = false;
    public float chaspeed = 0.05f;

    public Color origColor;

    public Material[] _matters;


    private void Start()
    {
        this.GetComponent<Renderer>().material = _matters[0];
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
        //print("ネムイ");
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }


    public void EneCannonShot()
    {
        if (target.activeInHierarchy == false)
        {
            //GetComponent<Renderer>().material.color = origColor;
            this.GetComponent<Renderer>().material = _matters[0];
            //print("消してやったリ");
            inArea = false;
        }
        //print("撃て！");
        Vector3 mballPos = muzzlePoint.transform.position;
        GameObject newBall = Instantiate(ball, mballPos, transform.rotation);
        Vector3 dir = newBall.transform.forward;
        newBall.GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Impulse);
        newBall.name = ball.name;
        Destroy(newBall, 0.8f);          

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(target.transform.position - transform.position), Time.deltaTime * 3.0f);
            inArea = true;
            target = other.gameObject;
            GetComponent<Renderer>().material.color = new Color(255f / 255f, 65f / 255f, 26f / 255f, 255f / 255f);
            this.GetComponent<Renderer>().material = _matters[1];
            //print("なにものダ");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //print("どこいきやがっタ");
            inArea = false;
            //GetComponent<Renderer>().material.color = origColor;
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

        if (inArea == true)
        {
            attackTime += 1;
            transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(target.transform.position - transform.position), Time.deltaTime * 30.0f);
            if (attackTime % intvalTime == 0)
            {
                EneCannonShot();
            }
        }
    }
}
