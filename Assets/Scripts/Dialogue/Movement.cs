using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueText", menuName = "DialogueText/New Dialogue Container", order = 0)]
public class DialogueText : ScriptableObject
{
    public string speakerName;
    [TextArea(5,10)]
    public string[] paragraphs;

}
