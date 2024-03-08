using Assets.Scripts.Abstracts.Models;
using Assets.Scripts.Abstracts.Views;
using UnityEngine;

namespace Assets.Scripts.Abstracts.Controllers
{
    public abstract class MovementController : MonoBehaviour
    {
        protected UnitModel unitModel;
        protected UnitView unitView;

        public abstract void Move();

        protected virtual void Awake()
        {
            unitModel = GetComponent<UnitModel>();
            unitView = GetComponent<UnitView>();
        }

        void FixedUpdate()
        {
            Move();
        }
    }
}
