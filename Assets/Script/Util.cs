using System;

public static class Util
{
    public static bool CheckUserID(string id)
    {
        return (id.Length >= Global.MIN_ID_LENGTH) && (id.Length <= Global.MAX_ID_LENGTH); 
    }
    
    public static bool CheckUserPassword(string pass)
    {
        return (pass.Length >= Global.MIN_PASSWORD_LENGTH) && (pass.Length <= Global.MAX_PASSWORD_LENGTH);
    }
}
