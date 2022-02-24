using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceOutputWarehouse : Warehouse
{
    private void OnTriggerEnter(Collider other)
    {
        _playerInArea = true;
        if (other.TryGetComponent(out Player player) && factory.player == null)
            factory.EnterInWarehouse(player);
        else
            factory.EnterInWarehouse();
    }

    private void OnTriggerStay(Collider other)
    {
        if (_timer > 1 && _playerInArea)
            factory.StayInOutputWarehouse();            
    }

    private void OnTriggerExit(Collider other)
    {
        _playerInArea = false;
        factory.ExitFromWarehouse();
    }

    private void Update()
    {
        if (_playerInArea)
            _timer += Time.deltaTime;
        else
            _timer = 0;
    }
}
