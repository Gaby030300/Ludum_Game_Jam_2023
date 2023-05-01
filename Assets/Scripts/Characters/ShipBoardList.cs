using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBoardList : MonoBehaviour
{
    [SerializeField] List<Character> characters;
    [SerializeField] int boardingLimit=4;
    public void AddCharacterToList(Character character)
    {
        if (characters.Count<boardingLimit)
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
