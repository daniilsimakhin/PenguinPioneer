using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool IsSlotEmpty()
    {
        if (transform.childCount == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
