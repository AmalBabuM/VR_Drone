using DjiDrone;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(IP_Drone_Inputs))]
public class IP_Drone_Controller : IP_Base_RigidBody
{
    #region Variables
    [Header("Engine Properties")]
    [SerializeField] float minMaxPitch = 30f;
    [SerializeField] float minMaxRoll = 30f;
    [SerializeField] private float yawPower = 4f;
    [SerializeField] private float lerpSpeed = 2f;

    private IP_Drone_Inputs input;
    private List<IEngine> engines = new List<IEngine>();

    private float finalPitch;
    private float finalRoll;
    private float yaw;
    private float finalYaw;
    #endregion

    #region Main Method
    private void Start()
    {
        input = GetComponent<IP_Drone_Inputs>();
        engines=GetComponentsInChildren<IEngine>().ToList<IEngine>();
    }
    #endregion

    #region Custom method
    protected override void HandlePhysics()
    {
        HandleEngines();
        HandleControls();
    }

    protected virtual void HandleEngines()
    {
        /*rb.AddForce(Vector3.up*(rb.mass*Physics.gravity.magnitude));*/
        foreach(IEngine engine in engines)
        {
            engine.UpdateEngine(rb,input);
        }
    }
    protected virtual void HandleControls()
    {
        float pitch = input.Cyclic.y * minMaxPitch;
        float roll = -input.Cyclic.x * minMaxRoll;
        yaw += input.Pedals * yawPower;

        //Pitch --> Forward and backward X Axis
        //Yaw --> Rotation 360 Y Axis
        //Roll --> Forward and backward Z Axis
        finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
        finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
        finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);


        Quaternion rot = Quaternion.Euler(finalPitch, finalYaw, finalRoll);
        rb.MoveRotation(rot);
    }

    #endregion
}
