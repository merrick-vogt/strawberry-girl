using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // KeyCode.Return represents the Enter key
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

