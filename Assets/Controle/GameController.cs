using MLAPI;
using MLAPI.Prototyping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : NetworkBehaviour
{
    public GameObject[] jogadores;
    public static GameController Instance { get; private set; }
    public Vector3[] posicoesIniciais;
    public GameObject prefabJogador;


    // Start is called before the first frame update
    void Start()
    {
        if (!NetworkManager.Singleton.IsHost)
        {
            return;
        }
        Instance = this;
        jogadores = GameObject.FindGameObjectsWithTag("PlayerInfo");

        CarregarPersonagens();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void CarregarPersonagens()
    {
        int i = 0;
        Vector3 pos;
        NetworkTransform goTrans;
        GameObject novo;
        foreach (GameObject go in jogadores)
        {
            PlayerInfo info = go.GetComponent<PlayerInfo>();
            pos = this.posicoesIniciais[i++];
            novo = Instantiate(prefabJogador, pos, Quaternion.identity);
            novo.GetComponent<NetworkObject>().SpawnAsPlayerObject(info.OwnerClientId);
        }
    }
}
