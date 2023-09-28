using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera Camera;
    public CinemachineVirtualCamera CmVirtualCamera;
    public CinemachineVirtualCamera CmVirtualUpgradeCamera;
    public CinemachineVirtualCamera flyCam;
    public CinemachineVirtualCamera finishCam;
    private float shakeTimer = 0;
    private CinemachineBasicMultiChannelPerlin perlin;

    private void Start()
    {
        perlin = CmVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        perlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            if (shakeTimer <= 0)
            {
                perlin.m_AmplitudeGain = 0;
            }
        }
    }

    public void SetUpgradeCamera(int value)
    {
        switch (value)
        {
            case 0:
                CmVirtualUpgradeCamera.Priority = 5;
                flyCam.Priority = 5;
                finishCam.Priority = 5;
                perlin = CmVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                break;
            case 1:
                CmVirtualUpgradeCamera.Priority = 20;
                flyCam.Priority = 5;
                perlin = CmVirtualUpgradeCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                break;
            case 2:
                flyCam.Priority = 20;
                perlin = flyCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                CmVirtualUpgradeCamera.Priority = 5;
                break;
            case 3:
                finishCam.Priority = 20;
                flyCam.Priority = 5;
                perlin = finishCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                CmVirtualUpgradeCamera.Priority = 5;
                break;
        }
    }

    private Tween fovTween;

    public void SetCameraDistance(float _fov)
    {
        var fov = CmVirtualCamera.m_Lens.FieldOfView;
        fovTween?.Kill();
        fovTween = DOTween.To(() => fov, x => fov = x, _fov, 0.2f).OnUpdate(() =>
        {
            CmVirtualCamera.m_Lens.FieldOfView = fov;
            flyCam.m_Lens.FieldOfView = fov;
        }).OnComplete(() =>
        {
            CmVirtualCamera.m_Lens.FieldOfView = _fov;
            flyCam.m_Lens.FieldOfView = _fov;
        });
    }

    public void CameraSetFree()
    {
        flyCam.Follow = null;
        flyCam.m_Follow = null;
        flyCam.LookAt = null;
        flyCam.m_LookAt = null;
    }
}