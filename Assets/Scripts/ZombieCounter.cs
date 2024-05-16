using UnityEngine;

// This class counts the number of zombies within a certain radius of the player and applies damage accordingly
public class ZombieCounter : MonoBehaviour
{
	// The interval at which to check for zombies
	public float checkInterval = 3f;

	// The radius within which to check for zombies
	public float radius = 3f;

	// Reference to the PlayerHealth script to access player's health data
	private PlayerHealth playerHealth;

	// Start is called before the first frame update
	private void Start()
	{
		// Get the PlayerHealth component attached to this GameObject
		playerHealth = GetComponent<PlayerHealth>();

		// Start invoking the CheckZombies method at a regular interval
		InvokeRepeating(nameof(CheckZombies), 0f, checkInterval);
	}

	// This method checks for zombies within the specified radius and applies damage to the player
	private void CheckZombies()
	{
		// Get all colliders within the specified radius that are on the "Zombie" layer
		Collider[] zombies = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Zombie"));

		// Get the number of zombies
		int zombieCount = zombies.Length;

		// Apply damage to the player based on the number of zombies
		playerHealth.TakeDamage(zombieCount * 5);
	}

	// This method is called when the GameObject is selected and the Gizmos option is enabled
	private void OnDrawGizmosSelected()
	{
		// Set the color of the Gizmos to red
		Gizmos.color = Color.red;

		// Draw a wireframe sphere at the position of the GameObject with the specified radius
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
