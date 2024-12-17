using Models;
using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class APIReader : MonoBehaviour
{
    private readonly string basePath = "https://retoolapi.dev/RtYaFH/data";
    public UserData[] users;

    public UserData userData;
    [Space]
    [Space]
    [SerializeField] TMP_InputField userSignUpField;
    [SerializeField] TMP_InputField passSignUpField;
    [SerializeField] TMP_InputField confPassSignUpField;
    [SerializeField] TMP_InputField classSignUpField;
    [Space]
    [Space]
    [SerializeField] TMP_InputField userLogInField;
    [SerializeField] TMP_InputField passLogInField;
    [Space]
    [Space]
    [SerializeField] TMP_InputField userChangeField;
    [SerializeField] TMP_InputField oldPassChangeField;
    [SerializeField] TMP_InputField newPassChangeField;


    public void Start()
    {
        Get();

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Post();
        }
        

    }

    public void Get()
    { 
        RestClient.Get(basePath).Then(response =>
        {
            try
            {
                string jsonResponse = response.Text;
                users = JsonHelper.ArrayFromJson<UserData>(jsonResponse);   

                if(users!= null) {
                    Debug.Log("Number of users : " + users.Length);
                }
                
            }
            catch (Exception ex)
            {
                Debug.Log(ex + "User array is null");
            }

        }).Catch(error => { 
            Debug.Log(error.Message);
        }

        );
    }

    public void Post()
    {
        RestClient.Post(basePath, userData).Then(response =>
        {
            try
            {
                if (response != null)
                {
                    Debug.Log("Successful");
                }
                else
                {
                    Debug.Log("No Response");
                }

            }
            catch (Exception ex)
            {
                Debug.Log(ex + "Error posting UserData");
            }

        }).Catch(error => {
            Debug.Log(error.Message);
        }

        );
    }

    public void DeleteUser(int userId)
    {
        RestClient.Delete(basePath + "/"+ userId).Then(response =>
        {
            try
            {
                if (response != null)
                {
                    Debug.Log("Deleted Successfully");
                }
                else
                {
                    Debug.Log("No Response");
                }

            }
            catch (Exception ex)
            {
                Debug.Log(ex + "Error posting UserData");
            }

        }).Catch(error => {
            Debug.Log(error.Message);
        }

           );
    }

    public void PatchUser()
    {
        RestClient.Patch(basePath + "/" + userData.id,userData).Then(response =>
        {
            try
            {
                if (response != null)
                {
                    Debug.Log("Patched Successfully");
                }
                else
                {
                    Debug.Log("No Response");
                }

            }
            catch (Exception ex)
            {
                Debug.Log(ex + "Error Patching UserData");
            }

        }).Catch(error => {
            Debug.Log(error.Message);
        }

   );
    }

    public void SignUp()
    {
        Get();
        foreach (UserData data in users)
        {
            if (userSignUpField.text == data.Username)
            {
                Debug.Log("meron na nyan");
                return;
            }
        }

        userData.Username = userSignUpField.text;
        userData.Class = classSignUpField.text;
        if (confPassSignUpField.text == passSignUpField.text)
        {
            userData.Password = confPassSignUpField.text;
            userData.id = users.Length +1;
            Post();
        }
        else
        {
            Debug.Log("incorrect");
        }
        Get();
    }

    public void LogIn()
    {
        Get();
        foreach (UserData data in users)
        {
            if(userLogInField.text == data.Username)
            {
                if(passLogInField.text == data.Password)
                {
                    Debug.Log("Correct!");
                }
                else
                {
                    Debug.Log("Wrong Password");
                }
            }
            else
            {
                Debug.Log("Wrong Username");
            }
        }
    }

    public void ChangePassword()
    {
        Get();
        foreach (UserData data in users)
        {
            if (userChangeField.text == data.Username)
            {
                if (oldPassChangeField.text == data.Password)
                {
                    if (oldPassChangeField.text == newPassChangeField.text)
                    {
                        return;
                    }
                    else
                    {
                        userData.id = data.id;
                        userData.Username = userChangeField.text;
                        userData.Password = newPassChangeField.text;
                        userData.Class = data.Class;
                        PatchUser();
                    }
                }
                else
                {
                    Debug.Log("Wrong Password");
                }
            }
            else
            {
                Debug.Log("Wrong Username");
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
