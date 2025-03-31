using System;
using UnityEngine;

[Serializable]
public class User
{
    public int user_id;
    public string username;
    public string first_name;
    public string last_name;
    public string birthdate;
	public string password;
    public string email;
    public int points;

    public static User CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<User>(jsonString);
    }
}
