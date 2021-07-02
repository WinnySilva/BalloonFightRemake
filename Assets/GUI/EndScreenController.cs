using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    public TMP_Text pontuacao;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] jogadores = GameObject.FindGameObjectsWithTag("PlayerInfo");
        int pontos = 0;
        foreach (GameObject go in jogadores)
        {
            PlayerInfo pi = go.GetComponent<PlayerInfo>();
            pontos += pi.Score.Value;
        }

        this.pontuacao.text = pontos.ToString().PadLeft(8, '0');

        NetworkController.Instance.Desconectar();

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void IrParaLobby()
    {
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }

}
