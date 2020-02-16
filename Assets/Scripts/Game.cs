using UnityEngine;

public class Game : MonoBehaviour
{

	[SerializeField]
	int boardSize = 11;

	[SerializeField]
	GameBoard board = default(GameBoard);

	void Awake()
	{
		board.Initialize(boardSize);
	}
}
