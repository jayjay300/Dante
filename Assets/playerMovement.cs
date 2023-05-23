 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class playerMovement : MonoBehaviour {
     public float speed = 25.0F;
     public float jumpSpeed = 8.0F; 
     public float gravity = 20.0F;
     private Vector3 moveDirection = Vector3.zero;
     private float turner;
     private float looker;
     public float sensitivity = 5;

      public float smooth = 1f;

     private Vector3 targetAngles;

    [SerializeField]

    Animator anim;

    [SerializeField]
    GameObject animm;

    // Use this for initialization
    void Start () {
         
     }
     
     // Update is called once per frame
     void Update () {
         CharacterController controller = GetComponent<CharacterController>();
         // is the controller on the ground?
         if (controller.isGrounded) {
             //Feed moveDirection with input.
             moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
             moveDirection = transform.TransformDirection(moveDirection);
             //Multiply it by speed.
             moveDirection *= speed;
             //Jumping
            // if (Input.GetButton("Jump"))
          //       moveDirection.y = jumpSpeed;
             
         }

         if(Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") == 0){
            anim.SetBool("IsDown", false);
             anim.SetBool("IsUp", false);
             anim.SetBool("IsIdle", false);
            anim.SetBool("IsWalkLeft", false); //set to right
            anim.SetBool("IsWalkRight", true);

                targetAngles = transform.eulerAngles + 180f * Vector3.up; // what the new angles should be
     
     animm.transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 0.01f); 
            
         }else if(Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") == 0){
            anim.SetBool("IsDown", false);
             anim.SetBool("IsUp", false);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsWalkRight", false);
                anim.SetBool("IsWalkLeft", true); //set to right
                    targetAngles = transform.eulerAngles + 180f * Vector3.up; // what the new angles should be
     
     animm.transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 0.01f); 
            
        }
         else if(Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0){
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsWalkRight", false); //set to right
        anim.SetBool("IsWalkLeft", false);
        anim.SetBool("IsDown", false);
        anim.SetBool("IsUp", true);
         }
        else if(Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0){
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsWalkLeft", false);
        anim.SetBool("IsWalkRight", false); //set to right
        anim.SetBool("IsUp", false);
        anim.SetBool("IsDown", true);
         }else if(Input.GetAxis("Vertical") == 0){
            anim.SetBool("IsDown", false);
             anim.SetBool("IsUp", false);
             anim.SetBool("IsWalkLeft", false);
            anim.SetBool("IsWalkRight", false); //set to right
            anim.SetBool("IsIdle", true);
         }
         
         /*
         turner = Input.GetAxis ("Mouse X")* sensitivity;
         looker = -Input.GetAxis ("Mouse Y")* sensitivity;
         if(turner != 0){
             //Code for action on mouse moving right
             transform.eulerAngles += new Vector3 (0,turner,0);
         }
         if(looker != 0){
             //Code for action on mouse moving right
             transform.eulerAngles += new Vector3 (looker,0,0);
         }
         */
         //Applying gravity to the controller
         moveDirection.y -= gravity * Time.deltaTime;
         //Making the character move
         controller.Move(moveDirection * Time.deltaTime);
     }
 }
