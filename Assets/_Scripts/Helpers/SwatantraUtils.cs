using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Swatantra.Helpers
{
    public class SwatantraUtils
    {
       public static Vector3 GetMouseWorldPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
                return raycastHit.point;
            else
                return Vector3.zero;
        }
    }
}
