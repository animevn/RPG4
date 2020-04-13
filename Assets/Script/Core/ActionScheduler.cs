using UnityEngine;

namespace Script.Core
{
    public class ActionScheduler:MonoBehaviour
    {
        private MonoBehaviour currentAction;
        
        public void StartAction(MonoBehaviour action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                print("Cancel Action: " + currentAction.GetType().Name);
            }
            
            currentAction = action;
        }
    }
}