using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    public Warehouse outputWarehouse;
    public Warehouse inputWarehouse;

    [SerializeField] protected Material[] comparedMaterials;
    [SerializeField] protected Material settingMaterial;
    [SerializeField] protected Resourse prefab;
    [SerializeField] protected NotificationHandler notificationHandler;

    public Player player;

    public FactoryBaseState currentState;
    public FactoryBroadcastState BroadcastState = new FactoryBroadcastState();
    public FactoryReliaseState ReliaseState = new FactoryReliaseState();
    public FactoryWaitState WaitState = new FactoryWaitState();

    public void SwitchState(FactoryBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public virtual void StayInOutputWarehouse()
    {
        if (currentState != BroadcastState)
            SwitchState(BroadcastState);

        if (player.backpack.ResoursesCount < 10 && outputWarehouse.outputPool.Count != 0)
        {
            if (player.backpack.NumberEmptySlots >= outputWarehouse.outputPool.Count)
            {
                for (int i = 0; i < outputWarehouse.outputPool.Count;)
                {
                    Resourse resourse = outputWarehouse.outputPool.First();
                    outputWarehouse.outputPool.Remove(resourse);
                    player.backpack.PutToBackpack(resourse);
                }
            }
            else if (player.backpack.NumberEmptySlots < outputWarehouse.outputPool.Count)
            {
                for (int i = 0; i < player.backpack.NumberEmptySlots;)
                {
                    Resourse resourse = outputWarehouse.outputPool.First();
                    outputWarehouse.outputPool.Remove(resourse);
                    player.backpack.PutToBackpack(resourse);
                }
            }
        }
        if (player.backpack.ResoursesCount == 10)
        {
            notificationHandler.RefreshNotification("Рюкзак переполнен");
            SwitchState(WaitState);
            return;
        }
        if (outputWarehouse.outputPool.Count == 0)
        {
            notificationHandler.RefreshNotification($"Хранилище выдачи {gameObject.name} пустое");
            SwitchState(WaitState);
            return;
        }
    }

    public virtual void StayInInputWarehouse()
    {
        if (currentState != BroadcastState)
            SwitchState(BroadcastState);

        if (player.backpack.ResoursesCount > 0 && inputWarehouse.inputPool.Count < 10)
        {
            if (inputWarehouse.CountEmptySlots(inputWarehouse.inputPool) >= player.backpack.ResoursesCount)
            {
                for (int i = 0; i < player.backpack.ResoursesCount; i++)
                {
                    Slot slot = inputWarehouse.slots.FirstOrDefault(x => x.IsSlotEmpty() == true);
                    if (slot != default)
                    {
                        if (player.backpack.CompareMaterial(i, comparedMaterials))
                        {
                            inputWarehouse.inputPool.Add(player.backpack.TakeFromBackpack(i, slot.transform));
                            i = 0;
                        }
                        else
                        {
                            notificationHandler.RefreshNotification($"Хранилище {gameObject.name} не может переработать данный ресурс");
                        }
                    }
                }
            }
            else if (inputWarehouse.CountEmptySlots(inputWarehouse.inputPool) < player.backpack.ResoursesCount)
            {
                for (int i = 0; i < player.backpack.ResoursesCount; i++)
                {
                    Slot slot = inputWarehouse.slots.FirstOrDefault(x => x.IsSlotEmpty() == true);
                    if (slot != default)
                    {
                        if (player.backpack.CompareMaterial(i, comparedMaterials))
                        {
                            inputWarehouse.inputPool.Add(player.backpack.TakeFromBackpack(i, slot.transform));
                            i = 0;
                        }
                        else
                        {
                            notificationHandler.RefreshNotification($"Хранилище {gameObject.name} не может переработать данный ресурс");
                        }
                    }
                }
            }
        }
        if (player.backpack.ResoursesCount == 0)
        {
            notificationHandler.RefreshNotification("Рюкзак пуст");
            SwitchState(WaitState);
            return;
        }
        if (inputWarehouse.inputPool.Count == 10)
        {
            notificationHandler.RefreshNotification($"Хранилище выдачи {gameObject.name} заполнено");
            SwitchState(WaitState);
            return;
        }
    }

    public virtual void EnterInWarehouse(Player player) { this.player = player; SwitchState(WaitState); }
    public virtual void EnterInWarehouse() { SwitchState(WaitState); }
    public virtual void ExitFromWarehouse() { SwitchState(WaitState); }
    public abstract void CreateResourse();
    public abstract void TryReliase(ref float timer);
}
