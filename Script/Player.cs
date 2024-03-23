using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Gravity")]

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundDistance = 0.3f;
    [SerializeField] private LayerMask groundMask ;
    public bool Isground ;
    private float gravitasi = 9.8f;


    [Header("Camera")]
    private float zoomDistance = 5f; 

    [SerializeField] private Transform cameraTransform ;
    [SerializeField] private float zoomSpeed = 2f; 
    [SerializeField] private float minZoomDistance = 2f; 
    [SerializeField] private float maxZoomDistance = 10f; 
    [Header("Controller Player")]
    private float speed = 5f;
    private CharacterController controller; 


     void OnTriggerEnter(Collider other) {
        Debug.Log("Test");
    }
    
    Vector3 velocity;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      Jalan();
      gravity();
      Loncat();
    //   ZoomCamera();
    }

    void Loncat(){
        if(Input.GetButtonDown("Jump") && Isground){
            velocity.y = Mathf.Sqrt(2f*2f*gravitasi);
        }

        velocity.y -= gravitasi* Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
    void gravity(){
        Isground = Physics.CheckSphere(GroundCheck.position,GroundDistance,groundMask);
        if(Isground && velocity.y < 0){
            velocity.y = -2f;
            // Debug.Log(GroundCheck.position);

        }
        
    }
    void ZoomCamera(){
        float Scrollbar = Input.GetAxis("Mouse ScrollWheel");
        zoomDistance -= Scrollbar * zoomSpeed;
        zoomDistance = Mathf.Clamp(zoomDistance, minZoomDistance, maxZoomDistance);

        Vector3 zoomPosition = cameraTransform.localPosition;
        zoomPosition.z = -zoomDistance;
        cameraTransform.localPosition = zoomPosition;
    }
    void Jalan(){
    float Horizontalvalue = Input.GetAxis("Horizontal");
    float VertikalValue = Input.GetAxis("Vertical");

    Vector3 cameraForward = cameraTransform.forward;
    Vector3 cameraRight = cameraTransform.right;

    cameraForward.y = 0f;
    cameraRight.y = 0f;

    Vector3 movement = (cameraForward.normalized * VertikalValue + cameraRight.normalized * Horizontalvalue) * speed * Time.deltaTime;

    controller.Move(movement);

    // Mengubah arah gerakan berdasarkan rotasi kamera
    movement = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movement;
    movement.Normalize();

    // Debug.Log(cameraTransform.rotation.eulerAngles);

    // transform.Translate(movement); // Anda mungkin tidak perlu ini lagi
    }


    // void Jalan(){
    //     float Horizontalvalue = Input.GetAxis("Horizontal");
    //     float VertikalValue = Input.GetAxis("Vertical");
    //     Vector3 movement = new Vector3(Horizontalvalue , 0f , VertikalValue) * speed * Time.deltaTime;
        
        
    //     controller.Move(movement);
    //     movement = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movement;
    //     movement.Normalize();
    //     Debug.Log(cameraTransform.rotation.eulerAngles);

    //     // transform.Translate(movement);
    // }

    private void OnApplicationFocus(bool focusStatus) {
        if(focusStatus){
            Cursor.lockState=CursorLockMode.Locked;
        }else{
            Cursor.lockState=CursorLockMode.None;

        }
    }
}
