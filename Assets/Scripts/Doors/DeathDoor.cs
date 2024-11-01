using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathDoor : MonoBehaviour
{
    public Behaviour deathScreen;
    [SerializeField]
    private float delay = 1f;

     void Start()
    {
        deathScreen.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            deathScreen.enabled = true;
            StartCoroutine(ActionDelay(other));
        }
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator ActionDelay(Collider player)
    {
        yield return new WaitForSeconds(delay);
        ReloadCurrentScene();
    }
}
