using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Renderer render;
	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        render = GetComponent<Renderer>();
        rb2d.velocity = new Vector2(0, GameControl.Instance.BackgroundSpeed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        var viewPortPosition = Camera.main.WorldToViewportPoint(rb2d.position);
        if(viewPortPosition.y < -.75f)
        {
            rb2d.position = new Vector2(rb2d.position.x, (render.bounds.size.y * 3) + rb2d.position.y);
        }
	}
}
