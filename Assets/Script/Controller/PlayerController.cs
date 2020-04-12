using Script.Combat;
using Script.Movement;
using UnityEngine;

namespace Script.Controller
{
    
    public class PlayerController:MonoBehaviour
    {
        private void Update()
        {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
//            print("Nothing more");
        }

        private bool InteractWithCombat()
        {
            // ReSharper disable once Unity.PreferNonAllocApi
            var ray = GetMouseRay();
            // ReSharper disable once Unity.PreferNonAllocApi
            var hits = Physics.RaycastAll(ray);
            foreach (var hit in hits)
            {
                var target = hit.transform.GetComponent<CombatTarget>();
                Debug.DrawRay(ray.origin, ray.direction * 1000);
                if (target == null) continue;
//                print("right target");
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
//                    print("combat returns true");
                    Debug.DrawRay(ray.origin, ray.direction * 1000);
                }
                return true;
            }
//            print("combat returns false");
            return false;
        }

        private bool InteractWithMovement()
        {
            var ray = GetMouseRay();
            var hasHit = Physics.Raycast(ray, out var hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartToMoveTo(hit.point);
                }
                Debug.DrawRay(ray.origin, ray.direction * 1000);
                return true;
            }
            return false;
        }

        private Ray GetMouseRay()
        {
            // ReSharper disable once PossibleNullReferenceException
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}