using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
	private MenuAudio menuAudio;

	private void Start()
	{
		menuAudio = GetComponent<MenuAudio>();	
	}

	public void StartGame()
	{
		menuAudio.PlayStartSound();
		StartCoroutine(Wait());
		ChooseScene("Gymnasium");
	}

	public void ChooseScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	private IEnumerator Wait()
	{
		yield return new WaitWhile(()=> menuAudio.audioPlayer.isPlaying);
	}
}
