using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerInteractController : MonoBehaviour
    {
        private PlayerPickupAbleController playerPickupAbleController;
        private PlayerClickableController playerClickableController;
        private PlayerInputController playerInputController;
        private Camera _camera;

        [SerializeField] private float interactDistance = 3f;
        [SerializeField] private LayerMask interactableLayer;

        [Inject]
        private void Construct(PlayerInputController playerInputController, Camera camera, PlayerPickupAbleController playerPickupAbleController, PlayerClickableController playerClickableController)
        {
            this.playerPickupAbleController = playerPickupAbleController;
            this.playerClickableController = playerClickableController;
            this.playerInputController = playerInputController;
            this._camera = camera;
        }

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
                playerPickupAbleController.TryPickup(interactedObject);
                playerClickableController.TryPressButton(interactedObject);
            }
        }
    }
}
