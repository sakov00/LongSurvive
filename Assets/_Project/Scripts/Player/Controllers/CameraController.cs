using UnityEngine;

namespace Assets.Scripts.Player.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float sensitivity = 10.0f;

        [SerializeField] private float minimumVert = -80.0f;
        [SerializeField] private float maximumVert = 80.0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            var mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            var rotationX = transform.localEulerAngles.x - mouseY;
            var rotationY = transform.localEulerAngles.y + mouseX;

            if (rotationX > 180)
                rotationX -= 360;
            else if (rotationX < -180)
                rotationX += 360;

            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);
            transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.parent.Rotate(Vector3.up * rotationY);
        }
    }
}
