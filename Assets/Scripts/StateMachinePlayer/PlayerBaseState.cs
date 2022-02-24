using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public bool IsFinished;
    public Player Player;

    public abstract void EnterState(Player player);
    public abstract void UpdateState();
}
