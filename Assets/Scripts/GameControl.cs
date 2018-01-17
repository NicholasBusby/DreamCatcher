using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public float BackgroundSpeed = -1.5f;

    public static GameControl Instance;

    private void Awake()
    {
        Instance = Instance ?? this;

        if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
