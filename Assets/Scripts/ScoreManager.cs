using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.GetComponents<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreUpdate(int scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = "Score: " + score;
    }
}
