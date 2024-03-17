using Assets.Scripts.CommonForUnits.Models;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Player.Models
{
    public class PlayerModel : UnitModel
    {
        public float Score;
        public List<GameObject> Weapons;
        public ReactiveProperty<GameObject> CurrentWeapon;
    }
}
