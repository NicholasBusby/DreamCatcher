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
        for(int i = 0; i< Astronauts.Length; i++)
        {
            var a = Astronauts[i];
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(countdown == 0)
        {
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
        Instantiate(astronaut, new Vector3(0, 0, 0), Quaternion.identity);
        astronaut.Drop();
    }
}
