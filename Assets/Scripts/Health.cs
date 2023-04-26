using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

  [SerializeField] int health = 50;
  [SerializeField] ParticleSystem hitEffect;
  

  [SerializeField] bool isPlayer;
  [SerializeField] int score = 50;

[SerializeField] bool isYellowShip = false;
  [SerializeField] bool applyCameraShake;
   CameraShake cameraShake;
  AudioManager audioManager;
  ScoreKeeper scoreKeeper;
  LevelManager levelManager;
  Shooter shooter;

 public int GetHealth()
 {

 return health;

 }

 
 void Awake() 
    {

 cameraShake = Camera.main.GetComponent<CameraShake>();
 audioManager = FindObjectOfType<AudioManager>();
scoreKeeper = FindObjectOfType<ScoreKeeper>();
levelManager = FindObjectOfType<LevelManager>();
shooter = FindObjectOfType<Shooter>();

    }


   void OnTriggerEnter2D(Collider2D other) 
{
DamageDealer damageDealer = other.GetComponent<DamageDealer>();

if(damageDealer != null)
{

TakeDamage(damageDealer.GetDamage());
PlayHitEffect();
ShakeCamera();
damageDealer.Hit();
if(isYellowShip)
{

shooter.YelloShipHitOnce();

}

}


}

void TakeDamage(int damage)
{

audioManager.PlayDamageClip();
health -= damage;
if(health <= 0)
{

Die();

}


}

void Die()
{

if(!isPlayer)
{
 scoreKeeper.ModifyScore(score);
 Destroy(gameObject);
}

else
{
Destroy(gameObject);    
levelManager.LoadEndScreen();
}


}


void PlayHitEffect()
    {
        ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(instance.gameObject, instance.main.duration);
    }



void ShakeCamera()
{

if(cameraShake != null && applyCameraShake)
{

cameraShake.Play();

}

}



}




