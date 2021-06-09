using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float speed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public Animator anim;
    public Collider player;
    public GameObject balloon;
    public GameObject balloon2;
    private Rigidbody m_Rigidbody;
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();

        m_Rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        groundedPlayer = controller.isGrounded;
        moviment();
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        OnTriggerStay(player);
        LostBallon();
    }   

        void stopanim()
        {
            anim.SetBool("jump", false);
        }




        void moviment()
        {
            // if (groundedPlayer && playerVelocity.y < 0)
            //{
            //   playerVelocity.y = 0f;
            // }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0);
            controller.Move(move * Time.deltaTime * speed);
            anim.SetFloat("Horizontal", move.x);
            anim.SetFloat("speed", move.magnitude);
            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;

            }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump"))
            {

        //m_Rigidbody.AddForce(playerVelocity.y * jumpHeight, ForceMode.Force);
             playerVelocity.y += Mathf.Sqrt(jumpHeight * -3f * gravityValue);
            if (groundedPlayer == true)
                {

                    anim.SetTrigger("jump");
                }
                if (groundedPlayer == false)
                {
                    anim.SetBool("grouded", true);
                    anim.SetTrigger("jump");
                  
                }

            }





        }


        void OnTriggerStay(Collider player)
        {
            if (player.gameObject.tag == "ground")
            {
                anim.SetBool("grouded", false);
            }
        }

    void LostBallon()
    {
        if (PlayerBallon.Instance.cair < 2)
        {
            balloon.SetActive(false);

        }

        if (PlayerBallon.Instance.cair < 1)
        {
            balloon2.SetActive(false);
            gravityValue = -10000;
            //player.SetActive(false);
        }

    }
}



