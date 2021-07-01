using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolha : MonoBehaviour
{
    public float speed;
    private float timeDestroy;
    public Collider esfera;
    // Start is called before the first frame update
    void Start()
    {
        timeDestroy = 60f;
        Destroy(gameObject, timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        OnTriggerEnter(esfera);
    }


    void destroi()
    {
        timeDestroy = 0f;
        Destroy(gameObject, timeDestroy);

    }


    void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerMove>().Score = +500;

            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);

        }
    }
}
