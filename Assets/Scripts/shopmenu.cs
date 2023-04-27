// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class shopmenu : MonoBehaviour
// {
//     public static bool Shopping = false;
//     public GameObject shopMenuUI;
//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Escape))
//         {
//             if (Shopping)
//             {
//                 Resume();
//             } else
//             {
//                 Pause();
//             }
//         }
//     }

//     public void Resume()
//     {
//         shopMenuUI.SetActive(false);
//         Time.timeScale = 1f;
//         GameIsPaused = false;
//     }

//     public void Shop()
//     {
//         shopMenuUI.SetActive(true);
//         Time.timeScale = 0f;
//         Shopping = true;
//     }

//     public void LoadMenu()
//     {
//         Time.timeScale = 1f;
//         SceneManager.LoadScene("Menu");
//     }

//     public void QuitGame()
//     {
//         Application.Quit();
//     }
// }
