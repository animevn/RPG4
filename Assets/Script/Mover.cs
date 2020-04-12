using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class Mover : MonoBehaviour{

        private void Update(){
            if (Input.GetMouseButton(0)){
                MoveToCursor();
            }
            UpdateAnimator();
        }

        private void MoveToCursor(){
            if (Camera.main == null) return;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hasHit = Physics.Raycast(ray, out var hit);
            if (hasHit){
                GetComponent<NavMeshAgent>().destination = hit.point;
            } 
            Debug.DrawRay(ray.origin, ray.direction * 1000);
        }

        private void UpdateAnimator(){
            var velocity = GetComponent<NavMeshAgent>().velocity;
            var localVelocity = transform.InverseTransformDirection(velocity);
            var speed = localVelocity.z;
            // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
            GetComponent<Animator>().SetFloat("forward", speed);
        }

    }
}