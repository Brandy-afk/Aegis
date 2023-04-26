using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameOver : MonoBehaviour
{

[SerializeField]TextMeshProUGUI scoreText;
[SerializeField]TextMeshProUGUI highScoreText;
 ScoreKeeper scoreKeeper;

    void Awake()
    {

   scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }


    void Start()
    {

 scoreText.text = "Final Score:\n" + scoreKeeper.GetScore();
 highScoreText.text = "High Score:\n" + scoreKeeper.GetHighScore();
              
    }




}
