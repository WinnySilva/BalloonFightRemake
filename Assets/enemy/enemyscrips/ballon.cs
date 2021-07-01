using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ballon : MonoBehaviour
{
    public GameObject Navagent;
    public GameObject balloon;
    public Collider act;
    public static  bool cair;
    public GameObject parashut;
    public int pontuacao;
    public Transform ground0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter(act);
    }




    void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerMove>().Score = +pontuacao;
            balloon.SetActive(false);
            Navagent.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<enemy>().caca = false;
           
            cair = true;
            gameObject.GetComponent<enemy>().gravityValue = -9.81f;

            parashut.SetActive(true);        



        }

    }
}


