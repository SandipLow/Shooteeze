using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterCode : MonoBehaviour
{
    public Text input;
    public GameObject glass;
    public GameObject gameOver;
    public GameObject enterCode;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
    }

    public void inputNo()
    {
        input.text += gameObject.GetComponent<Text>().text;
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
        if (input.text == "7265")
        {
            input.text = "Correct Code";
            glass.SetActive(false);
            enterCode.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
		    Cursor.visible = false;
        }

        else
        {
            gameOver.SetActive(true);
            enterCode.SetActive(false);
            Time.timeScale = 0;
        }
    }

}
