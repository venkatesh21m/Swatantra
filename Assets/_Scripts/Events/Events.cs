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
        [System.Serializable] public class Vector3Event : UnityEvent<Vector3> { };
        [System.Serializable] public class TranformEvent : UnityEvent<Vector3> { };

        /// <summary>
        /// Event for handling all events which passes a boolean
        /// </summary>
        [System.Serializable] public class BooleanEvent:UnityEvent<bool> { };
        [System.Serializable] public class TriggerEvent:UnityEvent { };

        /// <summary>
        /// Event for handling all events which passes a Integer
        /// </summary>
        [System.Serializable] public class IntEvent : UnityEvent<int> { };

        /// <summary>
        /// event for handing all events which passes Characterstats_SO 
        /// </summary>
        [System.Serializable] public class CharacterStatsEvent : UnityEvent<Stats.characterStats.CharacterStats_SO> { };
        [System.Serializable] public class CurrentCharacterEvent : UnityEvent<MovementSystems.Movement> { };

    }
}
