using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Events;
namespace Swatantra.Helpers
{
    public class TargetIndicatorScipt : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            EventManager.OnMoveTothisLocationEvent.AddListener(HandleMovetoThisLocationEvent);
        }

        private void HandleMovetoThisLocationEvent(Vector3 targetlocation)
        {
            transform.position = targetlocation;
        }
    }
}
