using UnityEngine;

namespace Assets.Scripts.Weapons.Models
{
    public class ShotgunModel : DistanceWeaponModel
    {
        [field: SerializeField] public int CountBullets { get; set; }

        [field: SerializeField] public int RadiusShooting { get; set; }
    }
}
