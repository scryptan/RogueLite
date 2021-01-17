using UnityEngine;

namespace RogueLike.Actor
{
    public interface IMover
    {
        void SetVelocityVector(Vector3 velocity);
        void Rotate(float angle);
        void SetRotation(Quaternion rotation);
    }
}