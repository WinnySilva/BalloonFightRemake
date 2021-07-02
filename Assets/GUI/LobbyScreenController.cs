using MLAPI;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScreenController : NetworkBehaviour
{

    public TMP_InputField sala;
    public TMP_InputField nickname;
    public GameObject iniciarPartida;
    public GameObject aguardeMsg;
    public GameObject infoConexao;
    public GameObject btnDesconectar;
    public TMP_Text jogadoresConectados;
    public TMP_Text msg_feedback;

    private string nomeSala;
    void Start()
    {
        NetworkController.ServerStarted += ServerStarted;
        NetworkController.ClientDisconected += ClientDisconectado;
        NetworkController.ClientConected += ConectadoComoCliente;
        iniciarPartida.SetActive(false);
        aguardeMsg.SetActive(false);
        infoConexao.SetActive(true);
        btnDesconectar.SetActive(false);
        nomeSala = string.Empty;
    }

    void OnDestroy()
    {
        NetworkController.ServerStarted -= ServerStarted;
        NetworkController.ClientConected -= ConectadoComoCliente;
    }

    public void IniciarHost()
    {
        if (this.validarSalaNick() != null)
        {
            this.msg_feedback.text = this.validarSalaNick();
            this.msg_feedback.gameObject.SetActive(true);
            return;
        }
        this.msg_feedback.gameObject.SetActive(false);

        string sala = this.sala.text;
     //   string nickname = this.nickname.text;
        aguardeMsg.SetActive(true);
        infoConexao.SetActive(false);
        nomeSala = sala;
        NetworkController.Instance.IniciarHost(sala, string.Empty);
    }

    public void IniciarCliente()
    {
        if (this.validarSalaNick() != null)
        {
            this.msg_feedback.text = this.validarSalaNick();
            this.msg_feedback.gameObject.SetActive(true);
            return;
        }
        this.msg_feedback.gameObject.SetActive(false);

        string sala = this.sala.text;
       // string nickname = this.nickname.text;
        aguardeMsg.SetActive(true);
        infoConexao.SetActive(false);
        nomeSala = sala;
        NetworkController.Instance.IniciarClient(sala, string.Empty);
    }

    public void ComecarJogo()
    {
        aguardeMsg.SetActive(true);
        NetworkController.Instance.SwitchScene("Fase_01");
    }

    public void ConectadoComoCliente(ulong id)
    {

        aguardeMsg.SetActive(true);
        infoConexao.SetActive(false);

        if (NetworkManager.Singleton.IsHost)
        {
            iniciarPartida.SetActive(true);
        }
        else
        {
            iniciarPartida.SetActive(false);
        }
        btnDesconectar.SetActive(true);
        ListarJogadoresConectados();
    }

    public void Desconectar()
    {
        NetworkController.Instance.Desconectar();
        this.sala.text = string.Empty;
        iniciarPartida.SetActive(false);
        aguardeMsg.SetActive(false);
        infoConexao.SetActive(true);
        btnDesconectar.SetActive(false);
    }

    private void ServerStarted()
    {

        iniciarPartida.SetActive(true);
        aguardeMsg.SetActive(true);
        infoConexao.SetActive(false);
        btnDesconectar.SetActive(true);
        ListarJogadoresConectados();
    }

    
    void ListarJogadoresConectados()
    {

        if (!NetworkManager.Singleton.IsHost && !NetworkManager.Singleton.IsClient)
        {
            jogadoresConectados.text = string.Empty;
            return;
        }
        GameObject[] jogadores = GameObject.FindGameObjectsWithTag("PlayerInfo");
        string msg = "Conectados na sala \n" + this.nomeSala+ ":\n";
        int i = 1;
        foreach (GameObject j in jogadores)
        {
            PlayerInfo pi = j.GetComponent<PlayerInfo>();
            string nick = "#"+i.ToString();
            i++;
            
            msg += nick.Trim() + "\n";
        }
        jogadoresConectados.text = msg;
    }

    private string validarSalaNick()
    {
        string sala = this.sala.text;
     //  string nickname = this.nickname.text;

        if (sala.Length < 3)
        {
            return "Nome da Sala deve ser maior que 3 LETRAS";
        }

        //if (nickname.Length < 3)
        //{
        //    return "Nickname deve ser maior que 3 LETRAS";
        //}

        return null;

    }

    private void ClientDisconectado(ulong id)
    {
        this.sala.text = string.Empty;
        if (NetworkManager.Singleton.IsHost)
        {
            StartCoroutine(AtualizaTela());
        }
        else
        {
            SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
        }

    }

    IEnumerator AtualizaTela()
    {
        yield return new WaitForSeconds(0.5f);
        ListarJogadoresConectados();
    }
}


