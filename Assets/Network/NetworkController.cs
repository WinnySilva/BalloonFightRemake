using MLAPI;
using MLAPI.SceneManagement;
using MLAPI.Transports.PhotonRealtime;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NetworkController : NetworkBehaviour
{

    public static NetworkController Instance { get; private set; }
    public static Action<ulong> ClientConected;
    public static Action<ulong> ClientDisconected;
    public static Action ServerStarted;
    public bool EhLocal { get; private set; }
    public PhotonRealtimeTransport transport;
    public Dictionary<ulong, string> Jogadores { get; private set; }


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        Jogadores = new Dictionary<ulong, string>();

    }

    void Start()
    {
        NetworkManager.Singleton.OnServerStarted += OnServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectedCallback;
    }

    public void IniciarHost(string nomeSala, string nickname)
    {
             
        transport.RoomName = nomeSala;
       
        NetworkManager.Singleton.StartHost();

    }

    public void IniciarClient(string nomeSala, string nickname)
    {
        transport.RoomName = nomeSala;
        //    transport.OnPlayerEnteredRoom.

        NetworkManager.Singleton.StartClient();

    }

    public void OnClientConnectedCallback(ulong clientId)
    {
        Jogadores.Add(clientId, String.Empty);
        ClientConected?.Invoke(clientId);
    }

    public void OnClientDisconnectCallback(ulong clientId)
    {
        Jogadores.Remove(clientId);
        ClientDisconected?.Invoke(clientId);
    }

    public void OnServerStarted()
    {
        //   id_jogador_um = NetworkManager.Singleton.LocalClientId;
        ServerStarted?.Invoke();
    }

    public void Desconectar()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            //    NetworkManager.Singleton.DisconnectClient(id_jogador_dois);
            NetworkManager.Singleton.StopHost();
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            NetworkManager.Singleton.StopClient();
        }
    }

    public void SwitchScene(string mySceneName)
    {
        if (NetworkManager.Singleton.IsServer)
        {
            NetworkSceneManager.SwitchScene(mySceneName);
        }
    }

    public int ClientesConectados()
    {
        return NetworkManager.Singleton.ConnectedClientsList.Count;
    }

}

