using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortBoardList : MonoBehaviour
{
    [Header("Control Variables")]
    [SerializeField] List<Character> characters = new List<Character>();
    [SerializeField] int queuedLimit = 4;
    [SerializeField] List<Transform> spots;

    [SerializeField] float waitTime = 2f;

    [Header("Character")]
    [SerializeField] GameObject characterPrefab;

    [Header("Systems")]
    [SerializeField] private CharacterGenerator characterGenerator;

    Character currentCharacter;
    bool isBoarding;

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
        currentCharacter.GO = visualCharacter;
    }

    public void MoveToShip()
    {
        Character lastCharacter = characters[0];
        FindObjectOfType<ShipBoardList>().AddCharacterToList(lastCharacter);
        PopQuededCharacter(lastCharacter);
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && characters.Count > 0 && !isBoarding)
        {
            isBoarding = true;
            StartCoroutine(MoveTimer());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator MoveTimer()
    {
        ShipBoardList boardList = FindObjectOfType<ShipBoardList>();
        if (boardList.boardedCount < boardList.boardingLimit)
        {
            yield return new WaitForSeconds(waitTime);
            MoveToShip();
            //boardList.AddCharacterToList(character);
        }
        isBoarding = false;
    }
}
