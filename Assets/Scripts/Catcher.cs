using System;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    public float ForceMultiplier = 1.5f;
    public float SlowDownRate = .999f;

    private bool isDead = false;
    private Rigidbody2D rigidbody2d;
    private PolygonCollider2D polygonCollider;
    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector3 dir = position - rigidbody2d.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                angle = (angle - 90) % 360;

                rigidbody2d.AddForce(dir.normalized * ForceMultiplier);
                rigidbody2d.rotation = angle;
                animator.SetTrigger("Fly");
            }
            else
            {
                animator.SetTrigger("Idle");
                Slow();
            }
        }
        else
        {
            Slow();
        }

        var viewPortPosition = Camera.main.WorldToViewportPoint(rigidbody2d.position);
        if(viewPortPosition.x < 0 || viewPortPosition.x > 1)
        {
            rigidbody2d.velocity = new Vector2(-rigidbody2d.velocity.x, rigidbody2d.velocity.y);
            SetDeath();
        }
        if(viewPortPosition.y < 0 || viewPortPosition.y > 1)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, -rigidbody2d.velocity.y);
            SetDeath();
        }
	}

    private void SetDeath()
    {
        animator.SetTrigger("Die");
        isDead = true;
        GameControl.Instance.KillPlayer();
    }

    private void Slow()
    {
        if(rigidbody2d.velocity.magnitude < .03f)
        {
            rigidbody2d.velocity = Vector2.zero;
        }
        else
        {
            rigidbody2d.velocity *= SlowDownRate;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.StartsWith("Rescue", StringComparison.OrdinalIgnoreCase) && !isDead)
        {
            Destroy(collision.gameObject);
            GameControl.Instance.AddToScore();
        }
    }
}
