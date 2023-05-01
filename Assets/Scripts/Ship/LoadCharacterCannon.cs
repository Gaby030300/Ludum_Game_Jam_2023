using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacterCannon : MonoBehaviour
{
    ShipBoardList shipBoardList;

    public void GetReadyToBeingShoot()
    {
        shipBoardList.PopQuededCharacter();
    }
}
