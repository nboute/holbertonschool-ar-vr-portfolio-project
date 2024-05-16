using UnityEngine;
using UnityEngine.InputSystem;

// This class controls the animations for the left hand based on input actions
public class LeftHand : MonoBehaviour
{
    // Input action for the pinch animation
    public InputActionProperty pinchAnimationAction;

    // Input action for the grip animation
    public InputActionProperty gripAnimationAction;

    // Animator for the hand
    public Animator handAnimator;

    // Update is called once per frame
    void Update()
    {
        // Read the value of the pinch animation action
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();

        // Set the "Trigger" parameter of the animator to the pinch action value
        handAnimator.SetFloat("Trigger", triggerValue);

        // Read the value of the grip animation action
        float gripValue = gripAnimationAction.action.ReadValue<float>();

        // Set the "Grip" parameter of the animator to the grip action value
        handAnimator.SetFloat("Grip", gripValue);
    }
}
