using UnityEngine;
using UnityEngine.InputSystem;

namespace DjiDrone
{
    [RequireComponent(typeof(PlayerInput))]
    public class IP_Drone_Inputs : MonoBehaviour
    {
        #region Variables
        Vector2 cyclic;
        float pedals;
        float throttle;


        public Vector2 Cyclic { get => cyclic; }
        public float Pedals { get => pedals; }
        public float Throttle { get => throttle; }

        #endregion

        #region Main Method
        private void Update()
        {

        }
        #endregion

        #region Input Methods

        void OnCyclic(InputValue value)
        {
            Debug.Log("Cycle");
            cyclic = value.Get<Vector2>();
        }

        void OnPedals(InputValue value)
        {
            Debug.Log("Pedal");
            pedals = value.Get<float>();
        }
        void OnThrottle(InputValue value)
        {
            Debug.Log("Throttle");
            throttle= value.Get<float>();
        }
        #endregion
    }

}
