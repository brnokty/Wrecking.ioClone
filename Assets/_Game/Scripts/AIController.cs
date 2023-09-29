using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIController : CarMovement
{
    private bool onGround = true;
    private bool falling;
    private bool isDrifting;


    private Vector3 lookPos;
    private Vector3 destination;
    private Transform target;


    protected override void Start()
    {
        base.Start();
        List<CarMovement> targets = FindObjectsOfType<CarMovement>().ToList();
        targets.Remove(this);

        target = targets[Random.Range(0, targets.Count)].transform;
    }


    private void FixedUpdate()
    {
        if (!isGameStarted || isGameFinished || target == null)
            return;

        // if (landing) AirToGround();
        if (falling) TurnStraight();
        if (isDrifting) transform.RotateAround(carPoint.transform.position, Vector3.up, turnSpeed);
        if (onGround)
        {
            if (!isDrifting)
                transform.rotation = Quaternion.Slerp(transform.rotation
                    , Quaternion.LookRotation((target.position + destination) - transform.position)
                    , 3f * Time.deltaTime);

            transform.position += transform.forward * carSpeed * Time.deltaTime;
        }

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

    private void Update()
    {
        if (!isGameStarted || isGameFinished || target == null)
            return;

        destination = (Vector3.zero - target.position).normalized * 7;

        if ((target.position - transform.position).magnitude < 15)
        {
            isDrifting = true;
        }
        else isDrifting = false;


        if (transform.position.y > 0.5f && !falling)
        {
            onGround = false;
        }

        if (!onGround)
        {
            var size = GetComponent<BoxCollider>().size;
            Debug.DrawRay(transform.position, -transform.up * 0.1f, Color.red);
            Debug.DrawRay(transform.position, transform.up * (size.y + 0.1f), Color.red);
            if (Physics.Raycast(transform.position, -transform.up, 0.1f, 64) ||
                Physics.Raycast(transform.position, transform.up, size.y + 0.1f, 64))
            {
                StartCoroutine(AirToGroundCounter());
            }

            if (GetComponent<Rigidbody>().velocity.magnitude < 0.1f)
            {
                StartCoroutine(AirToGroundCounter());
            }
        }
    }

    // private void AirToGround()
    // {
    //     Vector3 carPos = transform.position;
    //     Vector3 targetPos = new Vector3(carPos.x, -0.05f, carPos.z);
    //     Quaternion targetRot = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
    //     transform.position = Vector3.Lerp(transform.position, targetPos, 0.5f);
    //     transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRot, 0.5f);
    // }

    private IEnumerator AirToGroundCounter()
    {
        onGround = true;
        falling = true;
        yield return new WaitForSeconds(0.3f);
        falling = false;
    }

    protected override void TouchedWater()
    {
        base.TouchedWater();
        FindObjectOfType<AIHandler>().RemoveAI(this);
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}