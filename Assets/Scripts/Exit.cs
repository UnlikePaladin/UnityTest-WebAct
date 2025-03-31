using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Exit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        Debug.Log("Uploading now:");
        string apiURL = Constants.API_URL + UIManager.player.user_id;
        Debug.Log(apiURL);
        string jsonData = JsonUtility.ToJson(UIManager.player);
        //byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonData);
        //UploadHandlerRaw upHandler = new UploadHandlerRaw(data);
        Debug.Log("JSON-> " + jsonData);
        using (UnityWebRequest web = UnityWebRequest.Put(apiURL, jsonData))
        {
            web.method = UnityWebRequest.kHttpVerbPUT;
            //web.useHttpContinue = false;
            //web.uploadHandler = (UploadHandler)new UploadHandlerRaw(body);
            //web.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            web.SetRequestHeader("Content-type", "application/json");
            web.SetRequestHeader("Accept", "application/json");
            yield return web.SendWebRequest();

            if (web.result == UnityWebRequest.Result.ConnectionError || web.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(web.error);
            }
            else
            {
                Debug.Log("Upload complete!");
            }
        }
    }
}
