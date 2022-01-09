using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic.CompilerServices;

namespace idn.AnPhu.Website.Utils
{
    public class StringUtils : System.Web.UI.Page
    {
        public static string URLForHTML(string sServerURL)
        {
            string applicationPath = HttpContext.Current.Request.ApplicationPath;
            bool flag = sServerURL.StartsWith("~");
            string result;
            if (flag)
            {
                bool flag2 = Operators.CompareString(applicationPath, "/", false) == 0;
                if (flag2)
                {
                    result = applicationPath + sServerURL.Substring(2);
                }
                else
                {
                    result = applicationPath + sServerURL.Substring(1);
                }
            }
            else
            {
                result = sServerURL;
            }
            return result;
        }
        public static string galleryItemMB(string sRoot, string sClass, string name)
        {
            var sReturn = "";
            var i = 1;

            if (!(Directory.Exists(HttpContext.Current.Server.MapPath(sRoot + "/" + sClass + "/"))))
            {
                return "";
            }

            foreach (var sFile in Directory.GetFiles(HttpContext.Current.Server.MapPath(sRoot + "/" + sClass + "/"), "*_sum*.*"))
            {
                var fileText = HttpContext.Current.Server.MapPath(sRoot + "/" + sClass + "/" + Path.GetFileNameWithoutExtension(sFile) + "l.txt");
                if (File.Exists(fileText))
                {
                    string[] arrLine = File.ReadAllLines(fileText);
                    sReturn += "<li class='" + sClass + "' type='movie'><a onclick=\"return showGalleryLargeLayer(this,'" + arrLine[0] + "','" + arrLine[1] + "')\" href='#'>";
                }
                else
                {
                    var s = Path.GetFileName(sFile);
                    var fileName = "";
                    if (s != null)
                    {
                        fileName = s.Replace("_sum", "_");
                        if (fileName.IndexOf("gallery_") == -1)
                        {
                            fileName = fileName.Replace(".png", ".jpg");
                            if (fileName.IndexOf("exterior_") == 0)
                            {
                                fileName = fileName.Replace("exterior_", "exterior_4door_");
                            }
                        }
                    }
                    sReturn += "<div class='col-md-3 col-6 mt16'>";
                }
                sReturn += "<img src='" + URLForHTML(sRoot + sClass + "/" + Path.GetFileName(sFile)) + "'data-bs-toggle='modal' data-bs-target='#" +sClass + i+"'>" + "<div class='modal fade' id='" + sClass + i + "' tabindex='-1' aria-labelledby='exampleModalLabel' aria-hidden='true'><div class='modal-dialog'><div class='modal-content'><img src = '" + URLForHTML(sRoot + sClass + "/" + Path.GetFileName(sFile)) + "'><div class='close' data-bs-dismiss='modal'><i class='fas fa-times'></i></div></div></div></div></div>";
                i++;
            }
            return sReturn;
        }

        public static string File_Read(string sFileName)
        {
            bool flag = sFileName.StartsWith("~");
            if (flag)
            {
                sFileName = HttpContext.Current.Server.MapPath(sFileName);
            }
            flag = File.Exists(sFileName);
            string result;
            if (flag)
            {
                result = File.ReadAllText(sFileName);
            }
            else
            {
                result = null;
            }
            return result;
        }
    }
}