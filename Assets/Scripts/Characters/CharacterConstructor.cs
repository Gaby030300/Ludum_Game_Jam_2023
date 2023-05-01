using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConstructor : MonoBehaviour
{
    public Character characterData;
    [SerializeField] GameObject[] meshes;
    [SerializeField] SkinnedMeshRenderer meshRenderer;

    private void Start()
    {
        //meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    public void ConstructCharacter(Character character)
    {
        characterData = character;

        int index = Random.Range(0,meshes.Length);
        meshes[index].SetActive(true);
        //meshRenderer.sharedMesh = character.characterMesh;
    }
}
