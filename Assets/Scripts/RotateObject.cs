using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime * _speed);
    }
}
