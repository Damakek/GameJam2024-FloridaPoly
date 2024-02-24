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

    public Button drugA_B;
    public Button drugB_B;
    public Button drugC_B;


    public TextMeshProUGUI A_info;
    public TextMeshProUGUI B_info;
    public TextMeshProUGUI C_info;



    public void drug_1()
    {
        //instantiate drug in worldspace
        closeWindow();
    }

    public void drug_2()
    {
        //instantiate drug in worldspace
        closeWindow();

    }

    public void drug_3()
    {
        //instantiate here
        closeWindow();
    }

    public void closeWindow()
    {
        Destroy(this.gameObject);
    }

    public void Start()
    {
        //something like this to set the image for drug on the button
       //drugA_B.image.sprite = drugA.gameObject.GetComponent<>
    }
}
