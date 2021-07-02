using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


public class enemy : MonoBehaviour
{
    public NavMeshAgent nave;
    public bool cacando;
    public Transform alvo;
    public float speed;
    public Animator anim;
    public Collider enemys;
    private Vector3 playerVelocity;
    public GameObject balloon;

    public GameObject[] Alvos;
    private Rigidbody rig;
    private bool groundedPlayer;
    public float gravityValue = -9.81f;
    public ballon balaoInimigo;
    public paraquedas paraquedasInimigo;

    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        Alvos = GameObject.FindGameObjectsWithTag("caminhoPatrulha");

        balaoInimigo.SemBaloesSobrando += SemBaloesSobrando;
        paraquedasInimigo.SemParaquedas += SemParaquedas;
        rig = GetComponent<Rigidbody>();
        GeraAlvo();
        anim.SetBool("estaChao", true);
        anim.SetBool("estaPulando", true);       
        StartCoroutine(this.InicioJogo());
        
    }
    void OnDestroy()
    {
        balaoInimigo.SemBaloesSobrando -= SemBaloesSobrando;
        paraquedasInimigo.SemParaquedas -= SemParaquedas;
    }

    // Update is called once per frame
    void Update()
    {


        if (cacando && nave.remainingDistance < 100)
        {
            GeraAlvo();
            NaveHunt(alvo);
        }

    }

    

    void entrada()
    {
      //  balloon.SetActive(true);
     //   cacando = true;
     //   nave.GetComponent<NavMeshAgent>().enabled = true;
      //  anim.SetBool("fly", true);
    }
    void groundout()
    {
        playerVelocity.y += Mathf.Sqrt(100 * -3.0f * gravityValue);

        anim.SetBool("fly", true);
    }

    void MoveCharacter(Vector3 frameMovement)
    {
        Vector3 novaPos = transform.position += frameMovement;
        rig.MovePosition(novaPos);

        //  frameMovement.z = 0;
    }

    public void GeraAlvo()
    {
        int rnd = UnityEngine.Random.Range(0, Alvos.Length);
        var valorAleatorio = Alvos[rnd];
        alvo = valorAleatorio.transform;


    }

    void NaveHunt(Transform alvo)
    {
        nave.isStopped = false;
        nave.SetDestination(alvo.transform.position);
        Vector3 direction = alvo.position - transform.position;
        float distanceToTarget = direction.magnitude;
        direction.Normalize();


        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -280f, transform.eulerAngles.z);
        }
        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 280f, transform.eulerAngles.z);
        }

    }

    void hunt()   // caça o inimigo
    {
        Vector3 direction = alvo.position - transform.position;

        float distanceToTarget = direction.magnitude;

        if (Math.Abs(distanceToTarget) < 100)
        {
            cacando = false;
            return;
        }

        direction.Normalize();
        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -280f, transform.eulerAngles.z);
        }
        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 280f, transform.eulerAngles.z);
        }

        float distanceWantsToMoveThisFrame = speed * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - 1), distanceWantsToMoveThisFrame);

        MoveCharacter(actualMovementThisFrame * direction);
    }


    private void SemBaloesSobrando(int pontuacao, ulong clientid)
    {
        nave.isStopped = true;
        nave.enabled = false;
        cacando = false;
        Destroy(nave);
        GameController.Instance.Pontuar(pontuacao, clientid);
        rig.AddForce(new Vector3(0, this.gravityValue * 0.2f), ForceMode.Force);
        anim.SetBool("fly", false);
    }

    private void SemParaquedas(int pontuacao, ulong clientid)
    {
    //    nave.isStopped = true;
   //     nave.enabled = false;
        cacando = false;
        GameController.Instance.Pontuar(pontuacao, clientid);  
        rig.AddForce(new Vector3(0, this.gravityValue*5), ForceMode.Impulse);
        anim.SetBool("paraquedas", false);
        StartCoroutine(Morrer());
    }

    IEnumerator InicioJogo()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("estaChao", false);
        anim.SetBool("estaPulando", false);
        anim.SetBool("fly", true);
        cacando = true;
        NaveHunt(alvo);
    }

    IEnumerator Morrer()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}







