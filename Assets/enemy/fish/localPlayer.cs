using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localPlayer : MonoBehaviour

{

    public GameObject peixe;
   
    public Collider intercept;
 


    // Start is called before the first frame update
    void Start()
    {
        //peixe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {


         peixe.GetComponent<Animator>().SetBool("aparece", true);
            peixe.GetComponent<Pegaplayer>().alvo = player.transform;
            peixe.GetComponent<Pegaplayer>().caca = true;
            //peixe.SetActive(true);
            // peixe.anim.SetBool("olhar", false);
            

        }

        if (player.gameObject.tag == "Enemy")
        {


            peixe.GetComponent<Animator>().SetBool("aparece", true);
            peixe.GetComponent<Pegaplayer>().alvo = player.transform;
            peixe.GetComponent<Pegaplayer>().caca = false;
        
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


            peixe.GetComponent<Animator>().SetBool("aparece", false);
            peixe.GetComponent<Pegaplayer>().alvo = player.transform;
            peixe.GetComponent<Pegaplayer>().caca = false;
        }



        if (player.gameObject.tag == "Enemy")
        {

            peixe.GetComponent<Animator>().SetBool("aparece", false);
            peixe.GetComponent<Pegaplayer>().alvo = player.transform;
            peixe.GetComponent<Pegaplayer>().caca = false;
        }



    }


}

