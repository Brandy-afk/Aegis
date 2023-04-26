using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
[SerializeField] bool goOpposite = false;
[SerializeField] float rotationSpeed = 0f;


    void Update()
    {
        if(!goOpposite)
        {
        transform.Rotate(0,0, rotationSpeed *Time.deltaTime);
        }

        if(goOpposite)
        {
        transform.Rotate(0,0,-40*Time.deltaTime);
        }
    }

}
