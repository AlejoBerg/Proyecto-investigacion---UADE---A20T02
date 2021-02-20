using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    [SerializeField] private float _skyboxRotSpeed = 5f;
    [SerializeField] private float _skyboxExposureSpeed = 5f;
    [SerializeField] private float _skyboxMaxExposure = 0.4f;

    void Start()
    {

    }

    void LateUpdate()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * _skyboxRotSpeed);

        float lerp = Mathf.PingPong(Time.time / _skyboxExposureSpeed, _skyboxMaxExposure);
        print(lerp);
        RenderSettings.skybox.SetFloat("_Exposure", lerp);
        //_skybox.material.SetFloat("_Rotation", Time.time * _skyboxRotSpeed);
    }
}
