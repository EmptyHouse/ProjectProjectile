using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Animator anim;
    Movement movement;
    Jump jump;
    BowMechanics bowMechanics;
    Dodge dodgeMechanics;

    float hInput = 0;
    float vInput = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        bowMechanics = GetComponentInChildren<BowMechanics>();
        jump = GetComponent<Jump>();
        dodgeMechanics = GetComponent<Dodge>();
    }

    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        movement.setHorizontalInput(hInput);
        jump.jump(Input.GetButtonDown("Jump"));
        bowMechanics.setDirectionDown(Input.GetButton("DirectionDown"));
        bowMechanics.setDirectionUp(Input.GetButton("DirectionUp"));
        bowMechanics.fire(Input.GetButton("Fire"));
        dodgeMechanics.dodge(Input.GetButtonDown("Dodge"));
    }

    public void fireArrow()
    {
        bowMechanics.fire();
    }

    public float getInput()
    {
        return this.vInput;
    }

    private class BufferInput
    {
        int maxFramesActive = 5;
        Dictionary<string, InputInfo> bufferedInputList = new Dictionary<string, InputInfo>();

        public void add(string inputName)
        {
            InputInfo newInfo = new InputInfo();
            newInfo.maxFramesActive = this.maxFramesActive;
            newInfo.currentFramesActive = 0;
            newInfo.isActive = false;
            bufferedInputList[inputName] = new InputInfo();
        }

        public bool getIsActive(string inputName)
        {
            if (bufferedInputList.ContainsKey(inputName))
            {
                return bufferedInputList[inputName].isActive;
            }
            return false;
        }

        public void activateInput(string inputName)
        {
            InputInfo info = bufferedInputList[inputName];
            info.isActive = true;
            info.currentFramesActive = 0;
            bufferedInputList[inputName] = info;
        }

        public void update()
        {
            foreach (string i in bufferedInputList.Keys)
            {
                if (bufferedInputList[i].isActive)
                {
                    InputInfo newInfo = bufferedInputList[i];
                    newInfo.currentFramesActive = bufferedInputList[i].currentFramesActive + 1;
                    if (newInfo.currentFramesActive > newInfo.maxFramesActive)
                    {
                        newInfo.isActive = false;
                        newInfo.currentFramesActive = 0;
                    }
                    bufferedInputList[i] = newInfo;
                }
            }
        }

        struct InputInfo
        {
            public int maxFramesActive;
            public int currentFramesActive;
            public bool isActive;
        }
    }
}
