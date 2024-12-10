using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickaxeController : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed at which the pickaxe rotates
    private Vector2 targetPosition;
    private float targetAngle;
    private bool isClicked = false; // Track if the mouse is clicked
    public float swingForce = 10f;

    void Update()
    {
        // Check if the player clicked on the screen
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            isClicked = true; // Set to true when clicked
        }

        if (Input.GetMouseButtonUp(0)) // 0 is the left mouse button
        {
            isClicked = false; // Set to true when clicked
        }

        // If clicked, start the rotation
        if (isClicked)
        {
            // Detect the mouse position
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calculate the direction vector from the pickaxe holder to the mouse position
            Vector2 direction = targetPosition - (Vector2)transform.position;

            // Calculate the target angle based on the mouse position
            targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

            // Get the current angle of the pickaxe holder
            float currentAngle = transform.eulerAngles.z;

            // Calculate the difference between the current angle and the target angle
            float angleDifference = Mathf.DeltaAngle(currentAngle, targetAngle);

            // Gradually rotate the pickaxe towards the target angle, respecting the shortest direction
            float angle = Mathf.LerpAngle(currentAngle, currentAngle + angleDifference, rotationSpeed * Time.deltaTime);

            // Apply the rotation to the pickaxe holder
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}