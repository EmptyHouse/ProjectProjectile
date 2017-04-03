using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueConversation : MonoBehaviour {
    public string fileName = "Default.txt";


    DialogueNode headNode;
    DialogueNode currentNode;
    Transform playerObject;

    string filePath;


    void Start()
    {
        filePath = Application.dataPath + "/Game";
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {

    }

    void OnTriggerExit2D(Collider2D collider)
    {

    }
}
