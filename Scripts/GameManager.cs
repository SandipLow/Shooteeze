using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public bool isPC;

    private void Start() 
    {
        if (isPC)
        {
            player.GetComponent<FPSCharacterController>().enabled = true;
            player.GetComponent<FPSControllerTouchScreen>().enabled = false;
        }

        else
        {
            player.GetComponent<FPSCharacterController>().enabled = false;
            player.GetComponent<FPSControllerTouchScreen>().enabled = true;
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void exit()
    {
        Application.Quit();
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void tooglePCTouch(bool isPC)
    {
        if (isPC)
        {
            player.GetComponent<FPSCharacterController>().enabled = false;
            player.GetComponent<FPSControllerTouchScreen>().enabled = true;
            isPC = false;
        }

        else
        {
            player.GetComponent<FPSCharacterController>().enabled = true;
            player.GetComponent<FPSControllerTouchScreen>().enabled = false;
            isPC = true;
        }
    }

    public void openWeb(string URL)
    {
        Application.OpenURL(URL);
    }
}
