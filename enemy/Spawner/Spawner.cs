using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemyP;
    public GameObject loseScreen;

    public float spawnRate;
    public bool gameEnded = false;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator spawnEnemy()
    {

        while(gameEnded == false)
        {
            spawnRate = 1 * Time.timeSinceLevelLoad + 0.5f;

            Debug.Log("I have entered the coroutine");

            yield return new WaitForSeconds(spawnRate);

            Debug.Log("I am about to spawn a thing");

            Instantiate(enemyP, this.transform.position, transform.rotation);
        }
        
    }
}
