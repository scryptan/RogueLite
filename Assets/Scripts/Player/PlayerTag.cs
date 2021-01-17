using RogueLike.Actor;
using UnityEngine;

namespace RogueLike.Player
{
    [RequireComponent(typeof(TransformMover))]
    [RequireComponent(typeof(IAttack))]
    public class PlayerTag : MonoBehaviour, IDamageable
    {
        public void GetDamage()
        {
        }
    }
}