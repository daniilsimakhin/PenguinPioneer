using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerping : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset = new Vector3(-10.5f, 18, -22.25f);
    [SerializeField] private float _speed;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _player.transform.position + _offset, Time.deltaTime * _speed);
    }
}
