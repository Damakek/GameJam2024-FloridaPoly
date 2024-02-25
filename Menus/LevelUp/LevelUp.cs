using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class LevelUp : MonoBehaviour
{

    public List<GameObject> drugs = new List<GameObject>();

    public GameObject drugA;
    public GameObject drugB;
    public GameObject drugC;

    public Text drugA_description;
    public Text drugB_description;
    public Text drugC_description;

    public GameObject levelUpScreen;
    public GameObject player;

    private void Awake()
    {
        levelUpScreen.SetActive(false);
    }

    public void Start()
    {
        int rand1 = Random.Range(1, drugs.Count);
        int rand2 = rand1;
        int rand3 = rand1;

        while(rand2 == rand1)
        {
            rand2 = Random.Range(1, drugs.Count);
        }

        while(rand3 == rand1 || rand3 == rand2)
        {
            rand3 = Random.Range(1, drugs.Count);
        }

       if(drugA == null)
       {
            drugA = drugs[rand1];

            drugA_description.text = drugA.gameObject.GetComponent<drug>().plus + "+\n" + drugA.gameObject.GetComponent<drug>().minus + "-";
       }
       if(drugB == null)
       {
            drugB = drugs[rand2];

            drugB_description.text = drugB.gameObject.GetComponent<drug>().plus + "+\n" + drugB.gameObject.GetComponent<drug>().minus + "-";
        }
       if(drugC == null)
       {
            drugC = drugs[rand3];

            drugC_description.text = drugC.gameObject.GetComponent<drug>().plus + "+\n" + drugC.gameObject.GetComponent<drug>().minus + "-";
        }
    }

    public void drug_1()
    {
        GameObject temp = GameObject.Instantiate(drugA, player.transform.position, transform.rotation);
        closeWindow();
    }

    public void drug_2()
    {
        GameObject temp = GameObject.Instantiate(drugB, player.transform.position, transform.rotation);
        closeWindow();

    }

    public void drug_3()
    {
        GameObject temp = GameObject.Instantiate(drugC, player.transform.position, transform.rotation);
        closeWindow();
    }

    public void closeWindow()
    {
        Time.timeScale = 1f;
        player.GetComponent<player>().menuUp = false;
        levelUpScreen.SetActive(false);
    }
}
