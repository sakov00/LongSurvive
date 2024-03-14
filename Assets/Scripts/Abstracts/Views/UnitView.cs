﻿using Assets.Scripts.Abstracts.Models;
using UnityEngine;

namespace Assets.Scripts.Abstracts.Views
{
    public abstract class UnitView : MonoBehaviour
    {
        protected UnitModel unitModel;
        protected CharacterController characterController;

        private void Awake()
        {
            unitModel = GetComponent<UnitModel>();
            characterController = GetComponent<CharacterController>();
        }

        public void Move(Vector3 movement)
        {
            characterController.Move(movement);
        }

        public void LookAt(Transform transform)
        {
            this.transform.LookAt(transform);
        }
    }
}
