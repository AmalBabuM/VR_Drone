using UnityEngine;

namespace DjiDrone
{
    [RequireComponent(typeof(BoxCollider))]
    public class IP_Drone_Engine : MonoBehaviour, IEngine
    {
        #region Variables
        [Header("Engine properties")]
        [SerializeField]float maxPower = 4f;
        #endregion
        #region Interface methods
        public void InitEngine()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEngine(Rigidbody rb, IP_Drone_Inputs input)
        {
            Vector3 engineForce = Vector3.zero;
            engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude) + (input.Throttle * maxPower)) / 4f;

            rb.AddForce(engineForce,ForceMode.Force);
        }
        #endregion
    }

}
