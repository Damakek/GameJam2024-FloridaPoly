using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseScreen : MonoBehaviour
{
    public GameObject loseScreen;

    private void Awake()
    {
        loseScreen.SetActive(false);
    }

    public void Retry()
    {
        Debug.Log("Retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void btMAIN()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
