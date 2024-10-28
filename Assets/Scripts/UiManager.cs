using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject backgroundPanel;  // Background for when the game ends
    public GameObject victoryPanel;     // Panel shown when the player wins
    public GameObject losePanel;        // Panel shown when the player loses

    public TMP_Text pointsTxt; // Text component for points
    public TMP_Text movesTxt;  // Text component for moves
    public TMP_Text goalTxt;   // Text component for goal

    // Update the UI with current game data


    public void UpdateUI(int points, int moves, int goal)
    {
        pointsTxt.text = "Points: " + points.ToString();
        movesTxt.text = "Moves: " + moves.ToString();
        goalTxt.text = "Goal: " + goal.ToString();
    }

    // Show the victory panel when the player wins
    public void DisplayVictoryPanel()
    {
        backgroundPanel.SetActive(true);
        victoryPanel.SetActive(true);
    }

    // Show the lose panel when the player loses
    public void DisplayLosePanel()
    {
        backgroundPanel.SetActive(true);
        losePanel.SetActive(true);
    }
}
