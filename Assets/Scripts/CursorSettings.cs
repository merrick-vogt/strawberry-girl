using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; // This line hides the cursor 
    }

    void Update()
    {
        if (Cursor.visible)
        {
            Cursor.visible = false;
        }
    }


}
