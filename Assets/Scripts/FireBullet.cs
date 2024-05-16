using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Controls firing behavior of a weapon.
/// </summary>
public class FireBullet : MonoBehaviour
{
    /// <summary>
    /// Input action for firing.
    /// </summary>
    public InputActionProperty fireAction;

    /// <summary>
    /// Damage inflicted by the bullet.
    /// </summary>
    public int damage = 50;

    private bool cooldown = true; // Cooldown flag to prevent rapid firing.

    /// <summary>
    /// Layer mask to filter collisions.
    /// </summary>
    public LayerMask mask;

    private RaycastHit hit; // Stores information about the raycast hit.

    /// <summary>
    /// Audio source for gun sound effects.
    /// </summary>
    public AudioSource gunSound;

    /// <summary>
    /// Prefab for bullet hole visual effect.
    /// </summary>
    public GameObject bulletHole;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        // Read the value of the fire action.
        float fire = fireAction.action.ReadValue<float>();

        // Check if the weapon is ready to fire and fire action is pressed.
        if (cooldown && fire > 0.8)
        {
            // Fire the weapon.
            cooldown = false; // Set cooldown to prevent rapid firing.
            gunSound.Play(); // Play the gun sound effect.

            // Perform a raycast to detect hits.
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100f, mask))
            {
                // Create a visual effect at the hit point.
                CreateBulletImpact(hit);

                // Check if the hit object is a zombie.
                if (hit.collider.tag == "Zombie")
                {
                    // Attempt to get the Zombie component from the hit object.
                    Zombie zombie = hit.collider.gameObject.GetComponent<Zombie>();

                    // If the Zombie component is found, apply damage.
                    if (zombie != null)
                        zombie.TakeDamage(damage);
                }
            }
        }

        // Reset cooldown when fire action is released.
        if (fire < 0.2)
            cooldown = true;
    }

    /// <summary>
    /// Creates a bullet impact visual effect at the specified hit point.
    /// </summary>
    /// <param name="hit">Information about the raycast hit.</param>
    void CreateBulletImpact(RaycastHit hit)
    {
        // Instantiate bullet hole effect at the hit point with proper rotation.
        GameObject hole = Instantiate(bulletHole, hit.point, Quaternion.LookRotation(hit.normal));
    }
}