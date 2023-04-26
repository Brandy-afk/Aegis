using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScript : MonoBehaviour
{

 SpriteRenderer spriteRenderer;

    void Start()
    {
     spriteRenderer = GetComponent<SpriteRenderer>();
     spriteRenderer.flipX = true;
    }

   

}
