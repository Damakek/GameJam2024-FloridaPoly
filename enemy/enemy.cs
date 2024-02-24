using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public int hp;
    public float speed = 3f;
    public int attack;

    public GameObject player;
    Rigidbody myRig;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
        myRig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //walk towards player - we can add a proximity by saying "hey if that's < threshold" or smth
        Vector3 playerPos = player.transform.position;
        if (player == null)
        {
            myRig.velocity = Vector3.zero;
        }
        else
        {
            transform.up = (gameObject.transform.position - playerPos).normalized;
            myRig.velocity = transform.up * speed * -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            hp--;
            if (hp <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
