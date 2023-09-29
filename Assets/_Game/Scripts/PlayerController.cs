using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CarMovement
{
    [SerializeField] private Joystick joystick;
    [SerializeField] protected ParticleSystem confetti;
    [SerializeField] private CharacterCanvas characterCanvas;
    private float sensitivity = 1f;

    protected override void Start()
    {
        base.Start();
        sensitivity = MainManager.Instance.GameManager.GetSensivityValue();
        MainManager.Instance.EventManager.Register(EventTypes.Win, Win);
    }


    protected override void StartCharacter(EventArgs args)
    {
        base.StartCharacter(args);
        var gameManager = MainManager.Instance.GameManager;
        characterCanvas.infoPanel.SetInfo(gameManager.Name, gameManager.FlagSprite);
    }

    private void Update()
    {
        if (!isGameStarted || isGameFinished)
            return;
        MoveCar(joystick.Horizontal * sensitivity);
    }


    protected override void TouchedWater()
    {
        base.TouchedWater();
        MainManager.Instance.EventRunner.Fail();
    }

    public void Win(EventArgs args)
    {
        carSpeed = 0;
        turnSpeed = 0;
        animationController.SwitchToWinAnimation();
        confetti.gameObject.SetActive(true);
        confetti.Play();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            MainManager.Instance.GameManager.IncreaseCoin(5);
        }
    }
}