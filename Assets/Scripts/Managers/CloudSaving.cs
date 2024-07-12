using System;
using UnityEngine;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using Unity.Services.Core;
using System.Collections.Generic;
using Unity.Services.CloudSave;
using Unity.Services.CloudSave.Models;
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
        return data;
    }
}