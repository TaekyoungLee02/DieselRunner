using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int        life;


    
    public int Life { get { return life; } }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Trap"))
        {
            life--;
            GameManager.Instance.LifeLose();
        }
    }
}
