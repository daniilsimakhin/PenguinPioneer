using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class FactoryBaseState
{
    public bool IsFinished;
    public Factory Factory;

    public abstract void EnterState(Factory manager);
    public abstract void UpdateState();
}
