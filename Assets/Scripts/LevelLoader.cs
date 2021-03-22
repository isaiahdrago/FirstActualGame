using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator Transition;

    public Animator DoorOpen;

    public float WaitTime = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        DoorOpen.SetTrigger("TouchDoor");
        yield return new WaitForSeconds(WaitTime / 2);
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(WaitTime / 2);
        SceneManager.LoadScene(levelIndex);
    }
}
