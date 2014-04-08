using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing.Drawing2D;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;

namespace RnD.KendoUISample.Helpers
{
    public static class FileUtility
    {
        #region File Save, Copy Move, Delete

        public static string SaveFile(HttpPostedFileBase fileUpload, out string strErrMsg)
        {
            strErrMsg = "";
            try
            {
                string sDirPath = HttpContext.Current.Server.MapPath("~/UploadedFiles");
                string sFilePath = "";
                //Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), Path.GetFileName(fileUpload.FileName));

                if (!Directory.Exists(sDirPath))
                {
                    Directory.CreateDirectory(sDirPath);
                }

                sFilePath = DateTime.Now.Ticks.ToString() + "__" + fileUpload.FileName;
                sFilePath = Path.Combine(sDirPath, sFilePath);

                fileUpload.SaveAs(sFilePath);

                return sFilePath;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
            }

            return "";
        }

        public static bool CopyFile(string strFromFilePath, string strToFilePath, out string strErrMsg)
        {
            strErrMsg = "";
            if (!string.IsNullOrEmpty(strFromFilePath) && System.IO.File.Exists(strFromFilePath)
                && !string.IsNullOrEmpty(strToFilePath))
            {
                try
                {
                    bool a = System.IO.Directory.Exists(strToFilePath);
                    System.IO.File.Copy(strFromFilePath, strToFilePath, true);
                    return true;
                }
                catch (Exception ex)
                {
                    strErrMsg = "Could not Copy File! <br />" + ex.Message;
                    return false;
                }
            }
            strErrMsg = "Source File not Found!";
            return false;
        }

        public static bool MoveFile(string strFromFilePath, string strToFilePath, out string strErrMsg)
        {
            strErrMsg = "";
            if (!string.IsNullOrEmpty(strFromFilePath) && System.IO.File.Exists(strFromFilePath)
                && !string.IsNullOrEmpty(strToFilePath))
            {
                try
                {
                    string strToFileDir = Path.GetDirectoryName(strToFilePath);
                    if (!string.IsNullOrEmpty(strToFileDir) && !System.IO.Directory.Exists(strToFileDir))
                        System.IO.Directory.CreateDirectory(strToFileDir);

                    System.IO.File.Move(strFromFilePath, strToFilePath);
                    return true;
                }
                catch (Exception ex)
                {
                    strErrMsg = "Could not Move File! <br />" + ex.Message;
                    return false;
                }
            }
            strErrMsg = "Source File not Found!";
            return false;
        }

        public static bool DeleteFile(string strFilePath, out string strErrMsg)
        {
            strErrMsg = "";
            if (System.IO.File.Exists(strFilePath))
            {
                try
                {
                    System.IO.File.Delete(strFilePath);
                    return true;
                }
                catch (Exception ex)
                {
                    strErrMsg = "Could not Delete File! <br />" + ex.Message;
                    return false;
                }
            }
            strErrMsg = "File not Found!";
            return false;
        }

        private static void DeleteAllFileHelper(string strDirectory)
        {
            if (Directory.Exists(strDirectory))
                Array.ForEach(Directory.GetFiles(strDirectory), File.Delete);
        }

        #endregion

        #region Image Upload, Resize

