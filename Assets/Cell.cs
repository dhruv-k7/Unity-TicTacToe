using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public int index;
    public TextMeshProUGUI cellText;
    public void OnClick()
    {
        GameManager.Instance.CellClicked(index);
    }
}
