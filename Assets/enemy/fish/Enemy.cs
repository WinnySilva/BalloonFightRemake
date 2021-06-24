using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{



    public GameObject inimigo;
    public Transform alvo;
    public Animator anim;

    


    // Start is called before the first frame update
    void Start()
    {
        //peixe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


       

            hunt();
        

    }






















    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }






    void hunt()   // caça o inimigo
    {
        Vector3 direction = alvo.position - transform.position;

        direction.y = 0;

        float distanceToTarget = direction.magnitude;


        direction.Normalize();















        float distanceWantsToMoveThisFrame = 10000f * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - 1), distanceWantsToMoveThisFrame);

        MoveCharacter(actualMovementThisFrame * direction);
    }







}
