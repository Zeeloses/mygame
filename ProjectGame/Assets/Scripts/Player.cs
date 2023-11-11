using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public int keys = 0;
    public int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.A))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (lives > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                lives--;
            }
        }
        if (collision.gameObject.tag == "Door")
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Menu":
                    SceneManager.LoadScene("Level1");
                    break;
                case "Level1":
                    SceneManager.LoadScene("Level2");
                    break;
                case "Level2":
                    if (keys == 2)
                    {
                        SceneManager.LoadScene("Level3");
                    }
                    break;
                case "Level3":
                    SceneManager.LoadScene("Level4");
                    break;
                case "Level4":
                    SceneManager.LoadScene("Level5");
                    break;
                case "Level5":
                    SceneManager.LoadScene("Level6");
                    break;
                case "Level6":
                    SceneManager.LoadScene("Level7");
                    break;
                case "Level7":
                    SceneManager.LoadScene("Level8");
                    break;
                case "Level8":
                    SceneManager.LoadScene("Level9");
                    break;
                case "Level9":
                    SceneManager.LoadScene("Level10");
                    break;
            }
        }
        if (collision.gameObject.tag == "Key")
        {
            keys++;
            Destroy(collision.gameObject);
        }
    }
}
