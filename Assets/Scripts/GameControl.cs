using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public float BackgroundSpeed = -1.5f;

    public static GameControl Instance;

    public Text ScoreVisual;
    public Text DeathVisual;
    public Button AdButton;

    private int score = 0;
    private bool playerAlive = true;

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
        DeathVisual.enabled = false;
        AdButton.enabled = false;
        AdButton.onClick.AddListener(AdButtonClicked);
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void AddToScore()
    {
        if(playerAlive)
        {
            score++;
            ScoreVisual.text = $"Score: {score}";
        }
    }

    public void KillPlayer()
    {
        if (!playerAlive)
            return;

        playerAlive = false;
        DeathVisual.enabled = true;
        AdButton.enabled = true;
    }

    public void AdButtonClicked()
    {
        Debug.Log("Clicked");
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
