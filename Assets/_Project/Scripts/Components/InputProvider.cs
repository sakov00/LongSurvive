using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Voody.UniLeo.Lite;

namespace _Project.Scripts.Components
{
    public class InputProvider : MonoProvider<InputComponent>
    {
        private void Awake()
        {
            
        }
    }
    
    [Serializable]
    public struct InputComponent
    {
        public Vector3 movementInput;
    }
}