        /// <summary>
        /// Uploads an Image file, size less than 1MB and Returns the file saved location
        /// </summary>
        /// <param name="fileUpload">File upload control</param>
        /// <param name="image">Optional send an image control to show the image after upload</param>
        /// <param name="editMode">add or edit mode</param>
        /// <param name="existingFileName">Target file path</param>
        /// <param name="strErrMsg">to return error message</param>
        /// <returns></returns>
        public static string SaveImage(FileUpload fileUpload, System.Web.UI.WebControls.Image image, string editMode,
                                       out string existingFileName, out string strErrMsg)
        {
            existingFileName = strErrMsg = "";
            string saveFolderPath = "";
            string saveFilePath = "";
            try
            {
                if (fileUpload.HasFile)
                {
                    saveFolderPath = "~/UploadedFiles";
                    string postedFileName = fileUpload.PostedFile.FileName;
                    long sizeInMB = fileUpload.PostedFile.ContentLength / (1024 * 1024);

                    if (sizeInMB < 1)
                    {
                        string imgName = "";
                        if (editMode == "add")
                        {
                            Guid guidImg3 = System.Guid.NewGuid();
                            imgName = guidImg3.ToString();
                        }
                        else
                        {
                            if (existingFileName != string.Empty)
                            {
                                imgName = existingFileName.Substring(existingFileName.LastIndexOf('\\'),
                                                                     existingFileName.LastIndexOf('.') -
                                                                     existingFileName.LastIndexOf('\\'));
                            }
                            else
                            {
                                Guid guidImg3 = System.Guid.NewGuid();
                                imgName = guidImg3.ToString();
                            }
                        }

                        string postedFileType = postedFileName.Substring(postedFileName.LastIndexOf('.'));
                        imgName += postedFileType;
                        saveFilePath = HttpContext.Current.Server.MapPath(saveFolderPath) + imgName;
                        try
                        {
                            fileUpload.PostedFile.SaveAs(saveFilePath);
                            System.Drawing.Image original = System.Drawing.Image.FromFile(saveFilePath);

                            using (System.Drawing.Image resized = ResizeImage(original, new Size(256, 192), true))
                            {
                                original.Dispose();
                                original = null;

                                if (File.Exists(saveFilePath))
                                {
                                    File.Delete(saveFilePath);
                                }

                                resized.Save(saveFilePath);
                                if (image != null)
                                    image.ImageUrl = saveFolderPath + imgName;

                                existingFileName = "~/UploadedFiles" + imgName;
                            }
                        }
                        catch (Exception ex)
                        {
                            strErrMsg = "Invalid file entered! <BR />" + ex.Message;
                        }
                    }
                    else
                    {
                        strErrMsg = "Please select an image less than 1 MB.";
                    }
                }
                else
                {
                    strErrMsg = "File not found!";
                }
            }
            catch (Exception ex)
            {
                strErrMsg = "File could not be uploaded! <br/>" + ex.Message;
            }

            return saveFilePath;
        }

        public static System.Drawing.Image ResizeImage(System.Drawing.Image image, Size size, bool preserveAspectRatio)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }

