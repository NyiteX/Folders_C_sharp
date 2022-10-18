
Console.Write("Имя директории (C:/path): ");
string? dir = Console.ReadLine();
if (dir == "") dir = "C:\\";

Walk(new DirectoryInfo(dir));

void Walk(DirectoryInfo dir)
{
    FileInfo[]? files = null;
    DirectoryInfo[]? subDirs = null;   

    try
    {
        files = dir.GetFiles("*.*");
        subDirs = dir.GetDirectories();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    if (subDirs != null && files != null)
    {
        foreach (var fi in files)
            Console.WriteLine("     " + fi.FullName);

        foreach (var dirInfo in subDirs)
        {
            Console.WriteLine(dirInfo.Name);
            Walk(dirInfo);
        }
    }
}