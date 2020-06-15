using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject panelWinGame,
        panelLoseGame,
        canvasUI;

    private Items itemsPlayer;

    void Start()
    {
        itemsPlayer = GameObject.FindWithTag("Character").GetComponent<Items>();

        panelWinGame = GameObject.Find("PanelWinGame");
        panelLoseGame = GameObject.Find("PanelLoseGame");
        canvasUI = GameObject.Find("Canvas");

        SetActiveRecursivelyExt(panelWinGame, false);
        SetActiveRecursivelyExt(panelLoseGame, false);
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemies.Length == 0)
            EndGame(true);

        if (itemsPlayer.health <= 0)
            EndGame(false);
    }

    private void EndGame(bool isWin)
    {
        if(isWin == true)
        {
            SetActiveRecursivelyExt(panelWinGame, true);
        } else
        {
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
