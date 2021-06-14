using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LobbyScreenController : MonoBehaviour
{

    public TMP_InputField sala;
    public TMP_InputField nickname;


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

}


