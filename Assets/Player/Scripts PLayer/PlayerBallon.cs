using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallon : MonoBehaviour
{
    public static PlayerBallon Instance { get; private set; }
  
    public Collider act;
    
    public  int cair= 2;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
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

        if (player.gameObject.tag == "atack")
        {
            {
                
                cair = cair - 1;
                
            }

        }

    }
    



}
