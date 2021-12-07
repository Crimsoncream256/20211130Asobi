using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotate : MonoBehaviour
{
    public float rotSpeed = 1.0f;
    
    void Start()
    {
        //GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody.angularVelocity = new Vector3();
        transform.Rotate(new Vector3(rotSpeed, 0, 0));
    }
}
