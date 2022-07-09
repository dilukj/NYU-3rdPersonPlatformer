using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTransformation : MonoBehaviour
{
    [Header("Movement Parameters")]
    public Vector3 movementAxis = Vector3.left;
    public float movementSpeed = 0.0f;
    public float movementDistance = 1.0f;

    [Header("Movement Positions")]
    public Vector3 startingPosition;
    public Vector3 posEnd;
    public Vector3 negEnd;
    private Vector3 direction;

    [Header("Rotation Parameters")]
    public Vector3 axis = Vector3.up;
    public float rotationStep = 10.0f;
    public float rotationStartAngle = 0.0f;
    public float rotationEndAngle = 0.5f;

    [Header("Scale Parameters")]
    public Vector3 scaleDirection = Vector3.right;
    public float scaleStep = 0.1f;
    public float minScale = 1.0f;
    public float maxScale = 5.0f;
    private float scaleFactor = 0.0f;
    private Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        // the direction of movement
        direction = movementAxis.normalized;
        originalScale = transform.localScale;
        scaleFactor = minScale;
        // precompute positions
        startingPosition = transform.position;
        posEnd = transform.position + (direction * movementDistance);
        negEnd = transform.position - (direction * movementDistance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if we reach the bounds of the movement, reverse the direciton vector
        if (Vector3.Distance(transform.position, posEnd) < 0.01f || Vector3.Distance(transform.position, negEnd) < 0.01f)
            direction *= -1;
        // move the platform
        transform.Translate(direction * movementSpeed * Time.deltaTime);

        if (transform.rotation.y < rotationStartAngle || transform.rotation.y > rotationEndAngle)
            rotationStep *= -1;
        transform.Rotate(axis, rotationStep * Time.deltaTime, Space.Self);

        if (scaleFactor > maxScale || scaleFactor < minScale)
            scaleStep *= -1;

        scaleFactor = scaleFactor + scaleStep * Time.deltaTime;

        transform.localScale = originalScale + scaleDirection * scaleFactor;

    }
}