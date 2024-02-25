using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class LevelUp : MonoBehaviour
{

    public GameObject drugA;
    public GameObject drugB;
    public GameObject drugC;

    public GameObject levelUpScreen;
    public GameObject player;

    private void Awake()
    {
        levelUpScreen.SetActive(false);
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
