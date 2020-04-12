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
            print("Nothing to do");
        }

        private bool InteractWithCombat()
        {
            var hits = Physics.RaycastAll(GetMouseRay());
            foreach (var hit in hits)
            {
                var target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack();
                }
                return true;
            }

            return false;
        }

        private bool InteractWithMovement()
        {
            if (Camera.main == null) return false;
            var ray = GetMouseRay();
            var hasHit = Physics.Raycast(ray, out var hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().MoveTo(hit.point);
                }
//                Debug.DrawRay(ray.origin, ray.direction * 1000);
                return true;
            }

            return false;
        }

        private static Ray GetMouseRay()
        {
            // ReSharper disable once PossibleNullReferenceException
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}