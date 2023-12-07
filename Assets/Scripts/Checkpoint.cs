using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted = false;

    void Start()
    {
        finishSound = GetComponent<AudioSource>();
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if ((collision.gameObject.name == "Player" || collision.gameObject.name == "Warrior") && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
