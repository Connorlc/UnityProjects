using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;

    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;

    private string playerSide;
    private int moveCount;

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
        moveCount++;

        if(buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) {
            GameOver(playerSide);
        } else if(buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) {
            GameOver(playerSide);
        } else if(buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) {
            GameOver(playerSide);
        } else if(buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide) {
            GameOver(playerSide);
        } else if(buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide) {
            GameOver(playerSide);
        } else if(buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide) {
            GameOver(playerSide);
        } else if(buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide) {
            GameOver(playerSide);
        } else if(buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide) {
            GameOver(playerSide);
        } else if (moveCount >= 9) {
            GameOver("draw");
        } else {
            ChangeSides();
        }
    }

    void GameOver(string winner)
    {
        if (winner == "draw") {
            SetGameOverText("It's a Draw!");
        } else {
            SetGameOverText(winner + " Wins!");
        }

        SetBoardInteractable(false);
        restartButton.SetActive(true);
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        if (playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
    }

    void SetGameOverText(string winner)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = winner;
    }

    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        SetBoardInteractable(true);

        for (int i = 0; i < buttonList.Length; i++) {
            buttonList[i].text = "";
        }

        restartButton.SetActive(false);
        SetPlayerColors(playerX, playerO);
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++) {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        restartButton.SetActive(false);
        SetPlayerColors(playerX, playerO);
    }
}
