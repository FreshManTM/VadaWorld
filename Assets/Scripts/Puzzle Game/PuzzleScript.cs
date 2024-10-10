using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScript : MonoBehaviour
{
    bool _puzzleSet;
    void Start()
    {
        int rotateTimes = Random.Range(1, 4);
        transform.rotation = Quaternion.Euler(0,0,rotateTimes * 90);
    }

   public void RotatePuzzle()
    {
        if(!_puzzleSet)
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.localRotation.eulerAngles.z + 90);
            if (transform.localRotation.eulerAngles.z < 0.1)
            {
                print("puzzle set");
                _puzzleSet = true;
                PGController.Instance.PuzzleSet();
            }
        }
    }
}
