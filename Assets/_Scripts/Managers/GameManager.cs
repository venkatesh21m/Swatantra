using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra;

namespace Swatantra.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public bool SingleCharacterControl;
        public bool multiPlayerControl;

        private void Awake()
        {
            Instance = this;
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}