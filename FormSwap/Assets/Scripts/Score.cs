using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private Transform player;
    private Text score;

    [SerializeField]
    private Text deadMenuScore;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        score = GetComponent<Text>();
    }

    private void Update()
    {
        score.text = player.position.x.ToString("0");
        deadMenuScore.text = player.position.x.ToString("0");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
