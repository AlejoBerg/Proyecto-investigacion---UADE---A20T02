using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class InteractiveMapCameraController : MonoBehaviour
{
    [SerializeField] private float _smoothZoom = 2f;
    [SerializeField] private Transform _cameraMainFocus;

    private float _initialFieldOfView = 0;
    private CinemachineVirtualCamera _vcam;

    private void Awake()
    {
        _vcam = this.GetComponent<CinemachineVirtualCamera>();
        _initialFieldOfView = _vcam.m_Lens.FieldOfView;
    }

    public void AssignNewFieldViewAndTarget(float newFieldOfView, Transform newLookAt, Transform newFollow)
    {
        StopAllCoroutines();
        _vcam.LookAt = newLookAt;
        _vcam.Follow = newFollow;
        StartCoroutine(ZoomLerp(newFieldOfView));
    }

    public void ResetCameraValues()
    {
        StopAllCoroutines();
        AssignNewFieldViewAndTarget(_initialFieldOfView, _cameraMainFocus, _cameraMainFocus);
    }

    IEnumerator ZoomLerp(float newFieldOfView)
    {
        while (Mathf.Abs(newFieldOfView - _vcam.m_Lens.FieldOfView) > 0.01f)
        {
            _vcam.m_Lens.FieldOfView = Mathf.Lerp(_vcam.m_Lens.FieldOfView, newFieldOfView, Time.deltaTime * _smoothZoom);
            yield return null;
        }

        _vcam.m_Lens.FieldOfView = newFieldOfView;
    }
}
