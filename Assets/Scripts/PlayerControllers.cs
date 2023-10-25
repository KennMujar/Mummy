        using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    //Movement
    public Rigidbody rb;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1; //0:left 1:middle 2:right
    public float laneDistance = 4; //distance between lanes

    //Gravity
    public float gravity = -20f;
    private Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    //Collision
    public Animator animator;
    public GameObject pole;
    public PoleController poleController;
    [SerializeField]
    private int slideSpeed = 25;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
       
        
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded)
        {
            
            slideSpeed = 25;
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
            animator.SetBool("hanging", false);

            //Gather the inputs

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                desiredLane++;
                if (desiredLane == 3)
                    desiredLane = 2;
            }

            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                desiredLane--;
                if (desiredLane == -1)
                    desiredLane = 0;
            }

        }
        else
        {
            bool isSliding = poleController.IsSliding();
            while (isSliding)
            {
                slideSpeed ++;
                animator.SetBool("hanging", true);
                rb.AddForce(transform.forward * slideSpeed);
                return;
            }
        }
        

        if(velocity.y > 0)
        {
            velocity.y = -2f;
        }

        //Calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 5 * Time.deltaTime);
        direction.y += gravity * Time.deltaTime;
    }


    
}
    




    






   