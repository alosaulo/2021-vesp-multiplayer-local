using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float 
        yMax = float.MinValue, 
        yMin = float.MaxValue, 
        xMax = float.MinValue, 
        xMin = float.MaxValue,
        totalX = 0, totalY = 0;

    public Cinemachine.CinemachineVirtualCamera cvCam4All;

    public Transform[] playersPositions;

    public Image[] playersLifeImg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerDistance();
    }

    public Image GetLifeImage(int playerNumber) {
        return playersLifeImg[playerNumber - 1];
    }

    Vector2 pos;
    private void OnDrawGizmos()
    {
        pos = new Vector2(totalX, totalY);
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(pos,0.3f);
    }

    void GetPlayerDistance() {
        
        yMax = float.MinValue;
        yMin = float.MaxValue;
        xMax = float.MinValue;
        xMin = float.MaxValue;

        for (int i = 0; i < playersPositions.Length; i++)
        {
            Vector3 playerPos = playersPositions[i].position;
            if (yMax < playerPos.y)
            {
                yMax = playerPos.y;
            }
            if (yMin > playerPos.y)
            {
                yMin = playerPos.y;
            }
            if (xMax < playerPos.x)
            {
                xMax = playerPos.x;
            }
            if (xMin > playerPos.x)
            {
                xMin = playerPos.x;
            }
        }

        totalX = (xMax + xMin) / 2;
        totalY = (yMin + yMax) / 2;

        cvCam4All.transform.position = new Vector3(totalX, totalY, -10f);

        yMax = float.MinValue;
        yMin = float.MaxValue;
        xMax = float.MinValue;
        xMin = float.MaxValue;
    }

}
