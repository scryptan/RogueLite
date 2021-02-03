using RogueLike.Actor;
using UnityEngine;

namespace RogueLike.Enemy
{
    public class EnemyTag : MonoBehaviour
    {
        private INotifiable _notifiable;

        public void Init(INotifiable notifiable)
        {
            _notifiable = notifiable;
        }
    }
}