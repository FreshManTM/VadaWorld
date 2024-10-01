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
        GetComponent<Button>().enabled = true;
        _lock.SetActive(false);
        Shadow.gameObject.SetActive(false);
    }
    
    public void SetCurrentLvl()
    {
        _stroke.color = Color.yellow;
    }
}
