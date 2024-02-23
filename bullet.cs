using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bullet : MonoBehaviour
{
    public float speed = 3.0f;
    public Rigidbody myRig;
    public GameObject cam;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        myRig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        myRig.velocity = transform.up * speed;
        if (Math.Abs((cam.transform.position - gameObject.transform.position).magnitude) > 15)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy" && gameObject.tag == "playerBullet")
        {
            Destroy(gameObject);
        }
    }
}