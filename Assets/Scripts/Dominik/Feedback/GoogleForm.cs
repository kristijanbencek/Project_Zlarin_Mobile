using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleForm : MonoBehaviour
{
    UnityWebRequest checkForNet;

    public GameObject feedbackArea;
    public GameObject username;
    public GameObject netErrorText;
    public GameObject notLongEnoughError;
    //public TMPro.TMP_Text noNetText;

    private string Name;
    private int longtitude;//use when Josip done
    private int latitude;//use when Josip done


    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSf7vdQj2QB9fcGAm-CaflNuPdfIUGanAlJkqcA--7wl8H4AcA/formResponse";//Dominikov form
    [SerializeField]
    private string NewTestURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSclSMrNwXlYS3WPd3j9toulIhMW3WHcCvK4y4EMmwcudcpw8A/formResponse";//Josipov form
    [SerializeField]
    private string FormBiologa;
    [SerializeField]
    private string ZlarinFormTest = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSefi7msAyduD3S7Rh4fl2LBlRvsIZX3AdqPIvDuv6mUvuk-Yg/formResponse";
    IEnumerator Post(string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.915033428", name);

        UnityWebRequest www = UnityWebRequest.Post(ZlarinFormTest, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            StartCoroutine(NetError());
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
            feedbackArea.SetActive(false);
        }
    }
    public void Send()
    {
        Name = username.GetComponent<TMPro.TMP_InputField>().text;
        if (Name.Length > 15)
        {
            StartCoroutine(Post(Name));
        }
        else
        {
            StartCoroutine(nameof(NotLongEnough));
        }
    }
    IEnumerator NetError()
    {
        netErrorText.SetActive(true);
        //noNetText.text = "Turn you internet on to send feedback!";
        yield return new WaitForSeconds(4);
        //noNetText.text = " ";
        netErrorText.SetActive(false);
    }
    IEnumerator NotLongEnough()
    {
        notLongEnoughError.SetActive(true);
        Debug.Log("Write a longer feedback");
        yield return new WaitForSeconds(4);
        notLongEnoughError.SetActive(false);
       
    }
}
