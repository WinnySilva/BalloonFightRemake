using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{

    public int Score;
    public GameObject Player;

    void Start()
    {
        Score = 0;
    }


    void Update()
    {

        //Score = Player.GetComponent<playermove>().Score;

        GetComponent<Text>().text = Mathf.RoundToInt(Score).ToString("0000");


    }
}