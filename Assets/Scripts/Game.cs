using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game : MonoBehaviour
{
    bool isGameOver;
    [SerializeField]
    GameObject coin;
    [SerializeField]
    Transform coinSpawn;
    bool GameStarted = false;
    [SerializeField]
    GameObject GameOver;
    [SerializeField]
    Text Tokentxt;
    [SerializeField]
    GameObject Jackpot;
    [SerializeField]
    int MONEY = 20;
    public Text obj1, obj2, obj3;
    int a, b, c;


    [SerializeField]
    private float changeRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        MONEY = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (MONEY == 0) { GameOverfunc(); }
        if (GameStarted)
        {
            
            if (changeRate >= 100f)
            {
                StopCoroutine("changeNumber");
                CheckPrize();
                Debug.Log("Stoped");
                GameStarted = false;
            }
            else
            {
                StartCoroutine("changeNumber");
                  changeRate = changeRate + 1f;
                Debug.Log(changeRate);
            }
        }
        Tokentxt.text = MONEY.ToString();

    }

    public void RandomSpin()
    {
        a = UnityEngine.Random.Range(1, 4);
        b = UnityEngine.Random.Range(1, 4);
        c = UnityEngine.Random.Range(1, 4);
        obj1.text = a.ToString();
        obj2.text = b.ToString();
        obj3.text = c.ToString();
    }

    public void GameOverfunc()
    {
        isGameOver = true;
        GameOver.SetActive(isGameOver);
        
    }

    IEnumerator changeNumber()
    {
        RandomSpin();
        Debug.Log("Int: " + a + "  " + b + "  " + c);
        yield return new WaitForSeconds(changeRate);
    }

    private void CheckPrize()
    {
        if (a == b && b == c)
        {
            switch (a)
            {
                case 1:
                    MONEY += 4;
                    StartCoroutine("CoinSpawn",4);
                    setresult(1);
                    break;
                case 2:
                    MONEY += 18;
                    JackbotFunc();
                    StartCoroutine("CoinSpawn",18);
                    setresult(2);
                    break;
                case 3:
                    MONEY += 8;
                    StartCoroutine("CoinSpawn",8);
                    setresult(3);
                    break;
            }
        }
    }

    void JackbotFunc()
    {
        Jackpot.SetActive(true);
        isGameOver = false;
    }
    public void StartSpin()
    {
        if (GameStarted == false)
        {
            if (isGameOver) { MONEY = 20; }
            MONEY -= 2;
            changeRate = 0.1f;
            GameOver.SetActive(false);
            Jackpot.SetActive(false);
            GameStarted = true;
        }


    }


    void setresult(int arg)
    {
        
        obj1.text = arg.ToString(); 
        obj2.text = arg.ToString();
        obj3.text = arg.ToString();
    }
   
    
    IEnumerator CoinSpawn(int iii)
    {
        for (int i = 0; i <= iii; i++)
        {
            Debug.Log("spawn !!!!!");
            Instantiate(coin, coinSpawn.position, Quaternion.identity);
        }
        Debug.Log("spawn func!");
        yield return new WaitForSeconds(1);
        
                }

    public void CoinInit(int ii)
    {
        
        for (int i = 0; i <= ii; i++)
        {
            
            Debug.Log("spawn !!!!!");
            Instantiate(coin, coinSpawn.position, Quaternion.identity);
        }
        Debug.Log("spawn func!");
    }
}


