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

    void Start()
    {
        NetworkController.ServerStarted += ServerStarted;
        iniciarPartida.SetActive(false);
        aguardeMsg.SetActive(false);

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
        NetworkController.Instance.SwitchScene("SampleSceneNetwork");     
        aguardeMsg.SetActive(true);
    }

    private void ServerStarted()
    {
        iniciarPartida.SetActive(true);
        aguardeMsg.SetActive(false);
    }


}


