using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    public CharacterAsset[] possibleCharacters;

    [SerializeField] Character currentCharacter;

    public Character GenerateRandomCharacter()
    {
        int index = Random.Range(0, possibleCharacters.Length);
        currentCharacter = new Character(possibleCharacters[index]);
        return currentCharacter;
    }

    ///You should be able to get 4 characters at first and if one of those is being poped up then create a new one
    ///Is it mandatory to create a new one each time a new one is being boarded?
    ///So I'll need 2 lists, one of the boarded characters and one of the Queued Characters
}
[System.Serializable]
public class Character{
        public Mesh characterMesh;
        public Sprite portrait;
        public string characterName; 
        public enum destinations { coconut, hacker, treasure, shipwreck }
        public destinations destination;
        public AudioClip voiceLine;
    public Character(CharacterAsset characterAsset)
    {
        characterMesh = characterAsset.CharacterMeshes;
        portrait = characterAsset.portrait;
        characterName = GetRandomName(characterAsset);
        destination = (destinations)(CharacterAsset.destinations)characterAsset.destination;
        voiceLine = characterAsset.voiceLine;
    }

    string GetRandomName(CharacterAsset characterAsset)
    {
        int index = Random.Range(0,characterAsset.characterName.Length);
        return characterAsset.characterName[index];
    }
}
