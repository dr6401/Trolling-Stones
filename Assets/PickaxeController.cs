using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeController : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed at which the pickaxe rotates
    private Vector2 targetPosition; // Target position for rotation
    private float targetAngle; // Calculated target angle
    public float swingForce = 10f; // Force of the swing
    public float screenDivisionX = 0f; // X position dividing the screen for the two pickaxes
    public bool isLeftPickaxe = true; // Determine if this is the left pickaxe
    public Transform otherPickaxe; // Reference to the other pickaxe's Transform

    void Update()
    {
        if (Input.GetMouseButton(0)) // Check if the left mouse button is clicked
        {
            // Detect the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Determine which pickaxe's region the click occurred in
            bool clickedLeft = mousePosition.x < screenDivisionX;

            // Set the target position and calculate rotation based on the relevant pickaxe
            Transform relevantPickaxe = clickedLeft ? transform : otherPickaxe;
            RotatePickaxes(mousePosition, relevantPickaxe);
        }
    }

    void RotatePickaxes(Vector3 mousePosition, Transform relevantPickaxe)
    {
        // Calculate the direction vector from the relevant pickaxe to the mouse position
        Vector2 direction = (Vector2)mousePosition - (Vector2)relevantPickaxe.position;

        // Calculate the target angle based on the mouse position
        targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        // Apply rotation to both pickaxes
        RotatePickaxe(transform, targetAngle);
        RotatePickaxe(otherPickaxe, targetAngle);
    }

    void RotatePickaxe(Transform pickaxe, float angle)
    {
        // Get the current angle of the pickaxe
        float currentAngle = pickaxe.eulerAngles.z;

        // Gradually rotate the pickaxe towards the target angle
        float angleDifference = Mathf.DeltaAngle(currentAngle, angle);
        float newAngle = Mathf.LerpAngle(currentAngle, currentAngle + angleDifference, rotationSpeed * Time.deltaTime);

        // Apply the rotation
        pickaxe.rotation = Quaternion.Euler(0f, 0f, newAngle);
    }
}
