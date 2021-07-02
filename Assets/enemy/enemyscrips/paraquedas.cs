using MLAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paraquedas : MonoBehaviour
{
    public static bool cair;
    public GameObject parashut;
    public int pontuacao;

    public Action<int, ulong> SemParaquedas;
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
            parashut.SetActive(false);
            SemParaquedas?.Invoke(pontuacao, clientid);
            Destroy(this);
        }

    }
        
}
