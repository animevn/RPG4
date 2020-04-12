using Script.Combat;
using Script.Movement;
using UnityEngine;

namespace Script.Controller
{
    
    public class PlayerController:MonoBehaviour
    {
        private void Update()
        {
            InteractWithCombat();
            InteractWithMovement();
        }

        private void InteractWithCombat()
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
            }
        }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            if (Camera.main == null) return;
            var ray = GetMouseRay();
            var hasHit = Physics.Raycast(ray, out var hit);
            if (hasHit){
                GetComponent<Mover>().MoveTo(hit.point);
            } 
//            Debug.DrawRay(ray.origin, ray.direction * 1000);
        }

        private static Ray GetMouseRay()
        {
            // ReSharper disable once PossibleNullReferenceException
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}