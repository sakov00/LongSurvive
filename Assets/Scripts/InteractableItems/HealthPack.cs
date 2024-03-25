using Assets.Scripts.Interfaces;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.InteractableItems
{
    public class HealthPack : MonoBehaviour, IPickupable
    {
        [field: SerializeField] public int HealthPoints { get; private set; }

        public void Pickup()
        {
            Destroy(gameObject);
        }
    }
}
