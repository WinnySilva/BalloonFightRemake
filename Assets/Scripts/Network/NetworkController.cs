﻿using MLAPI;
using MLAPI.SceneManagement;
using MLAPI.Transports.PhotonRealtime;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NetworkController : MonoBehaviour
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
       
    public void IniciarHost(string nomeSala, string nickname)
    {
        NetworkManager.Singleton.OnServerStarted += OnServerStarted;

    //    PlayerNet cliente = new LoadBalancingClient();

        transport.RoomName = nomeSala;
     //   transport.Client.NickName = nickname;

        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectedCallback;

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
        NetworkSceneManager.SwitchScene(mySceneName);
    }

    public int ClientesConectados()
    {
        return NetworkManager.Singleton.ConnectedClientsList.Count;
    }

}

