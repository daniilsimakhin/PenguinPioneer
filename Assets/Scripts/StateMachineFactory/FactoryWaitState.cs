using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryWaitState : FactoryBaseState
{
    public override void EnterState(Factory manager)
    {
        Factory = manager;
        IsFinished = false;
    }

    public override void UpdateState()
    {
        if (Factory.inputWarehouse != null)
        {
            if (Factory.outputWarehouse.outputPool.Count != 10 && Factory.inputWarehouse.inputPool.Count != 0)
            {
                if (!Factory.outputWarehouse.PlayerInArea && !Factory.inputWarehouse.PlayerInArea)
                {
                    Factory.SwitchState(Factory.ReliaseState);
                }
            }
        }
        else
        {
            if (Factory.outputWarehouse.outputPool.Count != 10 && !Factory.outputWarehouse._playerInArea)
            {
                Factory.SwitchState(Factory.ReliaseState);
            }
        }
    }
}
