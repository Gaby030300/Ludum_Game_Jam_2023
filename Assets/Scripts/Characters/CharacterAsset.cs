using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Character",menuName ="Create Character")]
public class CharacterAsset : ScriptableObject
{
    public Mesh Characters;
    public Sprite portrait;
    public string characterName;
    public string destination;
    public AudioClip voiceLine;


}
