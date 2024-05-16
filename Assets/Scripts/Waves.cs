using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class controls the spawning of waves of zombies
public class Waves : MonoBehaviour
{
	// The current wave number
	public int waveNumber = 1;

	// The number of zombies to spawn in the current wave
	public int zombieNumber = 10;

	// An array of zombie prefabs to spawn
	public GameObject[] zombiesPrefab;

	// An array of spawn points where zombies can appear
	public GameObject[] spawnPoints;

	// A singleton instance of the Waves class
	public static Waves instance;

	// The AudioSource component attached to this GameObject
	private AudioSource audioSource;

	public Text waveText;

	// Awake is called when the script instance is being loaded
	void Awake()
	{
		// If there is no instance of Waves yet, set this as the instance
		if (instance == null)
			instance = this;

		// Get the AudioSource component attached to this GameObject
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (zombieNumber == 0)
            StartCoroutine(WavesTransition());
    }

	// Start is called before the first frame update
	void Start()
	{
		// Initialize the wave number and zombie number
		waveNumber = 1;
		zombieNumber = 10;

		// Start the WavesTransition coroutine
		StartCoroutine(WavesTransition());
	}

	// This coroutine controls the transition between waves
	public IEnumerator WavesTransition()
	{
		// Calculate the number of zombies to spawn in the next wave
		zombieNumber = 5 + 5 * waveNumber;
		// Wait for 20 seconds before starting the next wave
		yield return new WaitForSeconds(12.0f);
        // Start the next wave
        StartWave();
	}

	// This method starts a wave of zombie spawns
	void StartWave()
	{
		// If there is no audio playing, start the audio
		if (audioSource.isPlaying == false)
			audioSource.Play();

		waveText.text = "Wave " + waveNumber.ToString();
		waveText.enabled = true;
		StartCoroutine(HideWaveText());

		// Spawn the zombies
		for (int i = 0; i < zombieNumber; i++)
		{
			// Choose a random zombie prefab and spawn point
			int randomZombie = Random.Range(0, zombiesPrefab.Length);
			int randomSpawnPoint = Random.Range(0, spawnPoints.Length);

			// Instantiate the zombie at the spawn point
			Instantiate(zombiesPrefab[randomZombie], spawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
		}

		// Increment the wave number for the next wave
		waveNumber++;
	}

    public IEnumerator HideWaveText()
	{
        yield return new WaitForSeconds(5.0f);
		waveText.enabled = false;
    }
}
