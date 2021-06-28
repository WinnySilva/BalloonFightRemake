using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paraquedas : MonoBehaviour
{
  
    public Collider act;
    public static bool cair;
    public GameObject parashut;
    public int pontuacao;
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
            player.GetComponent<playermove>().Score = +pontuacao;
            parashut.SetActive(false);

                cair = true;
            gameObject.GetComponent<enemy>().gravityValue = -150; 



        }

    }
}
