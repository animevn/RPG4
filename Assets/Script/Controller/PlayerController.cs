using UnityEngine;
using UnityEngine.AI;

namespace Script.Controller
{
    
    public class PlayerController:MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButton(0)){
                MoveToCursor();
            }
        }
        
        private void MoveToCursor()
        {
            if (Camera.main == null) return;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hasHit = Physics.Raycast(ray, out var hit);
            if (hasHit){
                GetComponent<NavMeshAgent>().destination = hit.point;
            } 
//            Debug.DrawRay(ray.origin, ray.direction * 1000);
        }
    }
}