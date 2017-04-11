using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMechanics : MonoBehaviour {
    public ProjectileMechanics[] availableArrows;
    public int maxArrowsInMem = 5;
    public Transform centerLaunch;

    public Transform upLaunch;
    public Transform downLaunch;
    public Vector2 launchDirectionCenter = Vector2.left;
    public Vector2 lauchDirectionUp = new Vector2(-1, 1).normalized;
    public Vector2 lauchDirectionDown = new Vector2(-1, -1).normalized;

    ProjectileMechanics[,] projectilesInMemory;
    int currentArrowSelected = 0;
    int currentListPosition = 0;
    bool directionUp;
    bool directionDown;
    Animator anim;


    void Start()
    {
        projectilesInMemory = new ProjectileMechanics[availableArrows.Length, maxArrowsInMem];
        for (int i = 0; i < availableArrows.Length; i++)
        {
            for (int j = 0; j < maxArrowsInMem; j++)
            {
                projectilesInMemory[i, j] = Instantiate<ProjectileMechanics>(availableArrows[i], Vector3.zero, Quaternion.identity);
                projectilesInMemory[i, j].gameObject.SetActive(false);
            }
        }
        anim = transform.parent.GetComponent<Animator>();

    }

    public void fire()
    {
        Transform pos = centerLaunch;
        Vector2 dir = launchDirectionCenter;
        if (directionUp)
        {
            pos = upLaunch;
            dir = lauchDirectionUp;
        }
        else if (directionDown)
        {
            pos = downLaunch;
            dir = lauchDirectionDown;
        }
        dir = new Vector2(dir.x * transform.parent.localScale.x, dir.y).normalized;
        ProjectileMechanics p = projectilesInMemory[currentArrowSelected, currentListPosition];
        p.gameObject.SetActive(true);
        p.transform.position = pos.position;
        p.updateProjectileRotation(dir.x, dir.y);
        p.launch(dir);
        currentListPosition = (currentListPosition + 1) % maxArrowsInMem;

    }

    public void fire(bool fireInput)
    {
        if (!fireInput) return;
        anim.SetBool("AngleUp", directionUp);
        anim.SetBool("AngleDown", directionDown);
        anim.SetTrigger("Shoot");
    }


    public void setDirectionDown(bool button)
    {
        directionDown = button;
    }

    public void setDirectionUp(bool button)
    {
        directionUp = button;
    }

    //Destoys all the arrow objects that were created by the bow
    void OnDestroy()
    {
        for (int i = 0; i < projectilesInMemory.GetLength(0); i++)
        {
            for (int j = 0; j < projectilesInMemory.GetLength(1); j++)
            {
                if (projectilesInMemory[i, j] != null) Destroy(projectilesInMemory[i, j]);
            }
        }
    }
}
