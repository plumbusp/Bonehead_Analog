using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StablePlayerController : MonoBehaviour
{
    public Action OnCharacterClick;

    //Animation Stats
    private Animator _animator;
    private string _currentState;
    private const string PLAYER_IDLE = "Player_Idle";
    private const string PLAYER_JUMP = "Player_Die";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        ChangeAnimationState(PLAYER_JUMP);
        OnCharacterClick?.Invoke();
        Debug.Log("Clicked");
    }

    public void ReturnToDefaultAnimation()
    {
        _currentState = PLAYER_IDLE;
        _animator.Play(_currentState);
    }

    private void ChangeAnimationState(string newState)
    {
        if (_currentState == newState)
            return;
        _currentState = newState;
        _animator.Play(newState);
    }
}
