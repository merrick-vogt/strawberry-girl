using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // KeyCode.Return represents the Enter key
        {
            Quit();
        }
    }

    public void Quit()
    {
        Application.Quit();

    }
}
