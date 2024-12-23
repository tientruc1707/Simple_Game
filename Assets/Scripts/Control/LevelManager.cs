
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;

    void Start()
    {
        for (int i = 0; i < levelButtons.Length; ++i)
        {
            int level = i + 1;
            levelButtons[i].onClick.AddListener(() => LoadLevelReached(level));
            if (level > DataManager.Instance.GetLevel())
                levelButtons[i].interactable = false;
        }
    }
    public void LoadLevelReached(int lv)
    {
        DataManager.Instance.ResetData();
        SceneManager.LoadScene("Level " + lv);
    }
    void OnDrawGizmosSelected()
    {
        levelButtons = GetComponentsInChildren<Button>();
        for (int i = 0; i < levelButtons.Length; ++i)
        {
            levelButtons[i].name = "Level " + (i + 1).ToString();
        }
    }
}
