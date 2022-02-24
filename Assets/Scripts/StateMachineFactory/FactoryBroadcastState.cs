using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBroadcastState : FactoryBaseState
{
    public override void EnterState(Factory manager)
    {
        Factory = manager;
        IsFinished = false;
    }

    public override void UpdateState()
    {

    }
}
