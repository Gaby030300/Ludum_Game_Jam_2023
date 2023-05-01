using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortBoardList : MonoBehaviour
{
    [Header("Control Variables")]
    [SerializeField] List<Character> characters = new List<Character>();
    [SerializeField] int queuedLimit = 4;
    [SerializeField] List<Transform> spots;

    [Header("Character")]
    [SerializeField] GameObject characterPrefab;

    [Header("Systems")]
    [SerializeField] private CharacterGenerator characterGenerator;

    Character currentCharacter;

    private void Start()
    {
        for (int i = 0; i < queuedLimit; i++)
        {
            CreateNewCharacter();
        }
    }

    public void CreateNewCharacter()
    {
        if (characters.Count <= queuedLimit)
        {
            currentCharacter = characterGenerator.GenerateRandomCharacter();
            AddCharacterToList(currentCharacter);
            InstantiateCharacter();
        }
    }

    public void InstantiateCharacter()
    {        
            GameObject visualCharacter = Instantiate(characterPrefab,spots[characters.Count-1]);
            visualCharacter.GetComponent<CharacterConstructor>().ConstructCharacter(currentCharacter);
        
    }

    public void AddCharacterToList(Character character)
    {
        characters.Add(character);
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
