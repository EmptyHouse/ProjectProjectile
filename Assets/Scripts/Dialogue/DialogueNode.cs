using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode : MonoBehaviour {
    public enum Emotion { Neutral, Happy, Sad, Embarrassed, Mad, Excited }

    public string characterName;
    public string dialogueLine;
    public Emotion currentEmotion;
}
