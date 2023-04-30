using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Character",menuName ="Create Character")]
public class CharacterAsset : ScriptableObject
{
    public enum destinations {coconut, hacker, treasure,shipwreck }

    public Mesh CharacterMeshes;
    public Sprite portrait;
    public string[] characterName;
    public destinations destination;
    public AudioClip voiceLine;



}
