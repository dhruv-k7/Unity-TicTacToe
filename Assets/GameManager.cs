using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private string[] board = new string[9];

    private bool xTurn = true;
    private bool gameOver = false;

    public Cell[] cells;

    public TextMeshProUGUI turnText;
    public TextMeshProUGUI resultText;
    
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        turnText.text = "Player X turn";
        resultText.text = "";
    }

    public void CellClicked(int index)
    {
        if (gameOver)
            return;
        if (board[index] != null)
            return;

        string currentPlayer = xTurn ? "X" : "O";

        board[index] = currentPlayer;
        cells[index].cellText.text = currentPlayer;

        if (checkWinner(currentPlayer))
        {
            resultText.text = $"Player {currentPlayer} wins!";
            turnText.gameObject.SetActive(false);
            gameOver = true;
        }
        else if (checkDraw())
        {
            resultText.text = "It's a draw!";
            turnText.gameObject.SetActive(false);
            gameOver = true;
        }
        else
        {
            xTurn = !xTurn;
            turnText.text = $"Player {(xTurn ? "X" : "O")} turn";
        }

    }

    private bool checkWinner(string player)
    {
        int[,] wins = new int[,]
        {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8},
            {0, 3, 6},
            {1, 4, 7},
            {2, 5, 8},
            {0, 4, 8},
            {2, 4, 6}
        };

        for (int i = 0; i < wins.GetLength(0); i++)
        {
            if (board[wins[i, 0]] == player && board[wins[i, 1]] == player && board[wins[i, 2]] == player)
            {
                return true;
            }
        }
        return false;
    }
    private bool checkDraw()
    {
        foreach (var cell in board)
        {
            if (string.IsNullOrEmpty(cell))
                return false;
        }
        return true;
    }

    public void ResetGame()
    {
        board = new string[9];
        foreach (var cell in cells)
        {
            cell.cellText.text = "";
        }
        xTurn = true;
        gameOver = false;
        turnText.gameObject.SetActive(true);
        turnText.text = "Player X turn";
        resultText.text = "";
    }
}
