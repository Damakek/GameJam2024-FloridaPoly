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

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        attack = (int)(Time.timeSinceLevelLoad/10) + 2;
        hp = (int)(Time.timeSinceLevelLoad / 20) + 1;
        Debug.Log(attack);
        player = GameObject.FindGameObjectWithTag("Player");   
        p = player.GetComponent<player>();
        myRig = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
            audioManager.PlaySFX(audioManager.enemyHit);
            hp--;
            if (hp <= 0) {
                p.defeatEnemy(amount);
                Destroy(gameObject);
            }
        }
    }
}
