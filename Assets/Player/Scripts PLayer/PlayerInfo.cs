using MLAPI;
using MLAPI.NetworkVariable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : NetworkBehaviour
{
   
    public NetworkVariable<string> Nickname;
    
    public NetworkVariable<ulong> Score;

    public NetworkVariable<int> Vida;

    // Start is called before the first frame update
    void Start()
    {
        Nickname  = new NetworkVariable<string>(
            new NetworkVariableSettings { WritePermission = NetworkVariablePermission.OwnerOnly }, string.Empty);

        Score = new NetworkVariable<ulong>(
                new NetworkVariableSettings { WritePermission = NetworkVariablePermission.ServerOnly }, 0);

        Vida = new NetworkVariable<int>(
               new NetworkVariableSettings { WritePermission = NetworkVariablePermission.ServerOnly }, 2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
