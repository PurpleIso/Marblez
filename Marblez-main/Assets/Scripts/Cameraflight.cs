using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camflight : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float normalSpeed = 20f;
    [SerializeField] private float speedySpeed = 40f;
    [SerializeField] private float verticalSpeed = 10f;

    [SerializeField] private float lookSensitivity = 0.5f;
    [SerializeField] private bool invertY = false;


    [SerializeField] private Vector2 moveInput;
    [SerializeField] private Vector2 LookInput;
    [SerializeField] private bool SpeedInput;
    [SerializeField] private bool HoldonLeftClickInput;

    private Vector3 verticalMovement = Vector3.zero;


    private float cameraPitch = 0f;

    private Camera FreeCam;
    private CamFlight inputActions;

    private void Awake()
    {
        FreeCam = Camera.main;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnEnable()
    {
        inputActions = new CamFlight();
        inputActions.Enable();

        inputActions.CameraMovement.Smoving.performed += OnMove;
        inputActions.CameraMovement.Smoving.canceled += OnMove;

        inputActions.CameraMovement.Look.performed += OnLook;
        inputActions.CameraMovement.Look.canceled += OnLook;

        inputActions.CameraMovement.MoveUp.performed += OnMoveUp;
        inputActions.CameraMovement.MoveUp.canceled += OnMoveUp;

        inputActions.CameraMovement.MoveDown.performed += OnMoveDown;
        inputActions.CameraMovement.MoveDown.canceled += OnMoveDown;

        inputActions.CameraMovement.Speed.performed += OnSpeed;
        inputActions.CameraMovement.Speed.canceled += OnSpeed;

        inputActions.CameraMovement.HoldonLeftClick.performed += OnHoldonLeftClick;
        inputActions.CameraMovement.HoldonLeftClick.canceled += OnHoldonLeftClick;
    }

    private void OnDisable()
    {

        if (inputActions != null)
        {
            inputActions.CameraMovement.Smoving.performed -= OnMove;
            inputActions.CameraMovement.Smoving.canceled -= OnMove;

            inputActions.CameraMovement.Look.performed -= OnLook;
            inputActions.CameraMovement.Look.canceled -= OnLook;

            inputActions.CameraMovement.MoveUp.performed -= OnMoveUp;
            inputActions.CameraMovement.MoveUp.canceled -= OnMoveUp;

            inputActions.CameraMovement.MoveDown.performed -= OnMoveDown;
            inputActions.CameraMovement.MoveDown.canceled -= OnMoveDown;

            inputActions.CameraMovement.Speed.performed -= OnSpeed;
            inputActions.CameraMovement.Speed.canceled -= OnSpeed;

            inputActions.CameraMovement.HoldonLeftClick.performed -= OnHoldonLeftClick;
            inputActions.CameraMovement.HoldonLeftClick.canceled -= OnHoldonLeftClick;

            inputActions.Disable();
            inputActions.Dispose();
        }
    }


    public void OnMove(InputAction.CallbackContext context) => moveInput = context.ReadValue<Vector2>();
    public void OnLook(InputAction.CallbackContext context) => LookInput = context.ReadValue<Vector2>();
    public void OnMoveUp(InputAction.CallbackContext context) => verticalMovement = context.performed ? Vector3.up : Vector3.zero;
    public void OnMoveDown(InputAction.CallbackContext context) => verticalMovement = context.performed ? Vector3.down : Vector3.zero;
    public void OnSpeed(InputAction.CallbackContext context) => SpeedInput = context.performed;
    public void OnHoldonLeftClick(InputAction.CallbackContext context) => HoldonLeftClickInput = context.performed;


    private void Update()
    {
        if (HoldonLeftClickInput)
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            LookAround();
        }
        else
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            LookInput = Vector2.zero;
        }

        MoveCamera();
    }

    void MoveCamera()
    {
        float speed = SpeedInput ? speedySpeed : normalSpeed;

        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y);

        Vector3 worldDirection = transform.TransformDirection(direction);

        worldDirection += verticalMovement;


        transform.position += worldDirection * speed * Time.deltaTime;
    }

    void LookAround()
    {
        float mouseX = LookInput.x * lookSensitivity;
        float mouseY = LookInput.y * lookSensitivity * (invertY ? 1f : -1f);


        transform.Rotate(Vector3.up * mouseX);

        cameraPitch += mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

        if (FreeCam != null)
        {

            FreeCam.transform.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);
        }
    }
}
