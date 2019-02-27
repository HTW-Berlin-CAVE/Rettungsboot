using UnityEngine;
using Htw.Cave.Joycon;
using JoyconLib;

[RequireComponent(typeof(Rigidbody))]
public class CustomControls : MonoBehaviour
{
    [Header("Input Types")]
    [Tooltip("Enables the classic input way with WASD")]
    public bool enableMouseAndKeyboard = false;

    public AI_control aicontrol;
    [SerializeField]
    [Tooltip("Animator component")]
    private Animator game;


    private Vector3 controls;
    private Rigidbody body;

    #region Movementfactors
    private float lateralAcceleration;
    private float angularAcceleration;
    private float verticalAcceleration;

    private float lateralForce = 50;
    private float verticalForce = 10;
    private float angularForce = 10;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.steer)
        {
            angularAcceleration = 0.95f * angularAcceleration + 0.05f * controls.x;
            verticalAcceleration = 0.9f * verticalAcceleration + 0.1f * controls.y;
            lateralAcceleration = 0.9f * lateralAcceleration + 0.1f * controls.z;

            body.AddRelativeForce(Vector3.forward * lateralAcceleration * lateralForce);
            body.AddRelativeForce(Vector3.up * verticalAcceleration * verticalForce);
            body.AddRelativeTorque(Vector3.up * angularAcceleration * angularForce);

            //Autoupright ... submarine stays upright and dont rotate on the z and x 
            body.AddForceAtPosition(Vector3.up * 100, transform.TransformPoint(Vector3.up * 10));
            body.AddForceAtPosition(Vector3.down * 100, transform.TransformPoint(Vector3.down * 10));
        }

        if (enableMouseAndKeyboard)
        {
            MouseAndKeyboardMovement();
        }

        if (JoyconHelper.GetJoyconsCount() > 0)
        {
            JoyconControlls();
        }
    }

    private void MouseAndKeyboardMovement()
    {
        if (!game.GetBool("autopilot"))
        {
            controls = Vector3.zero;
            if (UnityEngine.Input.GetKey(KeyCode.A)) controls += Vector3.left;
            if (UnityEngine.Input.GetKey(KeyCode.D)) controls += Vector3.right;
            if (UnityEngine.Input.GetKey(KeyCode.W)) controls += Vector3.forward;
            if (UnityEngine.Input.GetKey(KeyCode.S)) controls += Vector3.back;
            if (UnityEngine.Input.GetKey(KeyCode.Q)) controls += Vector3.up;
            if (UnityEngine.Input.GetKey(KeyCode.E)) controls += Vector3.down;
        }
        else
        {
            controls = aicontrol.controls;
            Debug.Log(controls.ToString("f4"));
        }
    }

    private void JoyconControlls()
    {
        float[] move = JoyconHelper.GetLeftJoycon().GetStick();
        float[] rotate = JoyconHelper.GetRightJoycon().GetStick();

        if (JoyconHelper.GetLeftJoycon().GetButton(Joycon.Button.SHOULDER_2))
        {
            controls += Vector3.down;
        }

        if (JoyconHelper.GetRightJoycon().GetButton(Joycon.Button.SHOULDER_2))
        {
            controls += Vector3.up;
        }

        if (move[1] < 0)
        {
            controls += Vector3.back;
        }

        if (move[1] > 0)
        {
            controls += Vector3.forward;
        }

        if (rotate[0] < 0)
        {
            controls += Vector3.left;
        }

        if (rotate[0] > 0)
        {
            controls += Vector3.right;
        }
    }

    public float returnMagnitude()
    {
        return controls.magnitude;
    }

}
