using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPaused = false;

    private GameObject panelWinGame,
        panelLoseGame,
        canvasUI,
        panelPause;

    private Items itemsPlayer;

    void Start()
    {
        itemsPlayer = GameObject.FindWithTag("Character").GetComponent<Items>();

        panelWinGame = GameObject.Find("PanelWinGame");
        panelLoseGame = GameObject.Find("PanelLoseGame");
        canvasUI = GameObject.Find("Canvas");
        panelPause = GameObject.Find("PanelPause");

        SetActiveRecursivelyExt(panelWinGame, false);
        SetActiveRecursivelyExt(panelLoseGame, false);
        SetActiveRecursivelyExt(panelPause, false);
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemies.Length == 0)
            EndGame(true);

        if(itemsPlayer.health <= 0)
            EndGame(false);

        if(itemsPlayer.ammo == 0 && itemsPlayer.money < 10)
            EndGame(false);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                GameResume();
            }
            else
            {
                GamePause();
            }
        }
    }

    public void GameResume()
    {
        SetActiveRecursivelyExt(panelPause, false);
        SetActiveRecursivelyExt(canvasUI, true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void GamePause()
    {
        SetActiveRecursivelyExt(panelPause, true);
        SetActiveRecursivelyExt(canvasUI, false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void EndGame(bool isWin)
    {
        if(isWin == true)
        {
            FindObjectOfType<AudioManager>().Stop("EnemyAttack");
            //FindObjectOfType<AudioManager>().Play("WinGame");
            SetActiveRecursivelyExt(panelWinGame, true);
        } else
        {
            FindObjectOfType<AudioManager>().Stop("EnemyAttack");
            //FindObjectOfType<AudioManager>().Play("LoseGame");
            SetActiveRecursivelyExt(panelLoseGame, true);
        }
        
        SetActiveRecursivelyExt(canvasUI, false);
        Debug.Log("Game has End!");
    }

    private void SetActiveRecursivelyExt(GameObject obj, bool state)
    {
        obj.SetActive(state);
        foreach (Transform child in obj.transform)
        {
            SetActiveRecursivelyExt(child.gameObject, state);
        }
    }
}
