﻿using Script.Movement;
using UnityEngine;

namespace Script.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] private float weaponRange = 5f;
        // ReSharper disable once InconsistentNaming
        private Transform target;


        private void Update()
        {
            if (target == null) return;
            var isInRange = Vector3.Distance(transform.position, target.position) > weaponRange;
            if (isInRange)
            {
                GetComponent<Mover>().MoveTo(target.position);
//                    print("start attack");
            }
            else
            {
                GetComponent<Mover>().Stop();
//                    print("Stop here");
            }

        }
        
        public void Attack(CombatTarget combatTarget)
        {
//            print("Attack you here");
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }
}
