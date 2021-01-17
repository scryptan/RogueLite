using UnityEngine;

namespace RogueLike.Actor
{
    public class TransformMover : MonoBehaviour, IMover
    {
        [SerializeField] private float speed = 5;

        public void SetVelocityVector(Vector3 velocity)
        {
            transform.position += velocity * (speed * Time.deltaTime);
        }

        public void Rotate(float angle)
        {
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        public void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
    }
}