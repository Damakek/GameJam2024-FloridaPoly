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

    public void drug_1()
    {
        GameObject temp = GameObject.Instantiate(drugA, this.gameObject.transform.position, transform.rotation);
        closeWindow();
    }

    public void drug_2()
    {
        GameObject temp = GameObject.Instantiate(drugB, this.gameObject.transform.position, transform.rotation);
        closeWindow();

    }

    public void drug_3()
    {
        GameObject temp = GameObject.Instantiate(drugC, this.gameObject.transform.position, transform.rotation);
        closeWindow();
    }

    public void closeWindow()
    {
        Destroy(gameObject);
    }
}
