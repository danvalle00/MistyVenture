using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointLevelChanger : MonoBehaviour
{
    private MistyHurting hurtScript;
    public string sceneToLoad = "cena2";
    void Start()
    {
        hurtScript = GetComponent<MistyHurting>();
        SceneManager.UnloadSceneAsync(sceneToLoad);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assegura-se de que é o personagem do jogador que está interagindo
        {
            // Verifica se a cena já foi carregada
            if (!SceneManager.GetSceneByName(sceneToLoad).isLoaded)
            {
                SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);  // Carrega a cena de maneira aditiva
            }

            StartCoroutine(UnloadPreviousScene());
        }
    }

    IEnumerator UnloadPreviousScene()
    {
        yield return null;  // Aguarda até o próximo frame para garantir que a nova cena foi carregada

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (!scene.name.Equals(sceneToLoad))  // Não descarrega a nova cena
            {
                yield return SceneManager.UnloadSceneAsync(scene);  // Descarrega a cena anterior
            }
        }
    }
}
