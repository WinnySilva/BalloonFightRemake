using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopScores : MonoBehaviour
{
    public GameObject Score1;
    public GameObject Score2;
    public int p1;
    public int p2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1 = Score1.GetComponent<score>().Score;
        p2 = Score2.GetComponent<score>().Score;

        if (p1 > p2)
        {

            GetComponent<Text>().text = Mathf.RoundToInt(p1).ToString("0000");
        }
        if (p1 < p2)
        {
            GetComponent<Text>().text = Mathf.RoundToInt(p2).ToString("0000");
        }
    }
}
