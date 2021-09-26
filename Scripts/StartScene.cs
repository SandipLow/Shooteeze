using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    
    public void Starter()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
    }
}
