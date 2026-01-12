using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceObjectSetting : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TMP_Text nameText, explainText;
    [SerializeField] BallState ballStates;
    private BallState thisBallState;
    [SerializeField] GetBall getBall;
    public void SetChoiceObject(BallState ballState)
    {
        thisBallState = ballState;
        image.sprite = thisBallState.ballImage;
        nameText.text = thisBallState.ballName;
        explainText.text = thisBallState.ballExplain;
    }

    public void SpawnBall()
    {
        Instantiate(thisBallState.ballPrefab, new Vector3(0, -300, 0), Quaternion.identity);
        getBall.ChoiceClose();

    }
}