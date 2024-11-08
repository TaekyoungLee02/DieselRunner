using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager             Instance;

    [SerializeField] GameObject         lifeImage;
    [SerializeField] GameObject         lifeContainer;
    private Stack<GameObject>                 lifeList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    public void LifeGain(int amount = 1)
    {
        if(lifeList == null) lifeList = new Stack<GameObject>();

        int currentAmount = lifeContainer.transform.childCount;

        for(int i = 0; i < amount; i++) 
        {
            var life = Instantiate(lifeImage, lifeContainer.transform);
            life.GetComponent<RectTransform>().anchoredPosition = new Vector2(currentAmount * 75, 0);
            currentAmount++;

            lifeList.Push(life);
        }
    }

    public void LifeLose(int amount = 1)
    {
        for(int i = 0; i < amount; i++)
        {
            if(lifeList.Count <= 0) break;

            var life = lifeList.Pop();
            Destroy(life);
        }
    }
}
