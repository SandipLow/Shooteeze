using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;
    void Update()
    {
        if (Input.GetKey("r"))
        {
		    gameManager.Reload();
        }

        if(Input.GetKey("e"))
        {
            gameManager.exit();
        }
    }
}