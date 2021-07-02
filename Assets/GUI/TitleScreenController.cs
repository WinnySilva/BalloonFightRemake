using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{

    private void Start()
    {

    }
    
    public void IrParaLobby()
    {
        SceneManager.LoadScene("Lobby",LoadSceneMode.Single);

    }

}


