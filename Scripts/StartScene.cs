using UnityEngine;

public class StartScene : MonoBehaviour
{
    private void Start() {
        Time.timeScale = 0;
    }
    
    public void Starter()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
        Time.timeScale = 1;
    }
}
