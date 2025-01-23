using System;
using UnityEngine;
using Voody.UniLeo.Lite;

namespace _Project.Scripts.Components
{
    public class CameraProvider : MonoProvider<CameraComponent>
    {
        private void Awake()
        {
            value.sensitivity = 200f;
            value.minimumVert = -80f;
            value.maximumVert = 80f;
        }
    }
    
    [Serializable]
    public struct CameraComponent
    {
        [SerializeField] public float sensitivity;
        [SerializeField] public float minimumVert;
        [SerializeField] public float maximumVert;
        [SerializeField] public Transform cameraTransform;
    }
}