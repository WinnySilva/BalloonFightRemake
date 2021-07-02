using MLAPI;
using MLAPI.NetworkVariable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : NetworkBehaviour
{

    public NetworkVariable<string> Nickname;
    
    public NetworkVariable<int> Score;

    public NetworkVariable<int> Vida;

    // Start is called before the first frame update
    void Start()
    {
        if (!this.IsOwner)
        {
            return;
        }
        Nickname  = new NetworkVariable<string>(
            new NetworkVariableSettings { WritePermission = NetworkVariablePermission.Everyone }, string.Empty);

        Score = new NetworkVariable<int>(
                new NetworkVariableSettings { WritePermission = NetworkVariablePermission.Everyone }, 0);

        Vida = new NetworkVariable<int>(
               new NetworkVariableSettings { WritePermission = NetworkVariablePermission.Everyone }, 2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setNickname(string name)
    {
        if (!this.IsOwner)
        {
            return;
        }
        this.Nickname.Value = name;
    }


}
