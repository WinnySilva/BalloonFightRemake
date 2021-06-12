using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pegou : MonoBehaviour
{
    public GameObject peixe;
    public Transform alvo;
    public Animator anim;
    public Collider take;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        OnTriggerEnter(take);


    }


    void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {

            //player.transform.SetParent(peixe.transform);
            player.transform.parent = peixe.transform;
            player.GetComponent<playermove>().enabled = false;
            anim.SetBool("aparece", false);
            player.GetComponent<Animator>().SetBool("fall",true);

            //anim.SetBool("volta");
            //peixe.SetActive(true);
            // peixe.anim.SetBool("olhar", false);
        }

    }


}

