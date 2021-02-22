using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifetime;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        lifetime = 0;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up*10f,ForceMode.Impulse);

    }
    
    // Update is called once per frame
    void Update()
    {
        lifetime += 0.1f;
            if (lifetime>50f) { Destroy(this.gameObject); }
    }
}
