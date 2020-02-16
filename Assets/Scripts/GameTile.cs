using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour
{
    [SerializeField]
    Transform arrow = default;

    GameTile west, east, north, south, nextOnPath;

    int distance;

    public bool IsAlternative {get; set;}

    public bool HasPath => distance != int.MaxValue;

    public GameTile GrowPathNorth => GrowPathTo(north);
    public GameTile GrowPathSouth => GrowPathTo(south);
    public GameTile GrowPathEast => GrowPathTo(east);
    public GameTile GrowPathWest => GrowPathTo(west);

    public static void MakeEastWestNeighbors(GameTile east, GameTile west)
    {
        Debug.Assert(
            west.east == null && east.west == null, "Redefined neighbors!"
        );
        west.east = east;
        east.west = west;
    }

    public static void MakeNorthSouthNeighbors(GameTile north, GameTile south)
    {
        Debug.Assert(
            north.south == null && south.north == null, "Redefined neighbors!"
        );
        north.south = south;
        south.north = north;
    }

    public void ClearPath()
    {
        distance = int.MaxValue;
        nextOnPath = null;
    }

    GameTile GrowPathTo(GameTile neighbor)
    {
        Debug.Assert(HasPath, "No path!");
        if (neighbor == null || neighbor.HasPath)
        {
            return null;
        }
        neighbor.distance = distance + 1;
        neighbor.nextOnPath = this;
        return neighbor;
    }

    public void BecomeDestination()
    {
        distance = 0;
        nextOnPath = null;
    }

    public void ShowPath()
    {
        if (distance == 0)
        {
            arrow.gameObject.SetActive(false);
            return;
        }
        arrow.gameObject.SetActive(true);
        arrow.localRotation =
            nextOnPath == north ? northRotation :
            nextOnPath == east ? eastRotation :
            nextOnPath == south ? southRotation :
            westRotation;
    }

    static Quaternion
        northRotation = Quaternion.Euler(0f, 0f, 0f),
        eastRotation = Quaternion.Euler(0f, 0f, -90f),
        southRotation = Quaternion.Euler(0f, 0f, 180f),
        westRotation = Quaternion.Euler(0f, 0f, 90f);

}
