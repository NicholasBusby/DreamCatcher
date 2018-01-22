using UnityEngine;

public class AstronautScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.position = new Vector3(rb2d.position.x, rb2d.position.y, 0);
        Drop();
	}
	
	// Update is called once per frame
	void Update ()
    {
        var position = Camera.main.WorldToViewportPoint(rb2d.position);
        if(position.y < 0)
        {
            Destroy(gameObject);
        }
	}

    public void Drop()
    {
        rb2d.AddForce(new Vector2(0, (Random.value * -50) - 50));
        rb2d.AddTorque(Random.value * 10);
    }
}
