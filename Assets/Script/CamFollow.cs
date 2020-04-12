using UnityEngine;

namespace Script
{
    public class CamFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        
        private void LateUpdate(){
            transform.position = target.position;
        }
    }
}
