using UnityEngine;
using UnityEngine.InputSystem;

// This class controls the animations for the right hand
public class RightHand : MonoBehaviour
{
    // Animator for the hand
    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // Set the "Grip" parameter of the animator to 1, which starts the grip animation
        handAnimator.SetFloat("Grip", 1);
    }
}
