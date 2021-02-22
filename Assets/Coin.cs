using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        lifetime = 0;


    }
    
    // Update is called once per frame
    void Update()
    {
        lifetime = +0.1f;
            if (lifetime>100f) { Destroy(this); }
    }
}
