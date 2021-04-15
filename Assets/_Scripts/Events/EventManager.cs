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
        /// <summary>
        /// To handle click to move interation
        /// </summary>
        public static Events.OnMouseClickEvent OnMoveTothisLocationEvent = new Events.OnMouseClickEvent();
        
        /// <summary>
        /// To Broadcast Single character Mode selection 
        /// </summary>
        public static Events.OnBoolEvent OnSingleCharacterController = new Events.OnBoolEvent();

        /// <summary>
        /// To broadcast Multi character mode selection
        /// </summary>
        public static Events.OnBoolEvent OnMultiCharacterController = new Events.OnBoolEvent();
    }

}
