using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdMove : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D rigidbody2D;
    public bool isDead = false;
    private int point=0;
    public Text text;
    public Text highScoreText;
    public GameObject gameOverUI;
    public GameObject startUI;
    public GameObject resetScoreButton;

    //public Button btn;
    void Start()
    {
        Time.timeScale = 0;
        highScoreText.text = "HighScore:"+PlayerPrefs.GetInt("HighScore",0).ToString();
        startUI.SetActive(true);
        rigidbody2D = GetComponent<Rigidbody2D>();
       // btn = GetComponent<Button>();
       // btn.onClick.AddListener(Restart);
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isDead==false)
        {
            //Time.timeScale = 1;
            rigidbody2D.velocity = Vector2.up*velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isDead = true;
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            int number = addPoint();
            text.text = number.ToString();
            if (number>PlayerPrefs.GetInt("HighScore",0))
            {
                PlayerPrefs.SetInt("HighScore", number);
                highScoreText.text ="HighScore:"+ number.ToString();
            }
            
        }
    }
    public int addPoint()
    {
        point++;
        return point;
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
    public void TapScreen() 
    {
        Time.timeScale = 1;
        resetScoreButton.SetActive(false);
        startUI.SetActive(false);
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
