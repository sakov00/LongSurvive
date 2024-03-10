using Assets.Scripts.Interfaces;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerInteractController : MonoBehaviour
    {
        [SerializeField] private float interactDistance = 3f;
        [SerializeField] private LayerMask interactableLayer;

        [Inject] private PlayerInputController playerInputController;
        [Inject] private Camera _camera;

        public event Action<IPickupable> OnObjectPickuped;
        public event Action<IButton> OnButtonPressed;

        private void Awake()
        {
            playerInputController.OnInteractEvent += Interact;
        }

        private void Interact()
        {
            RaycastHit hit;
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit, interactDistance, interactableLayer))
            {
                GameObject interactedObject = hit.collider.gameObject;
                TryPickup(interactedObject);
                TryPressButton(interactedObject);
            }
        }

        private void TryPickup(GameObject interactedObject)
        {
            IPickupable pickupable = interactedObject.GetComponent<IPickupable>();
            if (pickupable != null)
            {
                pickupable.Pickup();
                OnObjectPickuped?.Invoke(pickupable);
            }
        }

        private void TryPressButton(GameObject interactedObject)
        {
            IButton button = interactedObject.GetComponent<IButton>();
            if (button != null)
            {
                button.Press();
                OnButtonPressed?.Invoke(button);
            }
        }
    }
}
