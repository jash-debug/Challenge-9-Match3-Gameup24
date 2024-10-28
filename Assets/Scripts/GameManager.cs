using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Static reference to GameManager

    public int goal;  // Points needed to win the game
    public int moves; // Number of turns allowed
    public int points; // Points earned so far
    public bool isGameEnded; // Is the game over?

    private UIManager uiManager; // Reference to the UIManager (without singleton)

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make GameManager persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    private void Start()
    {
        // Look for UIManager in the current scene
        uiManager = FindObjectOfType<UIManager>();

        if (uiManager == null)
        {
            Debug.LogError("UIManager not found in the scene.");
        }
    }

    public void Initialize(int _moves, int _goal)
    {
        moves = _moves;
        goal = _goal;

        if (uiManager != null)
        {
            uiManager.UpdateUI(points, moves, goal); // Update UI when initializing
        }
    }

    // Process the player's turn
    public void ProcessTurn(int pointsToGain, bool subtractMoves)
    {
        points += pointsToGain;
        if (subtractMoves)
        {
            moves--;
        }

        // Update the UI after turn
        if (uiManager != null)
        {
            uiManager.UpdateUI(points, moves, goal);
        }

        // Check for win or lose conditions
        if (points >= goal)
        {
            //isGameEnded = true;

            if (uiManager != null)
            {
                uiManager.DisplayVictoryPanel(); // Player wins
            }
            return;
        }

        if (moves <= 0)
        {
            isGameEnded = true;

            if (uiManager != null)
            {
                uiManager.DisplayLosePanel(); // Player loses
            }
            return;
        }
    }

    // Call this method to transition to the next level after winning
    public void WinGame()
    {
        // Load the next level
        points = 0;
        SceneManager.LoadScene(1);

        // Since UIManager is not persistent, find it again in the new scene
        uiManager = FindObjectOfType<UIManager>();

        Initialize(5, 20); // Example initialization for level 2
    }

    // Call this method to restart the game after losing
    public void LoseGame()
    {
        // Reload the first level or restart the game
        SceneManager.LoadScene(0);

        // Since UIManager is not persistent, find it again in the new scene
        uiManager = FindObjectOfType<UIManager>();

        Initialize(5, 10); // Example re-initialization
    }
}
