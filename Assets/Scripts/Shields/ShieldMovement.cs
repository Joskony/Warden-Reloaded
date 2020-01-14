using Lean.Touch;
using UnityEngine;

namespace Shields
{
    public class ShieldMovement : LeanSwipeBase
    {
        public LeanFingerFilter Use = new LeanFingerFilter(true);

        public Vector3 Axis = Vector3.down;

        public Space Space = Space.Self;
        
        protected virtual void Awake()
        {
            Use.UpdateRequiredSelectable(gameObject);
        }
        
        protected virtual void Update()
        {
            // Get the fingers we want to use
            var fingers = Use.GetFingers();

            // Calculate the rotation values based on these fingers
            var twistDegrees = LeanGesture.GetTwistDegrees(fingers);

            // Perform rotation
            transform.Rotate(Axis, twistDegrees, Space);
        }
    }
}