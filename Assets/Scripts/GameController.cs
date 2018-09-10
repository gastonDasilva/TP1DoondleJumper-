using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


    public float parallaxVelocidad = 0.02f;
    public RawImage background;
    public Text pointText;
    public Text recordText;
    private int points = 0;


    // Use this for initialization
    void Start () {
        recordText.text = "Best: " + GetMaxScore().ToString();
    }
	
	// Update is called once per frame
	void Update () {
        this.Parallax();
    }

    public void IncreasePoint( float puntos)
    {
        if (puntos >= 0 && puntos > points)
        {
            points = (int)puntos;
            pointText.text = points.ToString();
            //SaveScore(points);
        }
        int p = (int)puntos;
        if (p >= GetMaxScore())
        {
            recordText.text = "Best: " + p.ToString();
            SaveScore(p);
        }
    }

    public void RestarGame()
    {
        SceneManager.LoadScene("Principal");
    }

    void Parallax()
    {
        float finalSpeed = parallaxVelocidad * Time.deltaTime;
        background.uvRect = new Rect(0f,background.uvRect.y + finalSpeed, 1f, 1f);
    }

    public int GetMaxScore()
    { // devuelve el score maximo que el jugador pudo lograr
        return PlayerPrefs.GetInt("Max Points", 0);
    }

    public void SaveScore(int currentPoint)
    {// guarda el score que el jugador logro
        PlayerPrefs.SetInt("Max Points", currentPoint);
    }
}
