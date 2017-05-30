using UnityEngine;

public class BasicMechanics : MonoBehaviour {
    #region main variables
    [Tooltip("The goal speed that the character will move if its input is above 0 but below the runThreshold")]
    public float walkSpeed = 5f;
    [Tooltip("The goal speed that the character will move if it is above the runThreshold")]
    public float runSpeed = 8.5f;
    [Tooltip("The acceleration of our character's movement while they are on the ground")]
    public float acceleration = 25f;
    [Tooltip("Toggle this setting to determine whether or not we take inputs from the player during this time for movement")]
    public bool movementActive = true;

    [Tooltip("Toggle this setting to determine whether or not the character's direction will update based on the direction of the input")]
    public bool updateXDirection = true;

    [Tooltip("The max speed that the character can move if it is no longer on the ground")]
    public float inAirMaxSpeed;
    [Tooltip("The acceleration of our character while it is in the air")]
    public float inAirAcceleration;

    protected Animator anim;
    protected CustomPhysics rigid;

    private float walkThreshold = .1f;
    private float runThreshold = .6f;

    Vector2 inputDirection;
    #endregion main variables


    #region monobehaviour

    protected virtual void Start()
    {
        anim = GetComponent <Animator>();
        rigid = GetComponent<CustomPhysics>();
    }

    protected virtual void Update()
    {
        updateMovementGround();
        updateDirection();
    }

    #endregion monobehaviour

    protected virtual void updateMovementGround()
    {
        float goalSpeed = 0;
        if (movementActive)
        {
            if (Mathf.Abs(inputDirection.x) > runThreshold)
            {
                goalSpeed = runSpeed;
            }
            else if (Mathf.Abs(inputDirection.x) > walkThreshold)
            {
                goalSpeed = walkSpeed;
            }
            goalSpeed *= Mathf.Sign(inputDirection.x);
        }
        
        float currentSpeed = rigid.velocity.x;
        rigid.velocity = new Vector2(Mathf.MoveTowards(currentSpeed, goalSpeed, Time.deltaTime * acceleration), rigid.velocity.y);
    }

    public void updateDirection()
    {
        if (!updateXDirection) return;
        if (Mathf.Abs(inputDirection.x) > walkThreshold)
        {
            this.transform.localScale = new Vector3(Mathf.Sign(inputDirection.x), 1, 1);
        }
    }

    #region controller methods
    public void setHorizontalInput(float xInput)
    {
        this.inputDirection.x = xInput;
    }

    public void setVerticalInput(float yInput)
    {
        this.inputDirection.y = yInput;
    }

    public float getHorizontalInput()
    {
        return inputDirection.x;
    }

    public float getVerticalInput()
    {
        return inputDirection.y;
    }
    #endregion controller methods
}
