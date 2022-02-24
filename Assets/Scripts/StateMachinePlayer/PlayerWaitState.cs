using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaitState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        Player = player;
        IsFinished = false;
        //Debug.Log("PlayerWaitState enter");
    }

    public override void UpdateState()
    {
        
    }
}
