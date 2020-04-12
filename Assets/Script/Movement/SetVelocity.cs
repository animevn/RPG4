using UnityEngine;
using UnityEngine.AI;

namespace Script.Movement
{
    public class SetVelocity : MonoBehaviour
    {

        private void Update()
        {
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            var velocity = GetComponent<NavMeshAgent>().velocity;
            var localVelocity = transform.InverseTransformDirection(velocity);
            var speed = localVelocity.z;
            // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
            GetComponent<Animator>().SetFloat("forward", speed);
        }

    }
}