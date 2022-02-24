using System.Linq;
using UnityEngine;

public class SnowFactory : Factory
{
    public override void CreateResourse()
    {
        Slot slot = outputWarehouse.slots.FirstOrDefault(x => x.IsSlotEmpty() == true);
        if (slot != default)
        {
            Resourse resourse = Instantiate(prefab);
            resourse.Initialize(slot);
            resourse.SetMaterial(settingMaterial);
            outputWarehouse.outputPool.Add(resourse);
        }
    }

    public override void TryReliase(ref float timer)
    {
        if (outputWarehouse.outputPool.Count == 10)
        {
            notificationHandler.RefreshNotification($"Хранилище выгрузки {gameObject.name} заполнено");
            SwitchState(WaitState);
            return;
        }

        if (timer > 1)
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
