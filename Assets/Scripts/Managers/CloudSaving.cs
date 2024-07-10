
//using System.Diagnostics;
using System;
using UnityEngine;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using Unity.Services.Core;
using System.Collections.Generic;
using Unity.Services.CloudSave;
using Unity.Services.CloudSave.Models;

//using System.Diagnostics.Eventing.Reader;
//using System.Diagnostics;
//using System.Diagnostics;
//using System.Diagnostics.Eventing.Reader;
public class CloudSaving : MonoBehaviour
{
    async void Awake()
    {
        try
        {
            await UnityServices.InitializeAsync();
            await SignInAnonymouslyAsync();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }




    async Task SignInAnonymouslyAsync()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            //  Debug.Log("Sign in anonymously succeeded!");

            // Shows how to get the playerID
            //  Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }

    public async static void SaveData<T>(T inData, string key)
    {
        var data = new Dictionary<string, object> { { key, inData } };
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
    }


    public async static Task<T> LoadData<T>(string key)
    {
        Dictionary<string, string> playerData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { key });


        var dataString = playerData[key];

        var data = JsonUtility.FromJson<T>(dataString);
        Debug.Log("Done: " + playerData[key]);

        /*   if (playerData.TryGetValue("keyName", out var keyName))
           {
               Debug.Log($"keyName: {keyName.Value.GetAs<string>()}");
           }*/

        return data;
    }
}