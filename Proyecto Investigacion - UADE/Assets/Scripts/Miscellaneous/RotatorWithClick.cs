using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorWithClick : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 20;

    [SerializeField] private float _minClampX = -60;
    [SerializeField] private float _maxClampX = 60;
    [SerializeField] private float _minClampY = -60;
    [SerializeField] private float _maxClampY = 60;

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * Time.deltaTime *_rotationSpeed;
        float rotY = Input.GetAxis("Mouse Y") * Time.deltaTime * _rotationSpeed;

        Vector3 rot = transform.rotation.eulerAngles + new Vector3(rotY, -rotX, 0f); //use local if your char is not always oriented Vector3.up
        rot.x = ClampAngle(rot.x, _minClampX, _maxClampX);
        rot.y = ClampAngle(rot.y, _minClampY, _maxClampY);

        transform.eulerAngles = rot;
    }

    float ClampAngle(float angle, float from, float to)
    {
        // accepts e.g. -80, 80
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }
}
