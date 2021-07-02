using MLAPI;
using MLAPI.Prototyping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNet : NetworkBehaviour
{

    public NetworkTransform netTransform;

    // Start is called before the first frame update
    void Start()
    {

        
        netTransform = GetComponent<NetworkTransform>();
        NetworkObject no = GetComponent<NetworkObject>();
        SceneManager.sceneLoaded += OnSceneLoad;

    }

    void OnSceneLoad(Scene cena, LoadSceneMode mode)
    {

    }
        
    // Update is called once per frame
    void Update()
    {



    }
}
