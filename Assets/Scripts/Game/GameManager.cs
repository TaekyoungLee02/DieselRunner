using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager           Instance;

    private UIManager                   uiManager;


    [SerializeField] GameObject         player;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        uiManager = UIManager.Instance;


        uiManager.LifeGain(player.GetComponent<PlayerStatus>().Life);
    }

    public void LifeGain(int amount = 1)
    {
        uiManager.LifeGain(amount);
    }

    public void LifeLose(int amount = 1)
    {
        uiManager.LifeLose(amount);
    }
}
