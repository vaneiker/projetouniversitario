using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web.UI;

/// <summary>
/// Summary description for Utils
/// </summary>
public static class Utils
{
    /// <summary>
    /// Traer el SerialId 
    /// </summary>
    /// <returns>SerialId</returns>
    public static String GetSerialId()
    {
        return System.Guid.NewGuid().ToString().Replace("-", "").Substring(1, 12).ToUpper();
    }

    public static byte[] GetBytesFromFile(string fullFilePath)
    {
        FileStream fs = File.OpenRead(fullFilePath);
        try
        {
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return bytes;
        }
        finally
        {
            fs.Close();
        }
    }

    public static byte[] GetFileInfo(string fullFilePath)
    {
        FileStream fs = File.OpenRead(fullFilePath);
        try
        {
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return bytes;
        }
        finally
        {
            fs.Close();
        }
    }



    public static void SaveFile(string fileName, byte[] fileBytes)
    {
        using (FileStream file = new FileStream(fileName, FileMode.Create, System.IO.FileAccess.Write))
        {
            file.Write(fileBytes, 0, fileBytes.Length);
            file.Close();
        }
    }

    public static bool CreateFolder(string path)
    {
        if (Directory.Exists(path))
        {
            return true;
        }
        else
        {
            Directory.CreateDirectory(path);
            return false;
        }
    }

    public static void CreateLog(string fileName, string fileContent)
    {
        using (StreamWriter logfile = new StreamWriter(fileName, true))
        {
            logfile.WriteLine(fileContent);
            logfile.Close();
        }
    }
    /// <summary>
    ///  Author: Lic. Carlos Ml Lebron
    ///  Forza a renderizar las etiquetas thead y tfoooter en un gridview
    /// </summary>
    /// <param name="gv"></param>

    /// <summary>
    /// Validates wheather any items from array is null or empty
    /// </summary>
    /// <param name="arreglo"></param>
    /// <returns></returns>
    public static Boolean IsAnyNullOrEmpty(params object[] arreglo)
    {
        Boolean _result = false;
        Boolean _isString = false;
        for (int i = 0; i < arreglo.Length; i++)
        {
            if (arreglo[i].GetType() == typeof(string))
            {
                _isString = true;
                string value = (string)arreglo.GetValue(i);
                if (string.IsNullOrEmpty(value))
                {
                    _result = true;
                    break;
                }
                else
                    continue;
            }
        }
        return _result;
    }
    public static Boolean IsAnyNullOrEmpty(params string[] arreglo)
    {
        Boolean _result = false;
        Boolean _isString = false;
        for (int i = 0; i < arreglo.Length; i++)
        {
            _isString = true;
            string value = (string)arreglo.GetValue(i);
            if (string.IsNullOrEmpty(value))
            {
                _result = true;
                break;
            }
            else
                continue;
        }
        return _result;
    }

