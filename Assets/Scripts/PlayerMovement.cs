// Import the UnityEngine library
using UnityEngine;

// This class handles the player's movement
public class PlayerMovement : MonoBehaviour
{
    // SerializeField attribute makes the private field visible in the inspector
    // This is the speed at which the player moves
    [SerializeField] private float moveSpeed = 7f;

    // This vector stores the player's input
    private Vector2 inputVector;

    // This vector stores the direction the player will move in
    private Vector3 moveDir;

    // Update is called once per frame
    private void Update() {
        // Get the player's input and normalize it
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate() {
        // Set the move direction based on the player's input
        moveDir = new(inputVector.x, 0f, inputVector.y);

        // If the move direction is not zero
        if (moveDir != Vector3.zero) {
            // Change the direction of the vector to where the player is looking
            moveDir = transform.TransformDirection(moveDir);

            // Update the player's position based on the move speed, time and direction
            transform.position += moveSpeed * Time.deltaTime * moveDir;
        }
    }
}
