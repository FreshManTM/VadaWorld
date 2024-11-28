using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLevel : MonoBehaviour
{
    public Transform Shadow;
    [SerializeField] GameObject _lock;
    [SerializeField] Image _stroke;

    public void UnlockLvl()
    {
        _lock.SetActive(false);
        Shadow.gameObject.SetActive(false);
    }
    public bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number <= 3) return true;

        if (number % 2 == 0 || number % 3 == 0) return false;

        for (int i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
                return false;
        }
        return true;
    }
    public void SetCurrentLvl()
    {
        GetComponent<Button>().enabled = true;
        _stroke.color = Color.yellow;
    }
}
