using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOnCollision : MonoBehaviour
{
    public string GameOverLevel;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.isTrigger)
        {
            SceneManager.LoadScene(GameOverLevel);
        }
    }
}
