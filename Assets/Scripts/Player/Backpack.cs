using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] private List<Resourse> _resourses;

    public int ResoursesCount => _resourses.Count;
    public int NumberEmptySlots => 10 - _resourses.Count;

    public bool CompareMaterial(int i, Material[] comparedMaterials)
    {
        int count = 0;
        for (int j = 0; j < comparedMaterials.Length; j++)
        {
            if (_resourses[i].GetMaterial != comparedMaterials[j])
                count++;
        }
        if (count == comparedMaterials.Length)//(_resourses[i].GetMaterial != material)
            return true;
        else
            return false;
    }

    public bool TakeFromBackpack(int i, Transform targetTransform, Material material, out Resourse resourse)
    {
        if (_resourses[i].GetMaterial != material)
        {
            resourse = _resourses[i];
            resourse.transform.SetParent(targetTransform);
            _resourses.Remove(resourse);
            StartCoroutine(GiveElement(resourse.transform, targetTransform));
            return true;
        }
        else
        {
            resourse = null;
            return false;
        }
    }

    public Resourse TakeFromBackpack(int i, Transform targetTransform)
    {
        Resourse resourse = _resourses[i];
        resourse.transform.SetParent(targetTransform);
        _resourses.Remove(resourse);
        StartCoroutine(GiveElement(resourse.transform, targetTransform));
        return resourse;
    }

    public void PutToBackpack(Resourse resourse)
    {
        if (ResoursesCount < 10)
        {
            resourse.transform.SetParent(this.transform);
            _resourses.Add(resourse);
            StartCoroutine(GetElement(resourse.transform, _resourses.IndexOf(resourse))); ;            
        }
        else
        {
            return;
        }
    }

    private IEnumerator GiveElement(Transform gameobject, Transform targetTransform)
    {
        Vector3 originPosition = gameobject.position;

        float t = 0;

        float animationDuration = 1f;

        while (t < 1)
        {
            gameobject.position = Vector3.Lerp(originPosition, targetTransform.position, t);
            gameobject.rotation = targetTransform.rotation;
            t += Time.deltaTime / animationDuration;
            yield return null;
        }

        RefreshResourseStack();
    }

    private IEnumerator GetElement(Transform gameobject, int index)
    {
        Vector3 originPosition = gameobject.position;

        float t = 0;

        float animationDuration = 1f;

        while (t < 1)
        {
            gameobject.position = Vector3.Lerp(originPosition, new Vector3(transform.position.x, transform.position.y + (index * 0.15f), transform.position.z), t);
            gameobject.rotation = transform.rotation;
            t += Time.deltaTime / animationDuration;
            yield return null;
        }

        RefreshResourseStack();
    }

    private void RefreshResourseStack()
    {
        for (int i = 0; i < ResoursesCount; i++)
        {
            _resourses[i].transform.position = new Vector3(transform.position.x, transform.position.y + (i * 0.15f), transform.position.z);
        }
    }
}
