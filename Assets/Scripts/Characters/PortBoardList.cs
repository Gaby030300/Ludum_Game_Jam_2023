using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortBoardList : MonoBehaviour
{
    [Header("Control Variables")]
    [SerializeField] List<Character> characters;
    [SerializeField] int queuedLimit = 4;

    [Header("Character")]
    [SerializeField] GameObject characterPrefab;

    [Header("Systems")]
    [SerializeField] private CharacterGenerator characterGenerator;

    private void Start()
    {
        for (int i = 0; i < queuedLimit; i++)
        {
            CreateNewCharacter();
        }
    }

    public void CreateNewCharacter()
    {
        AddCharacterToList( characterGenerator.GenerateRandomCharacter());
    }

    public void AddCharacterToList(Character character)
    {
        if (characters.Count < queuedLimit)
        {
            characters.Add(character);
        }
        else
        {
            ///BOARDING FULL
        }
    }

    public void PopQuededCharacter(Character character)
    {
        characters.Remove(character);
    }
    public void PopQuededCharacter()
    {
        characters.RemoveAt(0);
    }
}
