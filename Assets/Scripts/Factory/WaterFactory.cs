using System.Linq;
using UnityEngine;

public class WaterFactory : Factory
{
    public override void CreateResourse()
    {
        Slot slot = outputWarehouse.slots.FirstOrDefault(x => x.IsSlotEmpty() == true);
        if (slot != default)
        {
            Resourse resourse = inputWarehouse.inputPool.First();
            resourse.Initialize(slot);
            resourse.SetMaterial(settingMaterial);
            outputWarehouse.outputPool.Add(resourse);
            inputWarehouse.inputPool.Remove(resourse);
        }
    }

    public override void TryReliase(ref float timer)
    {
        if (outputWarehouse.outputPool.Count == 10)
        {
            notificationHandler.RefreshNotification($"Хранилище {gameObject.name} выгрузки заполнено");
            SwitchState(WaitState);
            return;
        }
        else if (inputWarehouse.inputPool.Count == 0)
        {
            notificationHandler.RefreshNotification($"Хранилище {gameObject.name} загрузки пустое");
            SwitchState(WaitState);
            return;
        }
        if (timer > 2)
        {
            CreateResourse();
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void Start()
    {
        SwitchState(WaitState);
    }

    private void Update()
    {
        if (!currentState.IsFinished)
        {
            currentState.UpdateState();
        }
    }
}
