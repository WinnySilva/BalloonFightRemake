using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolha : MonoBehaviour
{
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
            {
                Destroy(gameObject, 0f);
                player.GetComponent<PlayerMove>().Score= +500;
            }

        }

    }




}
