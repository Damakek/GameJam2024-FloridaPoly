using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public int hp;
    public float speed = 3f;
    public int attack;

    public GameObject player;
    public player p;
    public int amount;
    Rigidbody myRig;

    // Start is called before the first frame update
    void Start()
    {
        attack = (int)(Time.timeSinceLevelLoad/10) + 2;
        hp = (int)(Time.timeSinceLevelLoad / 20) + 1;
        Debug.Log(attack);
        player = GameObject.FindGameObjectWithTag("Player");   
        p = player.GetComponent<player>();
        myRig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //walk towards player - we can add a proximity by saying "hey if that's < threshold" or smth
        if (!p.menuUp)
        {
            Vector3 playerPos = player.transform.position;
            Time.timeScale = 1f;
            transform.up = (gameObject.transform.position - playerPos).normalized;
            myRig.velocity = transform.up * speed * -1;
        }
        else
            Time.timeScale = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            hp--;
            if (hp <= 0) {
                p.defeatEnemy(amount);
                Destroy(gameObject);
            }
        }
    }
}