            System.Drawing.Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.CompositingQuality = CompositingQuality.HighSpeed;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        #endregion

    }

    public static class ExportUtility
    {
        #region Export GenericList to CSV

        public static void ExportGenericListToCSV<T>(this List<T> list, string filename)
        {
            if (list != null && list.Count > 0)
            {
                string csv = GetCsvFromGenericList(list);
                ExportCSVHelper(csv, filename);
            }
        }

        private static string GetCsvFromGenericList<T>(this List<T> list)
        {
            StringBuilder sb = new StringBuilder();

            //Get the properties for type T for the headers
            PropertyInfo[] propInfos = typeof(T).GetProperties();
            for (int i = 0; i <= propInfos.Length - 1; i++)
            {
                sb.Append(propInfos[i].Name);

                if (i < propInfos.Length - 1)
                {
                    sb.Append(",");
                }
            }

            sb.AppendLine();

            //Loop through the collection, then the properties and add the values
            for (int i = 0; i <= list.Count - 1; i++)
            {
                T item = list[i];
                for (int j = 0; j <= propInfos.Length - 1; j++)
                {
                    object o = item.GetType().GetProperty(propInfos[j].Name).GetValue(item, null);
                    if (o != null)
                    {
                        string value = o.ToString();

                        //Check if the value contans a comma and place it in quotes if so
                        if (value.Contains(","))
                        {
                            value = string.Concat("\"", value, "\"");
                        }

                        //Replace any \r or \n special characters from a new line with a space
                        if (value.Contains("\r"))
                        {
                            value = value.Replace("\r", " ");
                        }
                        if (value.Contains("\n"))
                        {
                            value = value.Replace("\n", " ");
                        }

                        sb.Append(value);
                    }

                    if (j < propInfos.Length - 1)
                    {
                        sb.Append(",");
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        #endregion

        #region Export DataTable to CSV, Excel, XML

        [Obsolete]
        public static void ExportDataTableToHtmlExcel(DataTable dt, string strFileName)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                //Get the HTML for the control.
                System.Web.UI.WebControls.DataGrid dgGrid = new System.Web.UI.WebControls.DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();
                dgGrid.RenderControl(hw);

                //Write the HTML back to the browser.
                //HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                //HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                //HttpContext.Current.Response.Write(tw.ToString());
                //HttpContext.Current.Response.End();
                ExportCSVHelper(tw.ToString(), strFileName);
            }
        }

        public static void ExportDataTableToCSV(DataTable dt, string strFileName)
        {
            StringBuilder sb = new StringBuilder();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append(column.ColumnName + ",");
                }
                sb.AppendLine();

                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sb.Append(row[i].ToString().Replace(",", ";") + ",");
                    }
                    sb.AppendLine();
                }

                ExportCSVHelper(sb.ToString(), strFileName);
            }
        }

        #endregion

        #region Export DataSet to CSV, Excel, XML

        public static void ExportDataSetToCSV(DataSet ds, string strFileName)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        sb.Append(column.ColumnName + ",");
                    }

                    sb.AppendLine();

                    foreach (DataRow row in table.Rows)
                    {
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            sb.Append(row[i].ToString().Replace(",", ";") + ",");
                        }

                        sb.AppendLine();
                    }

                    sb.AppendLine();
                    sb.AppendLine();
                }

                ExportCSVHelper(sb.ToString(), strFileName);
            }
            catch (Exception ex)
            {
            }
        }

        public static void ExportDataSetToXML(DataSet ds, string strFileName, bool IsWithSchema = false)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string header = @"<?xml version=""1.0"" encoding=""utf-8""?>";

                if (IsWithSchema)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        using (TextWriter streamWriter = new StreamWriter(memoryStream))
                        {
                            var xmlSerializer = new XmlSerializer(typeof(DataSet));
                            xmlSerializer.Serialize(streamWriter, ds);

                            //return Encoding.UTF8.GetString(memoryStream.ToArray());
                            var xml = Encoding.UTF8.GetString(memoryStream.ToArray());

                            ExportXMLHelper(xml, strFileName);
                        }
                    }
                }
                else
                {
                    sb.Append(header);
                    sb.Append("<DataSetList>");
                    var docresult = ds.GetXml();
                    sb.Append(docresult);
                    sb.Append("</DataSetList>");

                    ExportXMLHelper(sb.ToString(), strFileName);
                    sb.Clear();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void ExportDataSetListToXml(List<DataSet> dsList, string strFileName, bool IsWithSchema = false)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string header = @"<?xml version=""1.0"" encoding=""utf-8""?>";
                //string header1 = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";

                if (IsWithSchema)
                {
                    sb.Append(header);
                    sb.Append("<DataSetList>");
                    foreach (DataSet ds in dsList)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (TextWriter streamWriter = new StreamWriter(memoryStream))
                            {
                                var xmlSerializer = new XmlSerializer(typeof(DataSet));
                                xmlSerializer.Serialize(streamWriter, ds);
                                var docresult = Encoding.UTF8.GetString(memoryStream.ToArray());
                                docresult = docresult.Substring(40, docresult.Length - 40);
                                //docresult.Replace(header, "");

                                sb.Append(docresult);
                                docresult = null;
                            }
                        }
                    }
                    sb.Append("</DataSetList>");
                    ExportXMLHelper(sb.ToString(), strFileName);
                    sb.Clear();
                }
                else
                {
                    sb.Append(header);
                    sb.Append("<DataSetList>");
                    foreach (DataSet ds in dsList)
                    {
                        var docresult = ds.GetXml();
                        sb.Append(docresult);
                    }
                    sb.Append("</DataSetList>");

                    ExportXMLHelper(sb.ToString(), strFileName);
                    sb.Clear();
                }
            }
            catch (Exception ex)
            {
                //lblMsg.Text = "An error occured processing your request" + ex.Message;
            }
        }

        /// <summary>
        /// Usage call the following methods: FileUtility.DeleteAllFileHelper(strDirectory); ExportDatasetListToFile(dsList, strDirectory, false); ExportZippedHelper("xml", strDirectory, "ReservationInfoListZip");
        /// </summary>
        /// <param name="dsList"></param>
        /// <param name="strDirectory"></param>
        /// <param name="IsWithSchema"></param>
        public static void ExportDataSetListToFile(List<DataSet> dsList, string strDirectory, bool IsWithSchema = false)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string header = @"<?xml version=""1.0"" encoding=""utf-8""?>";

                if (IsWithSchema)
                {
                    foreach (DataSet ds in dsList)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (TextWriter streamWriter = new StreamWriter(memoryStream))
                            {

                                var xmlSerializer = new XmlSerializer(typeof(DataSet));
                                xmlSerializer.Serialize(streamWriter, ds);
                                var docresult = Encoding.UTF8.GetString(memoryStream.ToArray());

                                sb.Append(docresult);
                                docresult = null;

                                string strPath = strDirectory + ds.DataSetName + ".xml";
                                ExportTxtToFileHelper(strPath, sb.ToString());
                            }
                        }
                        sb.Clear();
                    }
                }
                else
                {
                    foreach (DataSet ds in dsList)
                    {
                        sb.Append(header);

                        var docresult = ds.GetXml();
                        sb.Append(docresult);

                        string strPath = strDirectory + ds.DataSetName + ".xml";
                        ExportTxtToFileHelper(strPath, sb.ToString());

                        sb.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                //lblMsg.Text = "An error occured processing your request" + ex.Message;
            }
        }

        private static void ExportCSVHelper(string strCsv, string strFileName)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Pragma", "public");
            HttpContext.Current.Response.AppendHeader("Content-Disposition",
                                                      "attachment; filename=" + strFileName + ".csv");
            HttpContext.Current.Response.ContentType = "text/csv";
            HttpContext.Current.Response.Write(strCsv);
            HttpContext.Current.Response.End();
        }

        private static void ExportXMLHelper(string strXml, string strFileName)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Pragma", "public");
            HttpContext.Current.Response.AppendHeader("Content-Disposition",
                                                      "attachment; filename=" + strFileName + ".xml");
            HttpContext.Current.Response.ContentType = "text/xml; charset=utf-8";
            HttpContext.Current.Response.Write(strXml);
            HttpContext.Current.Response.End();
        }

        #endregion

        private static void ExportTxtToFileHelper(string strFileNameWithPath, string strContents)
        {
            if (!Directory.Exists(Path.GetDirectoryName(strFileNameWithPath))) //strDirectory
                Directory.CreateDirectory(Path.GetDirectoryName(strFileNameWithPath));

            File.WriteAllText(strFileNameWithPath, strContents);
        }

        //attach and add reference to Ionic.Zip.Reduced.dll v1.9.1.8
        private static void ExportZippedHelper(string strFileExtension, string strDirectory, string strFileName)
        {
            //HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.BufferOutput = false;
            //HttpContext.Current.Response.ContentType = "application/zip";
            //HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + strFileName + ".zip");

            //using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            //{
            //    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;
            //    zip.AddSelectedFiles("*." + strFileExtension, strDirectory, "", false);
            //    zip.Save(Response.OutputStream);
            //}

            //Response.Close();
        }
    }
}