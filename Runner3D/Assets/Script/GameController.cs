using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
        public int scoreCoin;
        public Text scoreCointxt;
    public float score;
    public Text scoreText;

    public GameObject gameOver;
    private Player player ;

    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!player.isDead)
        {
            score += Time.deltaTime * 10f;
             scoreText.text = Mathf.Round(score).ToString() + "m";
        }
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void AddCoin()
    {
        scoreCoin++;         
        scoreCointxt.text = scoreCoin.ToString();
    }
}
