using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestructor : MonoBehaviour
{
    public float lifeTime = 15f;
        
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    
}
