using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (int sceneNumer)
	{
		Brick.brickCount = 0;
        SceneManager.LoadScene(sceneNumer);
	}

	public void QuitRequest ()
	{
        Application.Quit();
	}

	public void LoadNextLevel()
	{
		Brick.brickCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
	}

	public void BrickDestroyed()
	{
		if (Brick.brickCount <= 0) {
			LoadNextLevel();
		}
	}

}
