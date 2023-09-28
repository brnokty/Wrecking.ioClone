using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float carSpeed = 100f;
    [SerializeField] private float turnSpeed = 100f;
    [SerializeField] private Transform carPoint;
    [SerializeField] protected List<Transform> frontWheels = new List<Transform>();
    protected bool isGameStarted;
    protected bool isGameFinished;

    protected virtual void Start()
    {
        MainManager.Instance.EventManager.Register(EventTypes.LevelStart, StartCharacter);
    }

    protected virtual void StartCharacter(EventArgs args)
    {
        isGameStarted = true;
    }

    protected void MoveCar(float horizontal)
    {
        RotateWheels(horizontal);
        transform.RotateAround(carPoint.position, Vector3.up, horizontal * turnSpeed);
        transform.position += transform.forward * carSpeed * Time.deltaTime;
    }

    protected void RotateWheels(float horizontalValue)
    {
        float rotationSpeed = 10f; // Dönme hızı
        float maxRotationAngle = 40f; // Maksimum dönme açısı

        float rotationAmount = horizontalValue * rotationSpeed * maxRotationAngle;
        for (int i = 0; i < frontWheels.Count; i++)
        {
            frontWheels[i].rotation = Quaternion.Euler(90f, rotationAmount, 0f);
        }
    }
}