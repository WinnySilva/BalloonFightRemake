using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallon : MonoBehaviour
{

    public  Action SemBaloesSobrando;
    public  Action UmBalaoSobrando;

    public Collider act;

    public int cair = 2;

    void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "atack")
        {
            {

                cair = cair - 1;

                if (cair <= 0)
                {
                    SemBaloesSobrando?.Invoke();
                }
                else
                {
                    UmBalaoSobrando?.Invoke();
                }
            }

        }

    }

}
