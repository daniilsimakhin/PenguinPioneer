using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resourse : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Slot _slot;

    public Material GetMaterial => _meshRenderer.sharedMaterial;
    public bool IsSlotEmpty => _slot.IsSlotEmpty();

    public void Initialize(Slot slot)
    {
        transform.position = slot.transform.position;
        transform.rotation = slot.transform.rotation;
        transform.SetParent(slot.transform);
        _slot = slot;
        if (_meshRenderer == null)
            _meshRenderer = this.GetComponent<MeshRenderer>();
    }

    public void SetMaterial(Material material)
    {
        _meshRenderer.material = material;
    }
}
