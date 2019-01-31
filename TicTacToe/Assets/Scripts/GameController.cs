using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return "?";
    }

    public void EndTurn()
    {
        Debug.Log("EndTurn is not implemented!");
    }

    void Awake()
    {
        SetGameControllerReferenceOnButtons();
    }
}
