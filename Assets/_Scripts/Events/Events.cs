using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Swatantra.Events
{
    /// <summary>
    /// class to hold all the events of the game
    /// </summary>
    public static class Events 
    {

        /// <summary>
        /// event for the mouseclick event which passes a vector3
        /// </summary>
        [System.Serializable] public class OnMouseClickEvent : UnityEvent<Vector3> { };

        /// <summary>
        /// Event for handling all events which passes a boolean
        /// </summary>
        [System.Serializable] public class OnBoolEvent:UnityEvent<bool> { };

    }
}
