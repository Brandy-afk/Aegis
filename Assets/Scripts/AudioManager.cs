using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
 
 [Header("Shooting")]
 [SerializeField] AudioClip shootingClip;
 [SerializeField] [Range(0f,1f)] float shootingVolume = 1f; 

 [Header("Damage")]
 [SerializeField] AudioClip damageClip;
 [SerializeField] [Range(0f,1f)] float damageVolume = 1f;
 

static AudioManager instance;

// public AudioPlayer GetInstance()
// {

// return instance; 

// }



void Awake()
{

ManageSingleton();

}

void ManageSingleton()
{

// int instanceCount = FindObjectOfType(GetType()).Length; 1st way of doing a singleton.
// if(instanceCount > 1)
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




public void PlayShootingClip()
{
if(shootingClip != null)
{
AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
}
}

public void PlayDamageClip()
{

if(damageClip != null)
{

AudioSource.PlayClipAtPoint(damageClip, Camera.main.transform.position, shootingVolume);

}



}





}
