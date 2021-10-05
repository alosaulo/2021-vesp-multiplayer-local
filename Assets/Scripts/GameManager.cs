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

    public Camera[] playersCam;

    public Transform[] playersPositions;

    public Image[] playersLifeImg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cvCam4All.transform.position;
        GetPlayerDistance();
        SplitScreen();
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

    bool split = false;
    void SplitScreen() {
        Vector2 vec = new Vector2(totalX, totalY);
        for (int i = 0; i < playersPositions.Length; i++)
        {
            Vector2 playerPos = playersPositions[i].position;
            if (Vector2.Distance(vec, playerPos) >= 4 &&
                    split == false)
            {
                split = true;
            }
            else if (Vector2.Distance(vec, playerPos) <= 4) {
                split = false;
            }
        }
        if (split == true)
        {
            cvCam4All.gameObject.SetActive(false);
            for (int i = 0; i < playersCam.Length; i++)
            {
                playersCam[i].gameObject.SetActive(true);
            }
        }
        else {
            cvCam4All.gameObject.SetActive(true);
            for (int i = 0; i < playersCam.Length; i++)
            {
                playersCam[i].gameObject.SetActive(false);
            }
        }
    }

}
