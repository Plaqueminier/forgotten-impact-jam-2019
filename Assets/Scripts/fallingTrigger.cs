using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingTrigger : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8) {
            rb.isKinematic = false;
            rb.mass = 1000;
        }
    }
}
