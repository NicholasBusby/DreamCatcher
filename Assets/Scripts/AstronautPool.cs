using System.Linq;
using UnityEngine;

public class AstronautPool : MonoBehaviour
{
    public AstronautScript[] Astronauts;
    private int nextSpawnIndex = 0;
    private int countdown = 0;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		if(countdown == 0)
        {
            Debug.Log(nextSpawnIndex);
            DropAstronaut(Astronauts[nextSpawnIndex]);
            nextSpawnIndex = (nextSpawnIndex + 1) % Astronauts.Count();
            countdown = (int)Mathf.Floor(Random.value * 1000);
        }
        else
        {
            countdown--;
        }
	}

    void DropAstronaut(AstronautScript astronaut)
    {
        astronaut.enabled = true;
        astronaut.Drop();
    }
}
