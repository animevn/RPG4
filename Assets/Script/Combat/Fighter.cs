using Script.Movement;
using UnityEngine;

namespace Script.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] private float weaponRange = 5f;
        private Transform _target;

        private void Update()
        {

            if (_target != null)    
            {
                var isInRange = Vector3.Distance(transform.position, _target.position) > weaponRange;
                if (isInRange)
                {
                    GetComponent<Mover>().MoveTo(_target.position);
                    print("start attack");
                }
                else
                {
                    GetComponent<Mover>().Stop();
                    _target = null;
                    print("Stop here");
                }
            }

        }

        public void Attack(CombatTarget combatTarget)
        {
            print("Attack you here");
            _target = combatTarget.transform;
        }
    }
}
