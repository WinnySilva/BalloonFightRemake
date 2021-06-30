using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


public class enemy : MonoBehaviour
{
    public NavMeshAgent nave;
    public bool caca;
    public Transform alvo;
    public float speed;
    public Animator anim;
    public Collider enemys;
    private Vector3 playerVelocity;
    public GameObject balloon;
    private CharacterController controller;
    public List<Transform> Alvos;

    private bool groundedPlayer;
    public float gravityValue = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        GeraAlvo();

        controller = gameObject.AddComponent<CharacterController>();

      

    }

    // Update is called once per frame
    void Update()
    {

       
        
       


        if (ballon.cair == true)
        {
            anim.SetBool("fall", true);
            


        }

        //OnTriggerS(enemys);
        OnTriggerEnter(enemys);

        if (caca == true)
        {
            hunt();

        }
        groundedPlayer = controller.isGrounded;
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);




     




    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pballon")
        {
            alvo = other.transform;
        }
    }

    void entrada()
    {
        balloon.SetActive(true);
        caca = true;
        nave.GetComponent<NavMeshAgent>().enabled = true;
        anim.SetBool("fly", true);

    }
    void groundout()
    {
        playerVelocity.y += Mathf.Sqrt(100 * -3.0f * gravityValue);
         gameObject.GetComponent<CharacterController>().enabled = false;
        anim.SetBool("fly", true);
    }




        void MoveCharacter(Vector3 frameMovement)
        {
            transform.position += frameMovement;
            frameMovement.z = 0;
        }




    public void GeraAlvo()
    {
        var rnd = new System.Random();
        var valorAleatorio = Alvos[rnd.Next(Alvos.Count)];
        alvo = valorAleatorio;
    }


    void NaveHunt(Transform alvo)
    {
        nave.SetDestination(alvo.transform.position);
        Vector3 direction = alvo.position - transform.position;
        float distanceToTarget = direction.magnitude;
        direction.Normalize();


        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -280f, transform.eulerAngles.z);
        }
        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 280f, transform.eulerAngles.z);
        }

    }





    void hunt()   // caça o inimigo
        {
            Vector3 direction = alvo.position - transform.position;
        

        

        float distanceToTarget = direction.magnitude;


            direction.Normalize();








        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -280f, transform.eulerAngles.z);
        }
        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 280f, transform.eulerAngles.z);
        }







        float distanceWantsToMoveThisFrame = speed * Time.deltaTime;
            float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - 1), distanceWantsToMoveThisFrame);

            MoveCharacter(actualMovementThisFrame * direction);
        }

       
    }







