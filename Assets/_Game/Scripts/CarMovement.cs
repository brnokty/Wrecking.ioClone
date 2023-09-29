using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] protected float carSpeed = 100f;
    [SerializeField] protected float turnSpeed = 100f;
    [SerializeField] protected Ball ball;
    [SerializeField] protected Transform carPoint;
    [SerializeField] protected ParticleSystem collectEffect;
    [SerializeField] protected CharacterAnimationController animationController;
    [SerializeField] protected List<Transform> frontWheels = new List<Transform>();
    [SerializeField] protected List<TrailRenderer> driftTrails = new List<TrailRenderer>();
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
        if (horizontal != 0)
        {
            for (int i = 0; i < driftTrails.Count; i++)
            {
                var pos = driftTrails[i].transform.localPosition;
                pos.y = -0.05f;
                driftTrails[i].transform.localPosition = pos;
            }
        }
        else
        {
            for (int i = 0; i < driftTrails.Count; i++)
            {
                var pos = driftTrails[i].transform.localPosition;
                pos.y = -0.1f;
                driftTrails[i].transform.localPosition = pos;
            }
        }

        RotateWheels(horizontal);
        if (transform.position.y <= 0.2f && transform.position.y >= -0.2f)
        {
            transform.RotateAround(carPoint.position, Vector3.up, horizontal * turnSpeed);
            transform.position += transform.forward * carSpeed * Time.deltaTime;
        }

        var rot = transform.rotation.eulerAngles;
        if (rot.x > 60 || rot.x < -60 || rot.z > 60 || rot.z < -60)
        {
            TurnStraight();
        }
    }

    protected void RotateWheels(float horizontalValue)
    {
        float rotationSpeed = 10f;
        float maxRotationAngle = 10f;

        // float rotationAmount = horizontalValue * rotationSpeed * maxRotationAngle;
        float rotationAmount = Mathf.Lerp(-maxRotationAngle, maxRotationAngle, horizontalValue);
        for (int i = 0; i < frontWheels.Count; i++)
        {
            frontWheels[i].rotation = Quaternion.Euler(90f, rotationAmount, 0f);
        }

        DriftTrailCheck();
    }

    protected void DriftTrailCheck()
    {
        if (transform.position.y > 0.2f || transform.position.y < -0.2f)
        {
            for (int i = 0; i < driftTrails.Count; i++)
            {
                driftTrails[i].emitting = false;
            }
        }
        else
        {
            for (int i = 0; i < driftTrails.Count; i++)
            {
                driftTrails[i].emitting = true;
            }
        }
    }

    private Tween rotateTween;

    protected void TurnStraight()
    {
        if (rotateTween != null)
            if (rotateTween.active)
                return;
        var rotation = transform.rotation.eulerAngles;
        rotation.x = 0;
        rotation.z = 0;
        rotateTween = transform.DORotate(rotation, 0.5f);
    }

    protected virtual void TouchedWater()
    {
        carSpeed = 0;
        turnSpeed = 0;
        GetComponent<Rigidbody>().isKinematic = true;
        transform.DOMoveY(-4f, 0.8f);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DropBox"))
        {
            Destroy(other.transform.parent.gameObject);
            collectEffect.Play();
            animationController.SwitchToHappyAnimation();
            ball.GetFever();
        }

        if (other.CompareTag("Water"))
        {
            if (transform.position.y <= -2)
                TouchedWater();
        }
    }
}