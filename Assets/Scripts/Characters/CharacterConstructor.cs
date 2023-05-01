using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConstructor : MonoBehaviour
{
    public Character characterData;
    SkinnedMeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    public void ConstructCharacter(Character character)
    {
        characterData = character;

        meshRenderer.sharedMesh = character.characterMesh;
    }
}
