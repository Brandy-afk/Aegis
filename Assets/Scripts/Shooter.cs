using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

[Header("General")]
[SerializeField] GameObject projectilePrefab;
[SerializeField] float projectileSpeed = 10f;
[SerializeField] float projectileLifetime = 5f;
[SerializeField] float baseFiringRate = 0.2f;


[Header("AI")]
[SerializeField] bool useAI;
[SerializeField] float fireRateVariance = 0f;
[SerializeField] float minimumFiringRate = 0.1f;
[SerializeField] List<GameObject> points;

[SerializeField] bool bigEnemy = false;
[HideInInspector] public bool isFiring;
Coroutine firingCoroutine;
int num = 0; //Random number generation for larger ships Coroutine

AudioManager audioManager;


void Awake()
{

audioManager = FindObjectOfType<AudioManager>();

}



    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    
    void Update()
    {
        Fire();
    }








    void Fire()
{

if(isFiring && firingCoroutine == null)
    {
     if(!bigEnemy)
     {
     firingCoroutine = StartCoroutine(FireContinously()); 
     }
     else
     {
     firingCoroutine = StartCoroutine(FireContinouslyBigShip());
     }
    }
else if(!isFiring && firingCoroutine != null)
    {

 StopCoroutine(firingCoroutine);
 firingCoroutine = null;
    }
}


   IEnumerator FireContinously()
{
while(true)
    {
      
        GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);

            float timeToNextProjectile = Random.Range(baseFiringRate - fireRateVariance, baseFiringRate + fireRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            audioManager.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);


    }     

}

 IEnumerator FireContinouslyBigShip()
 {

while(true)
    {
        num = Random.Range(0,2);
         GameObject instance = Instantiate(projectilePrefab, points[num].transform.position, Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);

            float timeToNextProjectile = Random.Range(baseFiringRate - fireRateVariance, baseFiringRate + fireRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            audioManager.PlayShootingClip();

    

            yield return new WaitForSeconds(timeToNextProjectile);
        
       }
    }



     public void YelloShipHitOnce()
     {

     baseFiringRate *= 4;

     }



}


