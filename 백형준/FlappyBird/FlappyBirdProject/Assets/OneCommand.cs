using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OneCommand : MonoBehaviour {

    public GameObject Column, Floor, White, Quit;
    public AudioSource BirdSound_1, BirdSound_2, BirdSound_3, BirdSound_4;
    public Text Score;

    Rigidbody2D rig;
    float NextTime = 0;
    int i, j, BestScore = 0;
    bool Stop = false;
    GameObject[] gameObjects = new GameObject[3];
   

	void Start () {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(Vector3.up * 270);
        BirdSound_1.Play();
	}

    void Update()
    {
        // 뒤로가기
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        // 새
        GetComponent<Animator>().SetFloat("Velocity", rig.velocity.y);
        if (transform.position.y > 4.75f) transform.position = new Vector3(-1.5f, 4.75f, 0f);
        if (transform.position.y < -2.55f)
        {
            rig.simulated = false;
            GameOver();
        }
        if (rig.velocity.y > 0) transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.z, 30f, rig.velocity.y / 8f));
        else transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.z, -90f, -rig.velocity.y / 8f));

        if (Stop) return;

        if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            rig.velocity = Vector3.zero;
            rig.AddForce(Vector3.up * 270);
            BirdSound_1.Play();
        }

        // 기둥생성기
        if (Time.time > NextTime)
        {
            NextTime = Time.time + 1.7f;
            gameObjects[j] = (GameObject)Instantiate(Column, new Vector3(4, Random.Range(-1f, 3.2f), 0), Quaternion.identity);
            if (++j == 3) j = 0;
        }
        if (gameObjects[0])
        {
            gameObjects[0].transform.Translate(-0.03f, 0, 0);
            if (gameObjects[0].transform.position.x < -4) Destroy(gameObjects[0]);
        }
        if (gameObjects[1])
        {
            gameObjects[1].transform.Translate(-0.03f, 0, 0);
            if (gameObjects[1].transform.position.x < -4) Destroy(gameObjects[1]);
        }
        if (gameObjects[2])
        {
            gameObjects[2].transform.Translate(-0.03f, 0, 0);
            if (gameObjects[2].transform.position.x < -4) Destroy(gameObjects[2]);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // 점수
        if (col.gameObject.name == "Column(Clone)")
        {
            Score.text = (++i).ToString();
            BirdSound_2.Play();
        }
        else if (!Stop)
        {
            rig.velocity = Vector3.zero;
            BirdSound_4.Play();
            GameOver();
        }
    }

    void GameOver()
    {
        // 게임오버
        if (!Stop) BirdSound_3.Play();
        Stop = true;
        Floor.GetComponent<Animator>().enabled = false;
        White.SetActive(true);
        Score.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("BestScore", 0) < int.Parse(Score.text)) PlayerPrefs.SetInt("BestScore", int.Parse(Score.text));
        if (transform.position.y < -2.55f)
        {
            Quit.SetActive(true);
            Quit.transform.Find("ScoreScreen").GetComponent<Text>().text = Score.text;
            Quit.transform.Find("BestScreen").GetComponent<Text>().text = PlayerPrefs.GetInt("BestScore").ToString();
        }
    }

    public void Restart()
    {
        // 재시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
