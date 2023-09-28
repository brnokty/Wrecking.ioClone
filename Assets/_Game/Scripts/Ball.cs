using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private List<GameObject> balls = new List<GameObject>();


    private void Start()
    {
        balls[0].SetActive(false);
        balls[Random.Range(0, balls.Count)].SetActive(true);
        transform.SetParent(null);
        velocity = Vector3.zero;
    }


  
    public Transform target;
    public float speed;
    public float elasticity;

    private Vector3 velocity;
    

    void Update()
    {
        Vector3 desiredPosition = target.position;
        Vector3 currentPosition = transform.position;

        // Calculate the direction towards the target
        Vector3 direction = (desiredPosition - currentPosition).normalized;

        // Calculate the distance between the current position and the target
        float distance = Vector3.Distance(currentPosition, desiredPosition);

        // Calculate the elastic force
        Vector3 elasticForce = direction * elasticity * distance;

        // Apply the elastic force to the velocity
        velocity += elasticForce * Time.deltaTime;

        // Apply the velocity to the position
        transform.position += velocity * speed * Time.deltaTime;

        // Dampen the velocity to simulate friction or air resistance
        velocity *= 1f - (speed * Time.deltaTime);
    }
    
    
    
    // public Transform target;
    //
    // public float speed;
    //
    //
    // void Update()
    // {
    //     transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
    // }
}