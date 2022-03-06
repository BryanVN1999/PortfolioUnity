using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject DialogPanel;
    [SerializeField] private Text textDialog;
    [SerializeField] private UnityEvent EndDialog;
    private void Awake() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ShowDialoguePanel()
    {
        DialogPanel.SetActive(true);
    }
    public void StartDialogCoroutine(DialogScriptableObject DSO)
    {
        StartCoroutine(TextAnimation(DSO));
    }
    public void OpenDoor(Animator door)
    {
        door.SetBool("open",!door.GetBool("open"));
    }
    private IEnumerator TextAnimation(DialogScriptableObject DSO)
    {
        List<string> phrases = DSO.phrases;
        for (int i = 0; i < phrases.Count; i++)
        {
            for (int j = 0; j < phrases[i].Length; j++)
            {
                textDialog.text += phrases[i][j];
                yield return new WaitForSeconds(0.02f);
                /*if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
                {
                    textDialog.text = phrases[i];
                    break;
                }*/
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"));
            textDialog.text = "";
        }
        Debug.Log("FIN CONVERSACION");
        EndDialog.Invoke();
    }
}
