using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : NetworkBehaviour
{
    public GameObject[] jogadores;
    public static GameController Instance { get; private set; }
    public Vector3[] posicoesIniciais;
    public GameObject prefabJogadorUm;
    public GameObject prefabJogadorDois;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if (!NetworkManager.Singleton.IsHost)
        {
            return;
        }

        jogadores = GameObject.FindGameObjectsWithTag("PlayerInfo");

        CarregarPersonagens();
    }

    // Update is called once per frame
    void Update()
    {
        if (!NetworkManager.Singleton.IsHost)
        {
            return;
        }
        if (!PartidaEmAndamento())
        {
            FimDePartida();
        }

    }

    public void Pontuar(int pontuacao, ulong clienteid)
    {
        if (!NetworkManager.Singleton.IsHost)
        {
            return;
        }

        foreach (GameObject info in jogadores)
        {
            PlayerInfo inf = info.GetComponent<PlayerInfo>();
            if (inf.OwnerClientId == clienteid)
            {
                inf.Score.Value = inf.Score.Value + pontuacao;
                return;
            }
        }
    }

    public bool PartidaEmAndamento()
    {


        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("atack");
        if (inimigos.Length == 0)
        {
            return false;
        }

        GameObject[] jogadoresObj = GameObject.FindGameObjectsWithTag("Player");
        if (jogadoresObj.Length == 0)
        {
            return false;
        }
        int jogaresFora = 0;
        foreach (GameObject obj in jogadoresObj)
        {
            PlayerMovement move = obj.GetComponent<PlayerMovement>();

            if (move.EstaMorto.Value)
            {
                jogaresFora++;
            }

        }
        if (jogaresFora == jogadoresObj.Length)
        {
            return false;
        }

        return true;
    }

    void CarregarPersonagens()
    {
        int i = 0;
        Vector3 pos;
        GameObject novo;
        foreach (GameObject go in jogadores)
        {
            PlayerInfo info = go.GetComponent<PlayerInfo>();
            pos = this.posicoesIniciais[i++];
            if (info.IsOwner)
            {
                novo = Instantiate(prefabJogadorUm, pos, Quaternion.identity);
                novo.GetComponent<NetworkObject>().SpawnWithOwnership(info.OwnerClientId);
            }
            else
            {
                novo = Instantiate(prefabJogadorDois, pos, Quaternion.identity);
                novo.GetComponent<NetworkObject>().SpawnWithOwnership(info.OwnerClientId);
            }

        }
    }

    void FimDePartida()
    {
        NetworkController.Instance.SwitchScene("FimJogo");
    }
}
