using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private List<GameObject> balls = new List<GameObject>();


    public Transform target;
    public Transform player;
    public float speed;
    public float elasticity;
    public float feverTime = 10f;
    public float rotateSpeed = 20f;
    public Rigidbody rb;

    private Vector3 velocity;
    private bool isFeverMode;
    protected bool isGameStarted;

    private void Start()
    {
        MainManager.Instance.EventManager.Register(EventTypes.LevelStart, LevelStart);
        MainManager.Instance.EventManager.Register(EventTypes.UpgradePlayer, BallUpdate);
        balls[0].SetActive(false);
        balls[Random.Range(0, balls.Count)].SetActive(true);
        velocity = Vector3.zero;
    }


    public void LevelStart(EventArgs args)
    {
        var _scale = Vector3.one * (1 + MainManager.Instance.GameManager.BallSizeLevel * 0.1f);
        transform.parent.DOScale(_scale, 0.3f);
        transform.SetParent(null);
    }

    public void BallUpdate(EventArgs args)
    {
        var _scale = Vector3.one * (1 + MainManager.Instance.GameManager.BallSizeLevel * 0.1f);
        transform.parent.DOScale(_scale, 0.3f);
    }

    void Update()
    {
        if (isFeverMode || !isGameStarted)
            return;

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


    public void GetFever()
    {
        if (!isFeverMode)
            StartCoroutine(RotateObjectForDuration(feverTime));
    }

    IEnumerator RotateObjectForDuration(float rotationDuration)
    {
        isFeverMode = true;
        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration)
        {
            transform.RotateAround(player.position, Vector3.up, rotateSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isFeverMode = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.CompareTag("Player") || collision.collider.CompareTag("AI")) &&
            collision.gameObject != player.gameObject)
        {
            float vel = rb.velocity.magnitude + 10f;

            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * vel * 1, ForceMode.VelocityChange);

            // gameObject.GetComponentInParent<AnimatorController>().Hit();

            Debug.Log($"Car launched with velocity of {vel}.");

            // if (isPlayer) transform.parent.GetComponent<Customizer>().Hit(vel);
        }
    }
}