namespace LlavesquiPoems.Application.Helpers;

public static class EncodeFileHelper
{

    public static string GetBase64File(string path)
    {
        path = Environment.CurrentDirectory + path;
        byte[] bytes = File.ReadAllBytes(path);
        string file = Convert.ToBase64String(bytes);
        return file;
    }
    public static string GetUriFile(string path)
    {
        path = Environment.CurrentDirectory + path;

        return path;
    }
}