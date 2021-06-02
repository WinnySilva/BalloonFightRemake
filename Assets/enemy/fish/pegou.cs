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


        void OnTriggerEnter(Collider player)
        {

            if (player.gameObject.tag == "Player")
            {

                Debug.Log("quase");
                anim.SetTrigger("aparece");
                //peixe.SetActive(true);
                // peixe.anim.SetBool("olhar", false);
            }

        }
    }
}

