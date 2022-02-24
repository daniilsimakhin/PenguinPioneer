using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        Player = player;
        IsFinished = false;
        //Debug.Log("PlayerMoveState enter");
    }

    public override void UpdateState()
    {
        Player.playerMovement.Move();
    }
}
