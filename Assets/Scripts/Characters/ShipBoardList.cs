using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBoardList : MonoBehaviour
{
    [SerializeField] List<Character> characters;
    [SerializeField] public int boardingLimit=4;
    [SerializeField] List<Transform> spots;
    public int boardedCount { private set; get; }

    XController xController;

    private void Start()
    {
        xController = FindObjectOfType<XController>();
    }

    public void AddCharacterToList(Character character)
    {
        if (characters.Count<boardingLimit)
        {
            characters.Add(character);
            MoveCharacter(character.GO);
            boardedCount++;
        }
        else
        {
            ///BOARDING FULL
        }
    }

    private void LateUpdate()
    {
        if(characters.Count>0) xController.ActivateCurrent(characters[0]);
    }

    public void MoveCharacter(GameObject characterGO)
    {
        characterGO.transform.parent = spots[characters.Count - 1];
        characterGO.transform.localPosition = Vector3.zero;
        Debug.Log("Character " + characterGO.name + " has boarded the ship and is now on their way to their destination.");
    }

    public Character GetLastCharacter()
    {
        return characters[0];
    }

    public void PopQuededCharacter(Character character)
    {
        characters.Remove(character);
        boardedCount = boardedCount>0? boardedCount--:0;
    }
    public void PopQuededCharacter()
    {
        characters.RemoveAt(0);
        boardedCount = boardedCount>0? boardedCount--:0;
    }
}
