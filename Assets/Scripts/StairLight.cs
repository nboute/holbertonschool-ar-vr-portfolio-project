using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the light and sound effects for a stair
public class StairLight : MonoBehaviour
{
    // Reference to the point light GameObject
    public GameObject pointLight;

    // This method switches the light and sound effects on or off
    public void Switch(bool on)
    {
        // Set the active state of the point light to the passed in boolean
        pointLight.SetActive(on);

        // If the light is being switched on
        if (on)
        {
            // Play the AudioSource attached to this GameObject with a slight delay
            gameObject.GetComponent<AudioSource>().PlayDelayed(0.01f);
        }
    }
}
