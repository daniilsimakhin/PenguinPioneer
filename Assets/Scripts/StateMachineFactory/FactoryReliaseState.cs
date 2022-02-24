using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryReliaseState : FactoryBaseState
{
    float timer;

    public override void EnterState(Factory manager)
    {
        Factory = manager;
        IsFinished = false;
    }

    public override void UpdateState()
    {
        Factory.TryReliase(ref timer);
    }
}
