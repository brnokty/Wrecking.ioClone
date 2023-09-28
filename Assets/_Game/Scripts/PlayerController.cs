using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CarMovement
{
    [SerializeField] private Joystick joystick;
    
    [SerializeField] private CharacterCanvas characterCanvas;


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
        MoveCar(joystick.Horizontal);
        print("joyH : " + joystick.Horizontal);
    }


    // private void Update()
    // {
    //     if (Input.GetMouseButton(0))
    //     {
    //         direction = Vector3.right * joystick.Horizontal*0.2f;
    //     }
    // }
    //
    // private void FixedUpdate()
    // {
    //     Move();
    //     if (Input.GetMouseButton(0))
    //         Rotate();
    // }
}