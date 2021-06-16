using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pegaplayer : MonoBehaviour
{

    public GameObject peixe;
    public Transform alvo;
    public Animator anim;
    
    public bool caca;


    // Start is called before the first frame update
    void Start()
    {
        //peixe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

       
        if (caca == true) {

            hunt();
        }

    }

    
        
        

      




        


        
          
        
        

        

        
    
        void MoveCharacter(Vector3 frameMovement)
        {
    transform.position += frameMovement;
        }
        void OnTriggerExit(Collider player)
        {

            if (player.gameObject.tag == "Player")
            {


                anim.SetBool("aparece", false);
            alvo = null;
            caca = false;
                //peixe.SetActive(true);
                // peixe.anim.SetBool("olhar", false);
            }



            if (player.gameObject.tag == "Enemy")
            {


                anim.SetBool("aparece", false);

                //peixe.SetActive(true);
                // peixe.anim.SetBool("olhar", false);
            }



        }

    void hunt()   // caça o inimigo
    {
        Vector3 direction = alvo.position - transform.position;

        direction.y = 0;
        
        float distanceToTarget = direction.magnitude;
        
        
        direction.Normalize();

       
               

      










        float distanceWantsToMoveThisFrame = 10000f * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - 1), distanceWantsToMoveThisFrame);

        MoveCharacter(actualMovementThisFrame * direction);
    }



}
