using UnityEngine;

namespace RogueLike
{
    public static class Utils
    {
        public static Vector3 GetVectorFromAngle(float angle)
        {
            var rad = angle * (Mathf.PI / 180);
            return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
        }

        public static float GetAngleBetweenVectors(Vector3 from, Vector3 to)
        {
            var dir = from - to;
            return Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        }
    }
}