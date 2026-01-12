using System.Collections.Generic;
using UnityEngine;
public class GetBall : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    public List<BallState> ballStates;
    public GameObject choiceObject;
    public List<ChoiceObjectSetting> choiceObjectSetting;
    public void Start()
    {
        gameState.deleteBlockEvent.AddListener(BallChoice);
    }

    public void BallChoice()
    {
        choiceObject.SetActive(true);
        for (int i = 0; i < choiceObjectSetting.Count; i++)
        {
            choiceObjectSetting[i].SetChoiceObject(ballStates[Random.Range(0, ballStates.Count)]);
        }
        Time.timeScale = 0;
    }

    public void ChoiceClose()
    {
        choiceObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void BallSpwan()
    {
        Instantiate(ballStates[Random.Range(0, ballStates.Count)].ballPrefab, new Vector3(0, -300, 0), Quaternion.identity);
    }
}