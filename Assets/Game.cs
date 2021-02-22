using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game : MonoBehaviour
{
    bool isGameOver;
    [SerializeField]
    Transform coin;
    bool GameStarted = false;
    [SerializeField]
    GameObject GameOver;
    [SerializeField]
    Text Tokentxt;
    [SerializeField]
    GameObject Jackpot;
    [SerializeField]
    int Token;
    public Text obj1, obj2, obj3;
    //private IEnumerator coroutine;


    [SerializeField]
    private float changeRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        Token = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (Token == 0) { GameOverfunc(); }
        //coroutine = changeNumber(changeRate);
        //StartCoroutine(coroutine);
        if (GameStarted)
        {
            
            if (changeRate >= 100f)
            {
                CalculatePrize();
                Debug.Log("Stoped");
                // StopCoroutine(coroutine);
                GameStarted = false;
            }
            else

            {
                Invoke("changeNumber", 0.1f);
                changeRate = changeRate + 3f;
                Debug.Log(changeRate);
            }
        }
        Tokentxt.text = Token.ToString();

    }

    private void CalculatePrize()
    {
        int a = int.Parse(obj1.text);
        int b = int.Parse(obj2.text);
        int c = int.Parse(obj3.text);
        if (a == b && b == c)
        {
            Debug.Log(obj1.text+"IJILSEH UTGA");

            if (a == 1) { Token += 2; CoinInit(3); }
            if (a == 2)
            { Token += 18; JackbotFunc(); CoinInit(10); }
            if (a == 3) { Token += 4; CoinInit(5); }
            setresult(obj1.text);
            GameStarted = false;
            Debug.Log(Token);
        }
    }

    public void GameOverfunc()
    {
        isGameOver = true;
        GameOver.SetActive(isGameOver);
        Token = 20;
    }

    void changeNumber()
    {
        int i = 1;
        obj1.text = UnityEngine.Random.Range(i, i + 3).ToString();
        obj2.text = UnityEngine.Random.Range(i, i + 3).ToString();
        obj3.text = UnityEngine.Random.Range(i, i + 3).ToString();
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

            Token -= 2;
            changeRate = 0.1f;
            GameOver.SetActive(false);
            Jackpot.SetActive(false);
            GameStarted = true;
        }


    }


    void setresult(string st)
    {
        obj1.text = st;
        obj2.text = st;
        obj3.text = st;
    }
   
    void CoinInit(int times)
    {
        for (int i = 0; i == times; i++)
        {
            Instantiate(coin, new Vector3(280, 180, 460), Quaternion.identity);
        }

    }
}


