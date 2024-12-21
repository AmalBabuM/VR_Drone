using UnityEngine;

namespace DjiDrone
{
    public class IP_Drone_Inputs : MonoBehaviour
    {
        #region Variables
        Vector2 cyclic;
        float pedals;
        float throttle;

        public Vector2 Cyclic { get => cyclic;}
        public float Pedals { get => pedals;}
        public float Throttle { get => throttle;}

        #endregion
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
