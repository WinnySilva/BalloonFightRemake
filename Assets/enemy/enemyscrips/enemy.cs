using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


public class enemy : MonoBehaviour
{
    public NavMeshAgent nave;
    public bool caca;
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
    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        Alvos = GameObject.FindGameObjectsWithTag("caminhoPatrulha");

        rig = GetComponent<Rigidbody>();
        GeraAlvo();
        caca = true;
        NaveHunt(alvo);
    }

    // Update is called once per frame
    void Update()
    {

        if (ballon.cair == true)
        {
            anim.SetBool("fall", true);
            StartCoroutine("DestruirInimigo");
        }

        //OnTriggerS(enemys);
        OnTriggerEnter(enemys);



        //if (caca == true)
        //{
        //    hunt();
        //}
        //else
        //{

        //    GeraAlvo();
        //    caca = true;
        //}
        if (nave.remainingDistance < 100)
        {
            GeraAlvo();
            NaveHunt(alvo);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pballon")
        {
            alvo = other.transform;
        }
    }

    void entrada()
    {
        balloon.SetActive(true);
        caca = true;
        nave.GetComponent<NavMeshAgent>().enabled = true;
        anim.SetBool("fly", true);
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
            caca = false;
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

    public IEnumerator DestruirInimigo()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}







