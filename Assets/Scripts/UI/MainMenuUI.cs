using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button closeStoryButton;
    [SerializeField] private Button openStoryButton;
    [SerializeField] private Button closeCreditsButton;
    [SerializeField] private Button openCreditsButton;
    [SerializeField] private GameObject creditsUI;
    [SerializeField] private GameObject storyUI;
    [SerializeField] private GameObject mainScreen;


    // Start is called before the first frame update

    private void Awake()
    {
        creditsUI.SetActive(false);
        storyUI.SetActive(false);

/*        startButton.onClick.AddListener(() => LoadingScreen.LoadScene("MainScene"));*/

        openCreditsButton.onClick.AddListener(() => { creditsUI.SetActive(true);
            mainScreen.SetActive(false);});
        closeCreditsButton.onClick.AddListener(() => { creditsUI.SetActive(false);
            mainScreen.SetActive(true); });

        openStoryButton.onClick.AddListener(() => { storyUI.SetActive(true);
            mainScreen.SetActive(false); });
        closeStoryButton.onClick.AddListener(() => { storyUI.SetActive(false);
            mainScreen.SetActive(true); });
    }
}
