using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour {
    public float maxWalkSpeed = 5f;
    public float maxRunSpeed = 15f;
    public float acceleration = 25f;
    public float[] thresholdSpeeds = new float[] { .1f, .7f };//This needs to be a length of two
    public bool  updateActive = true;
    public bool inputActive = true;

    float hInput;
    Rigidbody2D rigid;
    Animator anim;

    void Start()
    {
        if (thresholdSpeeds.Length <= 1)
        {
            thresholdSpeeds = new float[] { .1f, .7f };//These will be used as 
        }
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(hInput));
        anim.SetFloat("VerticalVelocity", rigid.velocity.y);
    }

    void FixedUpdate()
    {
        if (!updateActive) return;
        updateVelocity();
    }

    public void setHorizontalInput(float hInput)
    {
        if (!inputActive)
        {
            hInput = 0;
            return;
        }
        
        this.hInput = hInput;
    }

    void updateVelocity()
    {
        int speedIndex = -1;
        foreach (float i in thresholdSpeeds)
        {
            if (i < Mathf.Abs(hInput)) speedIndex++;
        }
        float goalSpeed = 0;
        if (speedIndex >= 0)
        {
            goalSpeed = ((speedIndex == 0) ? maxWalkSpeed : maxRunSpeed) * ((hInput > 0) ? 1 : -1);
        }
        rigid.velocity = Vector2.MoveTowards(rigid.velocity, new Vector2(goalSpeed, rigid.velocity.y), Time.fixedDeltaTime * acceleration);
    }

    public float getHorizontalInput()
    {
        return hInput;
    }
}
