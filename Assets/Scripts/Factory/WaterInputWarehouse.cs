using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterInputWarehouse : Warehouse
{
    private void OnTriggerEnter(Collider other)
    {
        _playerInArea = true;
        if (other.TryGetComponent(out Player player) && factory.player == null)
            factory.EnterInWarehouse(player);
        else
            factory.EnterInWarehouse(player);
    }

    private void OnTriggerStay(Collider other)
    {
        if (_timer > 1 && _playerInArea)
            factory.StayInInputWarehouse();
    }

    private void OnTriggerExit(Collider other)
    {
        _playerInArea = false;
        factory.SwitchState(factory.WaitState);
    }

    private void Update()
    {
        if (_playerInArea)
            _timer += Time.deltaTime;
        else
            _timer = 0;
    }
}
