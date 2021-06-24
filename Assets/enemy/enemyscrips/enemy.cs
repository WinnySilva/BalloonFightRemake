using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public NavMeshAgent nave;
    public bool caca;
    public Transform alvo;
    public float speed;
    public Animator anim;
    public Collider enemys;
    private Vector3 playerVelocity;
   

    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
        
       
    }

    // Update is called once per frame
    void Update()
    {

        


        if (ballon.cair == true)
        {
            anim.SetBool("fall", true);
          nave.GetComponent<NavMeshAgent>().speed = 80f;
          


        }

        //OnTriggerEnter(enemys);
        //OnTriggerExit(enemys);

        if (caca == true) 
        {
            navehunt(alvo);
        }
        


    }




    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "ground")
        {
            anim.SetBool("grouded", false);
            caca = false;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "ground")
        {
            anim.SetBool("grouded", true);
            caca = true;
        }
    }


    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }






    void hunt()   // caça o inimigo
    {
        Vector3 direction = alvo.position - transform.position;

        

        float distanceToTarget = direction.magnitude;


        direction.Normalize();















        float distanceWantsToMoveThisFrame = speed * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - 1), distanceWantsToMoveThisFrame);

        MoveCharacter(actualMovementThisFrame * direction);
    }

    void navehunt(Transform alvo)
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
}





