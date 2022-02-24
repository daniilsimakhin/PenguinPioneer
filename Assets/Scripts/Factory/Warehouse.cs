using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    public List<Slot> slots;

    public List<Resourse> outputPool;
    public List<Resourse> inputPool;

    public Factory factory;

    public bool _playerInArea;
    [SerializeField] protected float _timer;

    public bool PlayerInArea => _playerInArea;
    public int CountEmptySlots(List<Resourse> pool) => 10 - pool.Count;
}
