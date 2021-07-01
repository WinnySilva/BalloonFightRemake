using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alvos : MonoBehaviour
{
    // Start is called before the first frame update

    private Collider ver;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter(ver);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if( other.gameObject.tag == "atack")
        {
            other.GetComponent<enemy>().GeraAlvo();
        }
    }


}
