using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : NetworkBehaviour
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
    public PlayerBallon playerBallon;
    public Vector3 move;
    public int Score;
    private void Start()

    {
        if (!this.IsOwner)
        {
            return;
        }
        controller = GetComponent<CharacterController>();
        m_Rigidbody = GetComponent<Rigidbody>();

        controller.enabled = true;
        playerBallon.UmBalaoSobrando += UmBalaoSobrando;
        playerBallon.SemBaloesSobrando += SemBaloesSobrando;

    }

    void OnDestroy()
    {
        playerBallon.UmBalaoSobrando += UmBalaoSobrando;
        playerBallon.SemBaloesSobrando += SemBaloesSobrando;
    }

    void Update()
    {
        if (!this.IsOwner)
        {
            return;
        }

        groundedPlayer = controller.isGrounded;
        moviment();        
    }

    void stopanim()
    {
        anim.SetBool("jump", false);
    }

    void moviment()
    {

        move = new Vector3(Input.GetAxis("Horizontal"), 0);

        controller.Move(move * Time.deltaTime * speed);
        anim.SetBool("fly", !groundedPlayer);
        anim.SetBool("grouded", groundedPlayer);
        if (move.x == 0 && groundedPlayer == true)
        {
            anim.SetBool("Horizontal", false);
        }

        if (move.x > 0)
        {
            // transform.eulerAngles = new Vector3(transform.eulerAngles.x, -280f, transform.eulerAngles.z);
            anim.SetBool("Horizontal", true);
        }

        if (move.x < 0)
        {
            //transform.eulerAngles = new Vector3(transform.eulerAngles.x, 280f, transform.eulerAngles.z);
            anim.SetBool("Horizontal", true);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump"))
        {

            if (groundedPlayer == true)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3f * gravityValue);
                anim.SetTrigger("jump");
                anim.SetBool("Horizontal", false);
                anim.SetBool("grouded", false);
               
            }

            if (groundedPlayer == false)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3f * gravityValue);
                anim.SetBool("grouded", false);
                anim.SetBool("fly", true);
                anim.SetBool("Horizontal", false);

            }

        }

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;

        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "ground")
        {
            anim.SetBool("grouded", true);
        }
    }


    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "ground")
        {
            anim.SetBool("grouded", false);
        }
    }
 
    private void SemBaloesSobrando()
    {
        balloon2.SetActive(false);
        gravityValue = -10000;
    }

    private void UmBalaoSobrando()
    {
        balloon.SetActive(false);
    }

}