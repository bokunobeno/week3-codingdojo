using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody rb;
    private float xMovement, zMovement;
    private float facing;
    private Camera _camera;
    private Transform _transform, _cameraTransform;
    private bool canJump = true;
    [SerializeField]private float jumpForce;
    [SerializeField]  private Transform groundCheck;
    [SerializeField]  private LayerMask groundLayer;
    private bool grounded = true;
    private bool pressedJump = false;
    public SoundManager soundManager;

    [SerializeField] private TextMeshProUGUI healthText;
    public static int health = 10;
    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        rb=GetComponent<Rigidbody>();
        _cameraTransform = Camera.main.GetComponent<Transform>();

    }
    private void Update()
    {
        
        xMovement =Input.GetAxis("Horizontal")*speed;
        zMovement=Input.GetAxis("Vertical")*speed;
        _cameraTransform.position =
            new Vector3(_transform.position.x, _transform.position.y + 4, _transform.position.z - 5);
        
        grounded = Physics.Linecast(transform.position, groundCheck.position, groundLayer);
        Debug.DrawLine(transform.position, groundCheck.position, Color.red);
        if(grounded){
            canJump = true;
        }else{
            canJump = false;
        }
        if(Input.GetKeyDown(KeyCode.Space) && canJump){
            canJump = false;
            pressedJump = true;    
        }
    }

    private void FixedUpdate()
    {
        if(pressedJump){
            Jump();
            pressedJump = false;
        }
        Vector3 movement=new Vector3(xMovement,0,zMovement);
        rb.velocity=new Vector3(movement.x,rb.velocity.y,movement.z);
        
        if(movement.x!=0|| movement.z!=0) 
            facing=Mathf.Atan2(movement.x,movement.z) * Mathf.Rad2Deg;
        rb.rotation=Quaternion.Euler(0,facing,0);
        
        if (!grounded)
        {
            rb.AddForce(Physics.gravity * 1f, ForceMode.Acceleration);
        }
    }
    
    private void Jump()
    {
        if (canJump)
        {
            canJump = false;
            rb.AddForce(Vector3.up*jumpForce);
            soundManager.PlayPlayerJump();
        }
    }
    
   
      
}
