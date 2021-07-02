using MLAPI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreenController : MonoBehaviour
{
    public TMP_Text jogadorUm_Nick;
    public TMP_Text jogadorUm_Score;

    public TMP_Text jogadorDois_Nick;
    public TMP_Text jogadorDois_Score;

    private GameObject jogadorUm;
    private GameObject jogadorDois;



    // Start is called before the first frame update
    void Start()
    {
        this.jogadorUm_Nick.gameObject.SetActive(false);
        this.jogadorUm_Score.gameObject.SetActive(false);
        this.jogadorDois_Nick.gameObject.SetActive(false);
        this.jogadorDois_Score.gameObject.SetActive(false);
        NetworkController.ClientDisconected += OnDisconect;
        GameObject[] jogadores = GameObject.FindGameObjectsWithTag("PlayerInfo");
        foreach (GameObject go in jogadores)
        {
            PlayerInfo pi = go.GetComponent<PlayerInfo>();
            if (NetworkManager.Singleton.ServerClientId == pi.OwnerClientId)
            {
                jogadorUm = go;
                pi.Score.OnValueChanged += AtualizaScoreJogadorUm;
                this.jogadorUm_Nick.text = pi.Nickname.Value;
                this.jogadorUm_Score.text = (pi.Score.Value.ToString()).PadLeft(8, '0');
                this.jogadorUm_Nick.gameObject.SetActive(true);
                this.jogadorUm_Score.gameObject.SetActive(true);
            }
            else
            {
                pi.Score.OnValueChanged += AtualizaScoreJogadorDois;
                this.jogadorDois_Nick.text = pi.Nickname.Value;
                this.jogadorDois_Score.text = (pi.Score.Value.ToString()).PadLeft(8, '0');
                this.jogadorDois_Nick.gameObject.SetActive(true);
                this.jogadorDois_Score.gameObject.SetActive(true);
                jogadorDois = go;
            }


        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AtualizaScoreJogadorUm(int velho, int novo)
    {
        int pontos = jogadorUm.GetComponent<PlayerInfo>().Score.Value;
        this.jogadorUm_Score.text = (pontos.ToString()).PadLeft(8, '0');
        Debug.Log("pontos: " + pontos + " velho: " + velho + " " + " novo:" + novo);
    }

    public void AtualizaScoreJogadorDois(int velho, int novo)
    {
        int pontos = jogadorDois.GetComponent<PlayerInfo>().Score.Value;
        this.jogadorDois_Score.text = (pontos.ToString()).PadLeft(8, '0');
        Debug.Log("pontos: " + pontos + " velho: " + velho + " " + " novo:" + novo);
    }

    public void OnDisconect(ulong id)
    {
        if (NetworkManager.Singleton.IsHost)
        {
            NetworkManager.Singleton.StopHost();
        }

        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }

    public void Desconectar()
    {
        NetworkController.Instance.Desconectar();
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
}
