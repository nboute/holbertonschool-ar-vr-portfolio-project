using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// This class controls the lights in a corridor
public class CorridorLights : MonoBehaviour
{
    // Lists to store the lights on the left and right sides of the corridor
    private List<StairLight> leftLights = new();
    private List<StairLight> rightLights = new();

    // Awake is called when the script instance is being loaded
    public void Awake()
    {
        // Iterate over all child objects of this GameObject
        foreach (Transform child in transform)
        {
            // If the child's name is "left", add all its children (the lights) to the leftLights list
            if (child.name == "left")
            {
                foreach (Transform light in child)
                {
                    leftLights.Add(light.GetComponent<StairLight>());
                }
            }
            // If the child's name is "right", add all its children (the lights) to the rightLights list
            if (child.name == "right")
            {
                foreach (Transform light in child)
                {
                    rightLights.Add(light.GetComponent<StairLight>());
                }
            }
        }
        // Order the lights based on their distance from the origin (Vector3.zero)
        leftLights.OrderBy(x => Vector3.Distance(Vector3.zero, x.transform.position));
        rightLights.OrderBy(x => Vector3.Distance(Vector3.zero, x.transform.position));
    }

    // Coroutine to switch on the corridor lights with a delay
    public IEnumerator SwitchCorridor(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Get the number of lights
        var len = leftLights.Count;

        // Set the initial timer for the delay between switching on each light
        var timer = 0.8f;

        // Iterate over all the lights
        for (int i = 0; i < len; i++)
        {
            // Switch on the i-th light on both sides of the corridor
            leftLights[i].Switch(true);
            rightLights[i].Switch(true);

            // Wait for the current timer value
            yield return new WaitForSeconds(timer);

            // Decrease the timer by 0.2f for the next light
            timer -= 0.2f;
        }
    }
}
