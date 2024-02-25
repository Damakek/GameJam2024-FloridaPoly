using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemyP;
    public GameObject loseScreen;

    public float spawnRate;
    public bool gameEnded = false;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<player>().menuUp)
            Time.timeScale = 0;
        else
            Time.timeScale = 1f;
    }

    public IEnumerator spawnEnemy()
    {
        while(gameEnded == false)
        {
            spawnRate = 1 / ((Time.timeSinceLevelLoad * 0.001f) + 1f);

            yield return new WaitForSeconds(spawnRate);

            Instantiate(enemyP, this.transform.position, transform.rotation);
        }
    }
}
