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
        NetworkController.Instance.IniciarHost(sala, nickname);
    }

    public void IniciarCliente()
    {
        string sala = this.sala.text;
        string nickname = this.nickname.text;
        
        NetworkController.Instance.IniciarClient(sala, nickname);
    }
        
    public void ComecarJogo()
    {
        aguardeMsg.SetActive(true);
        NetworkController.Instance.SwitchScene("SampleSceneNetwork");     
       
    }

    public void ConectadoComoCliente()
    {
        iniciarPartida.SetActive(false);
        aguardeMsg.SetActive(true);
        infoConexao.SetActive(false);
    }

    private void ServerStarted()
    {
        iniciarPartida.SetActive(true);
        aguardeMsg.SetActive(false);
        infoConexao.SetActive(false);
    }


}


