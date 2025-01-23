using Assets.Scripts.Player.Models;
using System;
using UnityEngine;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerInteractController : MonoBehaviour
    {
        /*private PlayerModel playerModel;
        private PlayerPickupAbleController playerPickupAbleController;
        private PlayerClickableController playerClickableController;
        private PlayerInputController playerInputController;

        [SerializeField] private Camera _camera;
        [SerializeField] private float interactDistance = 3f;
        [SerializeField] private LayerMask interactableLayer;

        private void Awake()
        {
            playerModel = GetComponent<PlayerModel>();
            playerInputController = GetComponent<PlayerInputController>();
            playerPickupAbleController = new PlayerPickupAbleController(playerModel);
            playerClickableController = new PlayerClickableController();

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
        }*/
    }
}
