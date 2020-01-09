using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    public LoseCondition loseCondition;

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.layer == 8)
    //         loseCondition.lost = true;
    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
            loseCondition.lost = true;
    }
}
