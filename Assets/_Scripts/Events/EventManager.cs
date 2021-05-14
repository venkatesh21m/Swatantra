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
        public static Events.Vector3Event OnMoveTothisLocationEvent = new Events.Vector3Event();


        #region character stats related events
        
        /// <summary>
        /// this event is for when mouse is hovered on character
        /// </summary>
        public static Events.CharacterStatsEvent OnHoverOnCharacterEvent = new Events.CharacterStatsEvent();
        public static Events.TriggerEvent onHoverExitOnCharacterEvent = new Events.TriggerEvent();
        
        #endregion

        #region Character control mode related events

        /// <summary>
        /// To Broadcast Single character Mode selection 
        /// </summary>
        public static Events.TriggerEvent OnSingleCharacterController = new Events.TriggerEvent();

        /// <summary>
        /// To broadcast Multi character mode selection
        /// </summary>
        public static Events.TriggerEvent OnMultiCharacterController = new Events.TriggerEvent();

        #endregion


        public static Events.CurrentCharacterEvent OnCurrentCharacterSelection = new Events.CurrentCharacterEvent();
    }

}
