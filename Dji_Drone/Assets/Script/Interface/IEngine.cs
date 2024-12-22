using UnityEngine;

namespace DjiDrone
{
    public interface IEngine
    {
        void InitEngine();
        void UpdateEngine(Rigidbody rb, IP_Drone_Inputs input);
    }

}
