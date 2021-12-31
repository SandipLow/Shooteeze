using UnityEngine;
using UnityEngine.UI;

public class EnterCode : MonoBehaviour
{
    public Text input;
    public GameObject Door;
    public GameObject gameOver;
    public GameManager gameManager;
    public string code;

    // Start is called before the first frame update
    public void Starter()
    {
        Time.timeScale = 0;
        gameManager.player.GetComponent<FPSCharacterController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
    }

    public void inputNo(string n)
    {
        // input.text += gameObject.transform.GetChild(0).GetComponent<Text>().text;
        input.text += n;
    }

    public void delete()
    {
        if (input.text != "")
        {
            input.text = input.text.Remove(input.text.Length - 1);
        }
    }

    public void enter()
    {
        if (input.text == gameObject.GetComponent<EnterCode>().code)
        {
            input.text = "Correct Code";
            Invoke("none", 2000f);
            gameObject.GetComponent<EnterCode>().Door.SetActive(false);
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
		    Cursor.visible = false;
            Time.timeScale = 1;
            if (gameManager.isPC)
            {
                gameManager.player.GetComponent<FPSCharacterController>().enabled = true;
            }
        }

        else
        {
            input.text = "Incorrect code!!";
            Invoke("none", 2000f);
            gameObject.GetComponent<EnterCode>().gameOver.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void exit() {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        if (gameManager.isPC)
        {
            gameManager.player.GetComponent<FPSCharacterController>().enabled = true;
        }
        Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
    }

    void none(){}

}
