namespace TodoApp.Shared.Helpers;

public class StringHelper
{
    public string StringReplace(string text)
    {
        text = text.Replace("İ", "I");
        text = text.Replace("ı", "i");
        text = text.Replace("Ğ", "G");
        text = text.Replace("ğ", "g");
        text = text.Replace("Ö", "O");
        text = text.Replace("ö", "o");
        text = text.Replace("Ü", "U");
        text = text.Replace("ü", "u");
        text = text.Replace("Ş", "S");
        text = text.Replace("ş", "s");
        text = text.Replace("Ç", "C");
        text = text.Replace("ç", "c");
        text = text.Replace(" ", "-");
        return text;
    }
    /// <summary>
    /// Seo dostu url üretmeye yardımcı olur
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string ToUrlFriendly(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

        // Türkçe karakterleri İngilizce karşılıklarına çevir  
        text = text.ToLowerInvariant();
        text = text.Replace("ı", "i")
                  .Replace("ğ", "g")
                  .Replace("ü", "u")
                  .Replace("ş", "s")
                  .Replace("ö", "o")
                  .Replace("ç", "c")
                  .Replace(" ", "-")
                  .Replace(".", "")
                  .Replace(",", "")
                  .Replace("'", "")
                  .Replace("\"", "")
                  .Replace("?", "")
                  .Replace("!", "")
                  .Replace("(", "")
                  .Replace(")", "")
                  .Replace("[", "")
                  .Replace("]", "")
                  .Replace("{", "")
                  .Replace("}", "")
                  .Replace("/", "")
                  .Replace("\\", "")
                  .Replace("+", "")
                  .Replace("*", "")
                  .Replace("&", "")
                  .Replace("#", "")
                  .Replace("%", "")
                  .Replace("^", "")
                  .Replace("|", "");

        // Geçersiz karakterleri kaldır  
        text = Regex.Replace(text, @"[^a-z0-9\s-]", string.Empty);

        // Boşlukları ve birden fazla tireyi düzenle  
        text = Regex.Replace(text, @"\s+", " ").Trim(); // Fazla boşlukları tek boşluğa indir  
        text = text.Replace(" ", "-"); // Boşlukları tire ile değiştir  

        // Birden fazla tireyi tek bir tireye indir  
        text = Regex.Replace(text, @"-+", "-");

        return text;
    }
}
