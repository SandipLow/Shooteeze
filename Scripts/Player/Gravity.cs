using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravity = 9.81f;
    public float jumpHeight = 1f;
    public GameObject groundCheck;
    public LayerMask groundLayerMask;
    public CharacterController characterController;
    
    bool isGrounded;
    Vector3 velocity;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, 0.1f, groundLayerMask);
        
        if (!isGrounded)
        {
            velocity.y -= gravity*Time.deltaTime;
            //Debug.Log("not Grounded");
        }

        else
        {
            velocity.y = 0f;
            //Debug.Log("Grounded");
        }
        
        //Jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight*0.1f * 2 * gravity);
        }

        characterController.Move(velocity);
    }


}
