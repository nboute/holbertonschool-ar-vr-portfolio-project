using UnityEngine;
using UnityEngine.UI;

// This class manages the health bar UI for the player
public class HealthBar : MonoBehaviour
{
	// Reference to the PlayerHealth script to access player's health data
	public PlayerHealth playerHealth;

	// Reference to the Slider component that represents the health bar
	private Slider healthSlider;

	// Start is called before the first frame update
	private void Start()
	{
		// Get the Slider component attached to this GameObject
		healthSlider = GetComponent<Slider>();
	}

	// Update is called once per frame
	private void Update()
	{
		// If the playerHealth and healthSlider references are not null
		if (playerHealth != null && healthSlider != null)
		{
			// Update the health bar's value to represent the player's current health as a fraction of the maximum health
			healthSlider.value = (float)playerHealth.currentHealth / playerHealth.maxHealth;
		}
	}
}
