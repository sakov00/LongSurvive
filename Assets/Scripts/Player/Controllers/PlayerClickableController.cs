using Assets.Scripts.Interfaces;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerClickableController
    {
        public void TryPressButton(GameObject interactedObject)
        {
            var clickableObject = interactedObject.GetComponent<IClickable>();
            if (clickableObject != null)
            {
                clickableObject.Click();
            }
        }
    }
}
