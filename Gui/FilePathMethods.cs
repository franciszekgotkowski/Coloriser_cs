namespace Gui;

public static class FilePathMethods {
    public static string NewFileWithPath(
        string path
    ) {
        int startnum = 0;

        string fullPath = Path.GetDirectoryName(path);
        string file = Path.GetFileNameWithoutExtension(path);
        string ext = Path.GetExtension(path);

        string newPath = Path.Combine(fullPath, $"{file}({startnum}){ext}");
        while (File.Exists(newPath)) {
            startnum++;
            newPath = Path.Combine(fullPath, $"{file}({startnum}){ext}");
        }

        return newPath;
    }
    public static string NewFileWithoutPath(
        string path
    ) {
        return Path.GetFileName(NewFileWithPath(path));
    }
}