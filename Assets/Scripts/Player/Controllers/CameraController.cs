using Assets.Scripts.Player.Views;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float sensitivity = 15.0f;

        [SerializeField] private float minimumVert = -80.0f;
        [SerializeField] private float maximumVert = 80.0f;

        [Inject] private PlayerView playerView;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void FixedUpdate()
        {
            var mouseX = Input.GetAxis("Mouse X") * sensitivity;
            var mouseY = Input.GetAxis("Mouse Y") * sensitivity;


            var rotationX = transform.localEulerAngles.x - mouseY;
            var rotationY = transform.localEulerAngles.y + mouseX;

            if (rotationX > 180)
                rotationX -= 360;
            else if(rotationX < -180)
                rotationX += 360;

            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);
            transform.localEulerAngles = new Vector3(rotationX, 0, 0);
            playerView.Rotation(new Vector3(0, rotationY, 0));
        }
    }
}
