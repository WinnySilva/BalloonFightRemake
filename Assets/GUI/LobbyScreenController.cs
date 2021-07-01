using MLAPI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LobbyScreenController : MonoBehaviour
{

    public TMP_InputField sala;
    public TMP_InputField nickname;
    public GameObject iniciarPartida;
    public GameObject aguardeMsg;
    public GameObject infoConexao;

    void Start()
    {
        NetworkController.ServerStarted += ServerStarted;
        NetworkController.ClientConected += ConectadoComoCliente;
        iniciarPartida.SetActive(false);
        aguardeMsg.SetActive(false);
        infoConexao.SetActive(true);

    }

    void OnDestroy()
    {
        NetworkController.ServerStarted -= ServerStarted;
    }

    public void IniciarHost()
    {
        string sala = this.sala.text;
        string nickname = this.nickname.text;
        aguardeMsg.SetActive(true);
        infoConexao.SetActive(false);

        NetworkController.Instance.IniciarHost(sala, nickname);
    }

    public void IniciarCliente()
    {
        string sala = this.sala.text;
        string nickname = this.nickname.text;
        aguardeMsg.SetActive(true);
        infoConexao.SetActive(false);
        NetworkController.Instance.IniciarClient(sala, nickname);
    }

    public void ComecarJogo()
    {
        aguardeMsg.SetActive(true);
        NetworkController.Instance.SwitchScene("Fase_01");

    }

    public void ConectadoComoCliente(ulong id)
    {

        aguardeMsg.SetActive(true);
        infoConexao.SetActive(false);
        GameObject[] jogadores = GameObject.FindGameObjectsWithTag("PlayerInfo");

        if (!string.IsNullOrEmpty(this.nickname.text))
        {
            foreach (GameObject j in jogadores)
            {
                PlayerInfo pf = j.GetComponent<PlayerInfo>();
                if (pf.IsOwner)
                {
                    pf.setNickname(this.nickname.text.Trim());
                }
            }
        }


        if (NetworkManager.Singleton.IsHost)
        {
            iniciarPartida.SetActive(true);
        }
        else
        {
            iniciarPartida.SetActive(false);
        }
    }

    private void ServerStarted()
    {
        
        GameObject[] jogadores = GameObject.FindGameObjectsWithTag("PlayerInfo");

        if (!string.IsNullOrEmpty(this.nickname.text))
        {
            foreach (GameObject j in jogadores)
            {
                PlayerInfo pf = j.GetComponent<PlayerInfo>();
                if (pf.IsOwner)
                {
                    pf.setNickname(this.nickname.text.Trim());
                }
            }
        }

        iniciarPartida.SetActive(true);
        aguardeMsg.SetActive(false);
        infoConexao.SetActive(false);
    }


}


