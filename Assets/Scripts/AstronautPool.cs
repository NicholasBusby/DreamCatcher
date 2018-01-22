using System.Linq;
using UnityEngine;

public class AstronautPool : MonoBehaviour
{
    public AstronautScript[] Astronauts;
    private int nextSpawnIndex = 0;
    private float countdown = 1;

	// Use this for initialization
	void Start ()
    {
        for(int i = 0; i< Astronauts.Length; i++)
        {
            var a = Astronauts[i];
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(countdown < 0)
        {
            countdown = Random.value * 5;
            DropAstronaut(Astronauts[nextSpawnIndex]);
            nextSpawnIndex = (nextSpawnIndex + 1) % Astronauts.Count();
        }
        else
        {
            countdown -= Time.deltaTime;
        }
	}

    void DropAstronaut(AstronautScript astronaut)
    {
        var startLocation = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, 1.1f, Camera.main.nearClipPlane));
        Instantiate(astronaut, startLocation, Quaternion.identity);
    }
}
