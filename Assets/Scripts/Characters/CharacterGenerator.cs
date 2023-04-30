using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    public CharacterAsset[] possibleCharacters;

    public CharacterAsset GenerateRandomCharacter()
    {
        int index = Random.Range(0, possibleCharacters.Length);
        CharacterAsset character = Instantiate(possibleCharacters[index]);
        character.characterName = GenerateRandomName();
        character.destination = GenerateRandomDestination();
        return character;
    }

    private string GenerateRandomName()
    {
        // TODO: Implement logic to generate random names
        return "John Doe";
    }

    private string GenerateRandomDestination()
    {
        // TODO: Implement logic to generate random destinations
        return "Unknown";
    }
}
