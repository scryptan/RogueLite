using RogueLike.Actor;
using UnityEngine;

namespace RogueLike.Player
{
    public class PlayerPistolAttack : MonoBehaviour, IAttack
    {
        public void Attack()
        {
            Debug.Log("attacked");
        }
    }
}