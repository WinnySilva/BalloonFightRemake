using MLAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ballon : MonoBehaviour
{
    public GameObject balloon;
    public GameObject parashut;
    public int pontuacao;

    public Action<int, ulong> SemBaloesSobrando;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {
            ulong clientid = player.GetComponent<NetworkObject>().OwnerClientId;           
            balloon.SetActive(false);           
            parashut.SetActive(true);            
            SemBaloesSobrando?.Invoke(pontuacao, clientid);
        }

    }
}


