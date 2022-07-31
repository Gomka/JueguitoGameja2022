using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobaloRotate : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;
    // Update is called once per frame
    void Update()
    {
        float randomnuber = Random.Range(0, 4);
        _speed = Random.Range(30,120);
        switch (randomnuber)
        {
            case 0:
                _rotation = Vector3.up;
                break;
            case 1:
                _rotation = Vector3.down;
                break;
            case 2:
                _rotation = Vector3.left;
                break;
            case 3:
                _rotation = Vector3.right;
                break;
        }
        transform.Rotate(_rotation * _speed * Time.deltaTime);
    }
}
