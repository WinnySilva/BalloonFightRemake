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
    public int Score;
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();

        
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
       Vector2 move = new Vector2(Input.GetAxis("Horizontal"), 0);

        controller.Move(move * Time.deltaTime * speed);


        if (move.x == 0 )
        {
            anim.SetBool("Horizontal", false);
           
        }
        if (move.x > 0)
        {
            anim.SetBool("Horizontal", true);

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -280f, transform.eulerAngles.z);

        }

        if (move.x < 0)
        {
            anim.SetBool("Horizontal", true);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 280f, transform.eulerAngles.z);
        }






        // Changes the height position of the player..


        if (Input.GetButtonDown("Jump"))
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

            if (groundedPlayer == true)
            {
                anim.SetTrigger("jump");
            }

            if ( groundedPlayer== false)
            {
                
                anim.SetBool("fly", true);


            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);



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



