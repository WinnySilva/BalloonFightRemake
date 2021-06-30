using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponto : MonoBehaviour
{

    private float cont = 0f;
    public GameObject point;
    public GameObject bolha;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;

        if(cont>= 80f)
        {
            GameObject CloneTiro = Instantiate(bolha, point.transform.position, point.transform.rotation);
            cont = 0f;
        }



    }
}
