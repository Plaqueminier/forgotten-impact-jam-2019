using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundParticle : MonoBehaviour
{

    public ParticleSystem groundParticle;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y > 3f && collision.gameObject.layer == 9) {
            SoundManager.playSound("landing");
            foreach (ContactPoint2D contact in collision.contacts) {
                Vector2 contactPoint = contact.point;
                groundParticle.emission.SetBursts(
                    new ParticleSystem.Burst[] {
                    new ParticleSystem.Burst(0.0f, ((short)(collision.relativeVelocity.y * 0.5f)), ((short)(collision.relativeVelocity.y * 1f)))
                });
                groundParticle.transform.position = new Vector2(contactPoint.x, contactPoint.y);
                groundParticle.Play();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
