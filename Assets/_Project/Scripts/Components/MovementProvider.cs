using System;
using UnityEngine;
using UnityEngine.Serialization;
using Voody.UniLeo.Lite;

namespace _Project.Scripts.Components
{
    public class MovementProvider : MonoProvider<MovementComponent>
    {
    }
    
    [Serializable]
    public struct MovementComponent
    {
        public CharacterController characterController;
        
        public Vector3 velocity;
        
        public Transform transform;
        public float movementSpeed;
        public float jumpHeight;

        public float gravity;
        public bool isGrounded;
        public Transform groundCheck;
        public float groundDistance;
        public LayerMask groundMask;
    }
}