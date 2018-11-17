using Shields;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI
{
    [System.Serializable]
    public class ShieldRetractEvent : UnityEvent<bool> { }
    
    [System.Serializable]
    public class ShieldExtendEvent : UnityEvent<bool> { }
    
    public class SpecialInput : MonoBehaviour, IPointerDownHandler
    {
        public ShieldManager m_shieldManager;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            
        }
    }
}

