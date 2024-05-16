using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Intro : MonoBehaviour
{
    // Public GameObject variables to hold references to various game objects in the scene
    public GameObject generatorLightA;
    public GameObject generatorLightB;
    public GameObject baseLights;
    public GameObject leftLights;
    public GameObject rightLights;
    public GameObject middleLights;
    public GameObject fanA;
    public GameObject fanB;


// Awake is called when the script instance is being loaded
    public void Awake()
    {
        // Play the intro sequence
        PlayIntro();
    }

    // Function to play the intro sequence
    public void PlayIntro()
    {
        // Start the coroutines for switching on the base and projectors, and for switching the corridor lights
        StartCoroutine(SwitchBase(2.0f));
        StartCoroutine(SwitchOnProjectors(6f));
        StartCoroutine(rightLights.GetComponent<CorridorLights>().SwitchCorridor(8.0f));
        StartCoroutine(middleLights.GetComponent<CorridorLights>().SwitchCorridor(8.0f));
        StartCoroutine(leftLights.GetComponent<CorridorLights>().SwitchCorridor(8.0f));
    }

    // Coroutine to switch on the base after a specified time
    IEnumerator SwitchBase(float time)
    {
        // Create a new list of StairLight objects
        List<StairLight> lights = new();
        // Play the audio source attached to the fans
        fanA.GetComponent<AudioSource>().Play();
        fanB.GetComponent<AudioSource>().Play();
        // Wait for the specified time
        yield return new WaitForSeconds(time);

        // Iterate over each child of the baseLights object
        foreach (Transform child in baseLights.transform)
        {
            // If the child has the tag "StairLight"
            if (child.tag == "StairLight")
            {
                // Get the StairLight component of the child
                var light = child.GetComponent<StairLight>();
                lights.Add(light);

            }
        }
        lights = lights.OrderBy(lights => lights.transform.position.x).ToList();
        foreach (StairLight light in lights)
        {
            light.Switch(true);
        }

    }

    IEnumerator SwitchOnProjectors(float time)
    {
        var lightsA = generatorLightA.transform.Find("Lights");
        var lightsB = generatorLightB.transform.Find("Lights");
        var audioA = generatorLightA.GetComponent<AudioSource>();
        var audioB = generatorLightB.GetComponent<AudioSource>();
        audioA.Play();
        audioB.PlayDelayed(0.5f);
        yield return new WaitForSeconds(time);
        lightsA.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        lightsB.gameObject.SetActive(true);

        // Code to execute after the delay
    }


}
