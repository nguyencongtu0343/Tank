using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : SingletonMonoBehaviour<CameraController>
{
    public void CameraMove(Vector3 Pos)
    {
        transform.position = new Vector3(
            Pos.x,
            Pos.y,
            -10
            );
    }
}
