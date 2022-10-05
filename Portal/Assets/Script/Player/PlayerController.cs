using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Protal;

public class PlayerController : MonoBehaviour
{
    public GunTransform RunGunPostion;
    public GunTransform ShootGunPostion;

    public static PlayerController Instance;

    #region Input For Character Controller
    [Header("Movement")]
    [SerializeField]private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    //mouse
    [Header("Mouse")]
    [SerializeField] private float sensitivityX;
    [SerializeField] private float sensitivityY;
    [SerializeField] private float minimumY;
    [SerializeField] private float maximumY;
    #endregion


    [HideInInspector]public Vector2 IHorizontalMovement;
    [HideInInspector]public bool IJump;

    [HideInInspector] public float IMouseX ;
    [HideInInspector] public float IMouseY ;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        LookFunction();

        Movement();
    }

    Vector3 TempMovement;
    Vector3 VecticalMovement = Vector3.zero; //Manaual gravity
    private bool groundedPlayer;
    float rotationY = 0F;
    private float xRotation;
    private float yRotation;

    private void Movement()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            VecticalMovement.y = 0;
        }
        //movement
        TempMovement = (transform.right * IHorizontalMovement.x + transform.forward * IHorizontalMovement.y) * playerSpeed;
        controller.Move(TempMovement*Time.deltaTime);

        if(IJump && groundedPlayer) 
        {
            VecticalMovement.y = Mathf.Sqrt(-2f * jumpHeight * gravityValue);
            IJump = false;
        }
        //gravity
        VecticalMovement.y += gravityValue * Time.deltaTime; 
        controller.Move(VecticalMovement * Time.deltaTime);
    }

    private void LookFunction()
    {
        Debug.Log("test: " + IMouseX + "," + IMouseY);

        //float rotationX = transform.localEulerAngles.y + IMouseX * sensitivityX * Time.deltaTime;

        //rotationY += IMouseY * sensitivityY * Time.deltaTime;
        //rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        //transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);


        //transform.Rotate(Vector3.up, IMouseX * Time.deltaTime);

        yRotation += IMouseX; 
        xRotation -= IMouseY; 
        xRotation = Mathf.Clamp(xRotation, minimumY, minimumY); 
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        targetRotation.y = yRotation;
        transform.eulerAngles = targetRotation;
    }
}
