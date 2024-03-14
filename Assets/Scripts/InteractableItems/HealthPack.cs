using Assets.Scripts.Interfaces;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.InteractableItems
{
    public class HealthPack : MonoBehaviour, IPickupable
    {
        [SerializeField] public float HealthPoints = 10f;

        public void Pickup()
        {
        }
    }
}
