using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundDistance = 1f;
    [SerializeField] private LayerMask groundMask ;
    private bool Isground ;
    private float speed = 5f;
    private float gravitasi = 9.8f;
    private CharacterController controller; 

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
    }

    void Loncat(){
        if(Input.GetButtonDown("Jump") && Isground){
            velocity.y = Mathf.Sqrt(2f*2f*gravitasi);
        }
        velocity.y -= gravitasi * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
    void gravity(){
        Isground = Physics.CheckSphere(GroundCheck.position,GroundDistance,groundMask);
        Debug.Log(Isground);
        if(Isground && velocity.y < 0){
            velocity.y = -2f;
        }
        
    }
    void Jalan(){
        float Horizontalvalue = Input.GetAxis("Horizontal");
        float VertikalValue = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(Horizontalvalue , 0f , VertikalValue) * speed * Time.deltaTime;


        controller.Move(movement);

        // transform.Translate(movement);
    }

    
}
