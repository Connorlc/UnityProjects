﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;

    private string playerSide;

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        if(buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) {
            GameOver();
        } else if(buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) {
            GameOver();
        } else if(buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) {
            GameOver();
        } else if(buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide) {
            GameOver();
        } else if(buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide) {
            GameOver();
        } else if(buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide) {
            GameOver();
        } else if(buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide) {
            GameOver();
        } else if(buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide) {
            GameOver();
        }

        ChangeSides();
    }

    void GameOver()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }

        gameOverText.text = playerSide + " Wins!";
        gameOverPanel.SetActive(true);
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
    }
}
