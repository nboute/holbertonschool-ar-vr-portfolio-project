using UnityEngine;
using UnityEngine.SceneManagement;

// This class manages the health of the player
public class PlayerHealth : MonoBehaviour
{
	public GameObject gameOverCanvas;
	// Maximum health the player can have
	public int maxHealth = 100;

	// Current health of the player
	public int currentHealth;

	// Start is called before the first frame update
	private void Start()
	{
		// Set the current health to the maximum health at the start of the game
		currentHealth = maxHealth;
	}

	// This method is called when the player takes damage
	public void TakeDamage(int damage)
	{
		// Subtract the damage from the current health
		currentHealth -= damage;

		// If the current health is less than or equal to zero, the player dies
		if (currentHealth <= 0)
		{
            SceneManager.LoadScene(2);
        }
	}

}
