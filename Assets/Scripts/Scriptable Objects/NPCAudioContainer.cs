using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCData", menuName = "ScriptableObjects/CreateNPCData", order = 1)]
public class NPCAudioContainer : ScriptableObject
{
    public AudioClip[] clips;
}
