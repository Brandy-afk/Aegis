using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
[Header("Health")]
[SerializeField] Slider healthSlider;
[SerializeField] Health playerHealth;

[Header("Score")]
[SerializeField] TextMeshProUGUI scoreText;
 ScoreKeeper scoreKeeper;



 void Awake() 
{
    
scoreKeeper = FindObjectOfType<ScoreKeeper>();

}


void Start()
{

 healthSlider.maxValue = playerHealth.GetHealth();

}



void Update()
{
ScoreUI();
HealthUI();
}

void ScoreUI()
{

scoreText.text = scoreKeeper.GetScore().ToString("000000000");


}

void HealthUI()
{

healthSlider.value = playerHealth.GetHealth();

}






}
