using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour {

	public float viewRadius;
	public LoseCondition loseCondition;
	bool facingRight = false;
	[Range(0,360)]
	public float viewAngle;
	public float viewPos;
	public Animator animator;


	private Rigidbody2D rb2d;
	float maxSpeed = 4f;
	float timer = 0.0f;
	float flipTimer = 0.0f;

	static bool attack = false;
	static bool stop = false;
	static float position = 0.0f;

	public LayerMask targetMask;
	public LayerMask obstacleMask;

	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();

	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
		StartCoroutine ("FindTargetsWithDelay", .2f);
	}


	IEnumerator FindTargetsWithDelay(float delay) {
		while (true) {
			yield return new WaitForSeconds (delay);
			FindVisibleTargets ();
		}
	}

	void FindVisibleTargets() {
		visibleTargets.Clear ();
		Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll ((Vector2)transform.position, viewRadius, targetMask);

		animator.SetFloat("speed", 0.0f);
		animator.SetFloat("attack", 0.0f);
		animator.SetFloat("die", 0.0f);
		timer += Time.deltaTime;
		for (int i = 0; i < targetsInViewRadius.Length; i++) {
			maxSpeed = 4.0f;
			Transform target = targetsInViewRadius [i].transform;
			Vector2 dirToTarget = (target.position - transform.position).normalized;
			if (Vector2.Angle (transform.forward, dirToTarget) < viewPos / 2 && target.position.y > transform.position.y - 1.0 && target.position.y < transform.position.y + 1.0) {
				float dstToTarget = Vector2.Distance (transform.position, target.position);

				if (!Physics2D.Raycast (transform.position, dirToTarget, dstToTarget, obstacleMask)) {
						Debug.Log("Detect");
						if (target.position.x > transform.position.x + 1.0f && Physics2D.Raycast (transform.position, DirFromAngle (137, false), dstToTarget, obstacleMask)) {
							rb2d.velocity = new Vector2((1 * maxSpeed), rb2d.velocity.y);
							animator.SetFloat("speed", 2.0f);
							if (!facingRight)
								Flip();
							if (stop == false) {
								SoundManager.playSound("stop");
								stop = true;
							}
						}
						else if (target.position.x <= transform.position.x - 1.0f && Physics2D.Raycast (transform.position, DirFromAngle (-137, false), dstToTarget, obstacleMask)) {
							rb2d.velocity = new Vector2((-1 * maxSpeed), rb2d.velocity.y);
							animator.SetFloat("speed", 2.0f);
							if (facingRight)
								Flip();
							if (stop == false) {
								SoundManager.playSound("stop");
								stop = true;
							}
						} else if (target.position.x > transform.position.x - 1.0f && target.position.x < transform.position.x + 1.0f) {
							animator.SetFloat("attack", 2.0f);
							if (attack == true) {
								Debug.Log(timer);
								Debug.Log(attack);
								loseCondition.lost = true;
							}
							if (attack == false || (timer > 0.12 && attack == true)) {
								SoundManager.playSound("slash");
								attack = true;
								timer = 0;
							}
						}
					visibleTargets.Add (target);
				}
			} else {
				animator.SetFloat("speed", 0.0f);
				animator.SetFloat("attack", 0.0f);
				animator.SetFloat("die", 0.0f);
				attack = false;
				rb2d.velocity = new Vector2((0), rb2d.velocity.y);
			}
		}
		if (flipTimer > 1.0) {
			stop = false;
			flipTimer = 0.0f;
		}
		// if (targetsInViewRadius.Length == 0 || animator.GetFloat("speed") == 0) {
		// 	maxSpeed = 2.0f;
		// 	float dstToTarget = 1.2f;
		// 	if (facingRight && Physics2D.Raycast (transform.position, DirFromAngle ( 137, false), dstToTarget, obstacleMask) && !Physics2D.Raycast (transform.position, DirFromAngle (90, false), 0.5f, obstacleMask)) {
		// 		rb2d.velocity = new Vector2((1 * maxSpeed), rb2d.velocity.y);
		// 		animator.SetFloat("speed", 2.0f);
		// 	}
		// 	else if (!facingRight && Physics2D.Raycast (transform.position, DirFromAngle (-137, false), dstToTarget, obstacleMask)) {
		// 		rb2d.velocity = new Vector2((-1 * maxSpeed), rb2d.velocity.y);
		// 		animator.SetFloat("speed", 2.0f);
		// 	}
		// 	if (!Physics2D.Raycast (transform.position, DirFromAngle (-137, false), dstToTarget, obstacleMask) || !Physics2D.Raycast (transform.position, DirFromAngle (137, false), dstToTarget, obstacleMask) && !Physics2D.Raycast (transform.position, DirFromAngle (-90, false), 0.5f, obstacleMask))
		flipTimer += Time.deltaTime;

		// }
		position = transform.position.x;
	}


	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
		if (!angleIsGlobal) {
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
