using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonScript : MonoBehaviour,IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene("Level1");
    }
}
