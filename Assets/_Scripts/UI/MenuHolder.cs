using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Events;


namespace Swatantra.UI
{
    public class MenuHolder : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnBuildingButtonPresased(int buildingnumber)
        {
            EventManager.BuildingButtonPressedEvent.Invoke(buildingnumber);
        }
    }
}
