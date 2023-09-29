using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [HideInInspector] public Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    private void SetTrigger(string parameter)
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(parameter))
            return;

        _animator.SetTrigger(parameter);
    }

    private void SetBool(string parameter, bool value)
    {
        _animator.SetBool(parameter, value);
    }

    private void SetFloat(string parameter, float value)
    {
        _animator.SetFloat(parameter, value);
    }
    
    
    //Happy
    public void SwitchToHappyAnimation()
    {
        _animator.SetTrigger("Happy");
    }
    
    //Win
    public void SwitchToWinAnimation()
    {
        _animator.SetTrigger("Win");
    }

  
}