    public static string NullOrText(this TextBox textbox)
    {
        return string.IsNullOrEmpty(textbox.Text) ? null : textbox.Text;
    }
    public static string FirstCharToUpper(this string input)
    {
        if (String.IsNullOrEmpty(input))
            throw new ArgumentException("ARGH!");
        return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
    }
    public static int ToInt(this object value)
    {
        try
        {
            return Convert.ToInt32(value);
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public static short ToShort(this string value)
    {
        try
        {
            return short.Parse(value);
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public static char ToChar(this string value)
    {
        try
        {
            return char.Parse(value);
        }
        catch (Exception)
        {
            return default(char);
        }
    }
    public static byte[] ToBytes(string hex)
    {
        var shb = SoapHexBinary.Parse(hex);
        return shb.Value;
    }
    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        var seenKeys = new HashSet<TKey>();
        foreach (TSource element in source)
        {
            if (seenKeys.Add(keySelector(element)))
            {
                yield return element;
            }
        }
    }

    public static byte[] FileToByteArray(string _FileName)
    {

        byte[] _Buffer = null;

        try
        {
            // Open file for reading
            System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            // attach filestream to binary reader
            System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);

            // get total byte length of the file
            long _TotalBytes = new System.IO.FileInfo(_FileName).Length;

            // read entire file into buffer
            _Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);

            // close file reader
            _FileStream.Close();
            _FileStream.Dispose();
            _BinaryReader.Close();
        }
        catch (Exception _Exception)
        {
            // Error
            Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
        }

        return _Buffer;
    }
    //public static byte[] ToBytes(string hex)
    //{
    //    var shb = SoapHexBinary.Parse(hex.ToString());
    //    return shb.Value;
    //}
    //public static byte[] ToBytes(System.Data.Linq.Binary hex)
    //{
    //    var shb = SoapHexBinary.Parse(hex.ToString());
    //    return shb.Value;
    //}


    public static DateTime? ToNDate(this object value)
    {
        try
        {
            return Convert.ToDateTime(value);
        }
        catch (Exception)
        {
            return null;
        }
    }
    public static DateTime ToDate(this object value)
    {
        try
        {
            return Convert.ToDateTime(value);
        }
        catch (Exception)
        {
            return default(DateTime);
        }
    }
    public static DateTime ToDate(this string value)
    {
        try
        {
            return Convert.ToDateTime(value);
        }
        catch (Exception)
        {
            return default(DateTime);
        }
    }
    public static bool ToBool(this object value)
    {
        try
        {
            return Convert.ToBoolean(value);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public static Decimal ToDecimal(this object value)
    {
        try
        {
            return Convert.ToDecimal(value);
        }
        catch (Exception)
        {
            return default(Decimal);
        }
    }
    public static decimal DefaultValue(this decimal? ovalue)
    {
        return ovalue ?? 0;
    }
    public static DateTime DefaultValue(this DateTime? ovalue)
    {
        return ovalue ?? new DateTime(1899, 12, 30);
    }
    public static DateTime RemoveMonth(this DateTime? ovalue, int Months)
    {
        var result = new DateTime(1899, 12, 30);
        if (ovalue.HasValue)
            result = ovalue.Value.AddMonths(-Months);
        return result;
    }
    public static int DefaultValue(this int? ovalue)
    {
        return ovalue ?? 0;
    }
    public static bool DefaultValue(this bool? ovalue)
    {
        return ovalue ?? false;
    }
    public static bool IsRange(this int value, int range1, int range2)
    {
        return value >= range1 && value <= range2;
    }
    public static string DefaultValue(this string ovalue)
    {
        return (!String.IsNullOrEmpty(ovalue) ? ovalue : String.Empty);
    }
    public static float ToFloat(this int ovalue)
    {
        try
        {
            return (float)ovalue;
        }
        catch (Exception)
        {
            return default(float);
        }
    }  

    public static void MessageBox(this Control Ctrl, String Message, int? Width = 350, int? Height = null, Boolean isModal = true, String Title = "Alert")
    {
        if (Title == "Alert")
            Title = "Alert";
        var Func = string.Format("CustomDialogMessageEx('{0}',{1},{2},{3},'{4}');", Message, Width.HasValue ? Width.ToString() : "null", Height.HasValue ? Height.ToString() : "null", isModal.ToString().ToLower(), Title);
        ExcecuteJScript(Ctrl, Func);
    }

    public static void MessageBoxALIF(this Control Ctrl, String Message, int? Width = 350, int? Height = null, Boolean isModal = true, String Title = "Alert")
    {
        if (Title == "Alert")
            Title = "Alert";
        var Func = string.Format("CustomDialogMessageExALIF('{0}',{1},{2},{3},'{4}');", Message, Width.HasValue ? Width.ToString() : "null", Height.HasValue ? Height.ToString() : "null", isModal.ToString().ToLower(), Title);
        ExcecuteJScript(Ctrl, Func);
    }

    public static void ShowPopup(this Control Ctrl, OptionsPopup Settings)
    {

        Settings.panel.ClientIDMode = ClientIDMode.Static;
        Settings.hdn.ClientIDMode = ClientIDMode.Static;
        var Func = string.Format("JQueryPopup({" +
          "ElementIDorClass: '#{0}'" +
          "pautoOpen: {1}," +
          "pShowTitleBar:{2}," +
          "pTitle: '{3}'," +
          "pmodal: {4}," +
          "presizable:{5}," +
          "OnCLose: function () { $('#{6}').val('false'); }" +
          "});", Settings.panel.ID,
                 Settings.AutoOpen.ToString().ToLower(),
                 Settings.ShowTitleBar.ToString().ToLower(),
                 Settings.Title,
                 Settings.isModal.ToString().ToLower(),
                 Settings.resizable.ToString().ToLower(),
                 Settings.hdn.ID
                 );

        ExcecuteJScript(Ctrl, Func);
    }
    public static void ExcecuteJScript(this Control Container, string JScript)
    {
        var key = Guid.NewGuid().ToString();
        ScriptManager.RegisterStartupScript(Container.Page, Container.Page.GetType(), key, JScript, true);
    }
    public static void ShowMessage(Control control, string message, string title = null)
    {
        //string mensaje = string.Format("El pago ha sido realizado");
        string script = string.Format("CustomDialogMessage('{0}', '{1}')", string.Format(message), title);
        ScriptManager.RegisterStartupScript(control, typeof(Page), "CustomDialogMessage", script, true);
    }
        
    public static bool IsFull(this  VW_DATA_MARBETE item)
    {
        bool result = false;
        if (!string.IsNullOrEmpty(item.EsFull))
            if (item.EsFull.Contains("Si", StringComparison.OrdinalIgnoreCase))
                result = true;
        return result;
    }
    public static bool Contains(this string source, string toCheck, StringComparison comp)
    {
        return source.IndexOf(toCheck, comp) >= 0;
    }
    public class OptionsPopup
    {
        public Panel panel { get; set; }
        public Boolean AutoOpen { get; set; }
        public Boolean ShowTitleBar { get; set; }
        public String Title { get; set; }
        public bool isModal { get; set; }
        public bool resizable { get; set; }
        public HiddenField hdn { get; set; }
    }

}
