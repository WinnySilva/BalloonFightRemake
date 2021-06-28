using MLAPI;
using MLAPI.Prototyping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] jogadores;
    public static GameController Instance { get; private set; }
    public Vector3[] posicoesIniciais;
    // Start is called before the first frame update
    void Start()
    {
        if (!NetworkManager.Singleton.IsHost)
        {
            return;
        }
        Instance = this;
        jogadores = GameObject.FindGameObjectsWithTag("Player");

        int i = 0;
        Vector3 pos;
        NetworkTransform goTrans;
        //foreach (GameObject go in jogadores)
        //{
        //    goTrans = go.GetComponent<NetworkTransform>();
        //    pos = posicoesIniciais[i++];
        //    goTrans.Teleport(pos, go.transform.rotation);
           
        //    goTrans.transform.position = pos;
        //    go.transform.position = pos;
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
