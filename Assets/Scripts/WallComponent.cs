using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallComponent : MonoBehaviour
{
    public Transform UpperWall;
    public Transform BottomWall;
    public Transform RightWall;
    public Transform LeftWall;

    public Vector2 GetRandomPointWithinWallBoundaries(Bounds BossBounds)
    {
        Vector2 TopLeft, BottomRight;
        TopLeft.x = LeftWall.position.x + LeftWall.GetComponent<BoxCollider2D>().bounds.extents.x + BossBounds.extents.x;
        TopLeft.y = UpperWall.position.y - UpperWall.GetComponent<BoxCollider2D>().bounds.extents.y - BossBounds.extents.y;
        BottomRight.x = RightWall.position.x - RightWall.GetComponent<BoxCollider2D>().bounds.extents.x - BossBounds.extents.x;
        BottomRight.y = BottomWall.position.y + BottomWall.GetComponent<BoxCollider2D>().bounds.extents.y + BossBounds.extents.y;
        return new Vector2(Random.Range(TopLeft.x, BottomRight.x), Random.Range(TopLeft.y, BottomRight.y));
    }
}
