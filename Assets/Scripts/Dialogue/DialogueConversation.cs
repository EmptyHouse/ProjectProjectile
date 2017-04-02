using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueConversation : MonoBehaviour {
    public string fileName = "Default.txt";

    DialogueNode headNode;
    DialogueNode currentNode;

    string filePath;


    void Start()
    {
        filePath = Application.dataPath + "/Game";
    }

    void Update()
    {

    }


    void parseNodes(string fileName)
    {

    }
}
