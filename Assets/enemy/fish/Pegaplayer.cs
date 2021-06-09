using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pegaplayer : MonoBehaviour
{

    public GameObject peixe;
    public GameObject alvo;
    public Animator anim;
    public Collider intercept;
  

    // Start is called before the first frame update
    void Start()
    {
        //peixe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter(intercept);
        OnTriggerExit(intercept);
    }

    void OnTriggerEnter(Collider player)
    {
        
            if (player.gameObject.tag == "Player")
            {
            

            anim.SetBool("aparece",true);
                    //peixe.SetActive(true);
            // peixe.anim.SetBool("olhar", false);
        }
        
    }


    void OnTriggerExit(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {


            anim.SetBool("aparece", false);
            //peixe.SetActive(true);
            // peixe.anim.SetBool("olhar", false);
        }

    }

  


}
