using UnityEngine;

public class AstronautScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start ()
    {
        Debug.Log("Astro Start");
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Drop()
    {
        Debug.Log("Dropping");
        enabled = true;
        transform.position = new Vector3(0, 0, 0);
        Debug.Log("position is" + transform.position);
    }
}
