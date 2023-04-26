using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
  [SerializeField] int  score = 0;  
 static ScoreKeeper instance;
  [SerializeField] int highScore = 0;


   void Awake()
   {
    ManageSingleton();
   }

    void ManageSingleton()
    {

if(instance != null)
{
  gameObject.SetActive(false);
  Destroy(gameObject);
}
else
{
  instance = this;
  DontDestroyOnLoad(gameObject);
}

    }


void Update() 
{
 HighScore();
}
 
void HighScore()
{
if(score > highScore)
{
 highScore = score;
}

}


public int GetHighScore()
{

return highScore;

}



  public int GetScore()
  {

 return  score;

  }

  public void ModifyScore(int value)
  {

  score += value;
  Mathf.Clamp(score, 0, int.MaxValue);
  
  }

 public void ResetScore()
 {

  score = 0;

 }





}
