using Assets.Scripts.Abstracts.Models;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Player.Models
{
    public class PlayerModel : UnitModel
    {
        public float Score { get; set; }
        [field: SerializeField] public List<GameObject> Weapons { get; set; }
        [field: SerializeField] public ReactiveProperty<GameObject> CurrentWeapon { get; set; }
    }
}
