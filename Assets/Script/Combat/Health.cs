using UnityEngine;

namespace Script.Combat
{
    public class Health:MonoBehaviour
    {
        [SerializeField] private float health = 100f;

        public void TakeDamage(float damage)
        {
            health = Mathf.Max((health - damage), 0);
        }

        public float GetHealth()
        {
            return health;
        }
    }
}