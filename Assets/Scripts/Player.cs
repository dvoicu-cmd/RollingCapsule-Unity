using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //Object
//MonoBehavior has a bunch of nice features that is inherited.
{
    //Access modifyer, then type, then name.
    private bool upNudge; //For up input
    private bool rightNudge;
    private bool leftNudge;
    private Rigidbody rigidbody; //Rigid body pointer
    private bool isGrounded;

    //Need dedection on all sides. For future note: Make it one big square hit box instead of 4 spheres.
    [SerializeField] private Transform groundCheckerB = null; 
    [SerializeField] private Transform groundCheckerL = null;
    [SerializeField] private Transform groundCheckerR = null;
    [SerializeField] private Transform groundCheckerT = null;

    // Start is called before the first frame update
    void Start(){
        rigidbody = GetComponent<Rigidbody>(); //Store pointer to rigidBody
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.UpArrow)){ //Input class, that gets if the space key is pressed down.
            upNudge = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            leftNudge = true;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            rightNudge = true;
        }
    }

    // Fixed Update is called every physics update (100 hz)
    void FixedUpdate(){

        //Bad practice, don't repeat yourself.
        int top = Physics.OverlapSphere(groundCheckerT.position, 0.1f).Length;
        int bottom = Physics.OverlapSphere(groundCheckerB.position, 0.1f).Length;
        int left = Physics.OverlapSphere(groundCheckerL.position, 0.1f).Length;
        int right = Physics.OverlapSphere(groundCheckerR.position, 0.1f).Length;

        //Supposed collision checks. But it did not work in the end.
        if (top > 11 || bottom > 11){ 
            Debug.Log("top vs bottom values:" + top + "" + bottom);
            isGrounded = false;
        }
        else if (left > 11 || right > 11){
            Debug.Log("left vs right valuse:" + left + "" + right);
            isGrounded = false;
        }
        else {
            isGrounded = true;
        }
        
        if(upNudge){
            if(isGrounded){
                rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
                upNudge = false;
            }
        }
        //I want them to spin
        if(leftNudge){
            rigidbody.AddTorque(Vector3.forward * 5, ForceMode.Impulse);
            leftNudge = false;
        }
        if(rightNudge){
            rigidbody.AddTorque(Vector3.back * 5, ForceMode.Impulse);
            rightNudge = false;
        }
    }




}
