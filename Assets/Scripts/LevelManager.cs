using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Text gameText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelBeat()
    {
        gameText.text = "YOU WIN!";
        gameText.gameObject.SetActive(true);
    }

    public void LevelLost()
    {
        gameText.text = "YOU LOST!";
        gameText.gameObject.SetActive(true);
    }
}
