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
    
    public void SetCurrentLvl()
    {
        GetComponent<Button>().enabled = true;
        _stroke.color = Color.yellow;
    }
}
