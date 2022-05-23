using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] private float thrustForce = 1000f;
    [SerializeField] private float rotationSpeed = 5f;

    private bool canThrust, rotateLeft, rotateRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();   
    }

    private void Update() 
    {
        // Thrust
        if(canThrust)
        {
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
            if(!audioSource.isPlaying) audioSource.Play();
        }
        else audioSource.Stop();

        // Rotation
        if(rotateLeft) ApplyRotation(rotationSpeed);
        else if(rotateRight) ApplyRotation(-rotationSpeed);
    }

    void ApplyRotation(float rotationValue)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationValue * Time.deltaTime);
        rb.freezeRotation = false;
    }

    #region "UI Input Methods"
    
    public void Thrust() => canThrust = true; 

    public void StopThrust() => canThrust = false;

    public void RotateLeft() => rotateLeft = true;

    public void StopRotateLeft() => rotateLeft = false;

    public void RotateRight() => rotateRight = true;   

    public void StopRotateRight() => rotateRight = false;
    
    #endregion
}
