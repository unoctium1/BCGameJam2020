using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

	[SerializeField]
	Transform ground = default;

	[SerializeField]
	GameTile tilePrefab = default;

	Vector2Int size;
	GameTile[] tiles;

	Queue<GameTile> searchFrontier = new Queue<GameTile>();

	public void Initialize(Vector2Int size)
	{
		this.size = size;
		ground.localScale = new Vector3(size.x, size.y, 1f);


		Vector2 offset = new Vector2(
			(size.x - 1) * 0.5f, (size.y - 1) * 0.5f
		);
		tiles = new GameTile[size.x * size.y];
		for (int i = 0, y = 0; y < size.y; y++)
		{
			for (int x = 0; x < size.x; x++,i++)
			{
				GameTile tile = tiles[i] = Instantiate(tilePrefab);
				tile.transform.SetParent(transform, false);
				tile.transform.localPosition = new Vector3(
					x - offset.x, y - offset.y, 0f
				);
				if (x > 0)
					GameTile.MakeEastWestNeighbors(tile, tiles[i-1]);
				if (y > 0)
					GameTile.MakeNorthSouthNeighbors(tile, tiles[i - size.x]);
				tile.IsAlternative = (x & 1) == 0;
				if ((y & 1) == 0)
				{
					tile.IsAlternative = !tile.IsAlternative;
				}
			}
		}

		FindPaths();

	}

	void FindPaths()
	{
		foreach(GameTile tile in tiles)
		{
			tile.ClearPath();
		}
		tiles[0].BecomeDestination();
		searchFrontier.Enqueue(tiles[0]);

		while(searchFrontier.Count > 0)
		{
			GameTile t = searchFrontier.Dequeue();
			if (t != null)
			{
				if (t.IsAlternative)
				{
					searchFrontier.Enqueue(t.GrowPathNorth);
					searchFrontier.Enqueue(t.GrowPathEast);
					searchFrontier.Enqueue(t.GrowPathSouth);
					searchFrontier.Enqueue(t.GrowPathWest);
				}
				else
				{
					searchFrontier.Enqueue(t.GrowPathWest);
					searchFrontier.Enqueue(t.GrowPathSouth);
					searchFrontier.Enqueue(t.GrowPathEast);
					searchFrontier.Enqueue(t.GrowPathNorth);

				}
			}
		}

		foreach(GameTile t in tiles)
		{
			t.ShowPath();
		}
	}

}
