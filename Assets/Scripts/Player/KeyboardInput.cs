using RogueLike.Actor;
using UnityEngine;

namespace RogueLike.Player
{
    [RequireComponent(typeof(IMover))]
    [RequireComponent(typeof(IAttack))]
    public class KeyboardInput : MonoBehaviour
    {
        private IMover _playerMover;
        private IAttack _playerAttack;
        private Camera _playerCamera;
        private Plane _groundPlane =  new Plane(Vector3.up, Vector3.zero);
        private void OnEnable()
        {
            _playerMover = GetComponent<IMover>();
            _playerAttack = GetComponent<IAttack>();
            _playerCamera = Camera.main;
        }

        private void Update()
        {
            Move();
            Look();
            if (Input.GetMouseButtonDown(0))
            {
                _playerAttack.Attack();
            }
        }

        private void Move()
        {
            var dir = new Vector3();

            if (Input.GetKey(KeyCode.W))
                dir.z = 1;
            if (Input.GetKey(KeyCode.A))
                dir.x = -1;
            if (Input.GetKey(KeyCode.S))
                dir.z = -1;
            if (Input.GetKey(KeyCode.D))
                dir.x = 1;

            _playerMover.SetVelocityVector(dir);
        }

        private void Look()
        {
            var cameraRay = _playerCamera.ScreenPointToRay(Input.mousePosition);
            if (_groundPlane.Raycast(cameraRay, out var rayLength))
            {
                var pointToLook = cameraRay.GetPoint(rayLength);
                _playerMover.Rotate(Utils.GetAngleBetweenVectors(pointToLook, transform.position));
            }
        }
    }
}