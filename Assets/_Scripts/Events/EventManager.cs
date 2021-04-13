using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Swatantra.Events
{
    /// <summary>
    /// EventManager is the store house of events
    /// </summary>
    public static class EventManager 
    {
        public static Events.OnMouseClickEvent OnMoveTothisLocationEvent = new Events.OnMouseClickEvent();
        public static Events.OnBoolEvent OnSingleCharacterController = new Events.OnBoolEvent();
        public static Events.OnBoolEvent OnMultiCharacterController = new Events.OnBoolEvent();
    }

}
