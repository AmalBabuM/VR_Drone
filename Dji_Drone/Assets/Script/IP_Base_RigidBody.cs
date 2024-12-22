using UnityEngine;

namespace DjiDrone
{
    [RequireComponent(typeof(Rigidbody))]
    public class IP_Base_RigidBody : MonoBehaviour
    {
        #region Variables
        [Header("RigidBody Properties")]
        [SerializeField] private float weightInLbs = 1f;

        const float lbsToKg = 0.454f;

        protected Rigidbody rb;

        protected float starDrag;
        protected float starAngularDrag;
        #endregion

        #region Main Method
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if (rb)
            {
                rb.mass=weightInLbs* lbsToKg;
                starDrag = rb.linearDamping;
                starAngularDrag = rb.angularDamping;
            }
        }
        private void FixedUpdate()
        {
            if (!rb)
            {

                return;
            }
            HandlePhysics();

        }
        #endregion

        #region Custom Methods
        protected virtual void HandlePhysics()
        {

        }

        #endregion
    }

}
