using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Backpack backpack;
    public PlayerMovement playerMovement;

    public PlayerBaseState currentState;
    public PlayerMoveState PlayerMoveState = new PlayerMoveState();

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        SwitchState(PlayerMoveState);
    }

    private void FixedUpdate()
    {
        if (!currentState.IsFinished)
        {
            currentState.UpdateState();
        }
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
