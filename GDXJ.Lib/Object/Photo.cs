﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using QQLib.Http;
using System.Net;
using System.Windows.Media;
using System.IO;
using GDXJ.Lib.Object.setting;
using System.Windows.Forms;
using JumpKick.HttpLib;

namespace GDXJ.Lib.Object
{
    public class Photo
    {
        public static void InitPath()
        {
            if (!System.IO.Directory.Exists(setting.Path.Temp_Path))
            {
                System.IO.Directory.CreateDirectory(setting.Path.Temp_Path);
            }
        }
        public static ImageSource GetPhoto(ref CookieContainer cookie, string studentId,string name)
        {
            string downloadPath =url.domainUrl+ @"/fileDownload?fileName=&filePath={0}&project=0 ";
            string refererUrl = url.domainUrl+@"/jsp/mems/xsxxgl/xjqgl/jlxjq.jsp?xsJbxxId={0}&xm={1}";
            System.Windows.Media.Imaging.BitmapImage image = new System.Windows.Media.Imaging.BitmapImage();
            try
            {
                string path=string.Format(downloadPath, GetPhotoPath(ref cookie, studentId));
                string referer = string.Format(refererUrl, studentId, QQLib.Encoded.Url.UrlEncode(name));
                image.BeginInit();

                var req = Http.Get(path);
                req.AddHeader("Referer", referer);
                //req.AddHeader("_ccrf.token", Csrf.GetCsrfToken());

                image.StreamSource = req.RealTimeGo().RequestStream;
                image.EndInit();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                //throw (new Exception("Get VerificationCodeImage error!"));
            }
            return image;
        }

        public static string SavePhotoToFile(ref CookieContainer cookie, string studentId, string name)
        {
            string downloadPath = url.domainUrl + @"/fileDownload?fileName=&filePath={0}&project=0 ";
            string refererUrl = url.domainUrl + @"/jsp/mems/xsxxgl/xjqgl/jlxjq.jsp?xsJbxxId={0}&xm={1}";
            string fileName=System.IO.Directory.GetCurrentDirectory()+"\\"+ setting.Path.Temp_Path+studentId+".jpg";
            System.Windows.Media.Imaging.BitmapImage image = new System.Windows.Media.Imaging.BitmapImage();
            try
            {
                string path = string.Format(downloadPath, GetPhotoPath(ref cookie, studentId));
                string referer = string.Format(refererUrl, studentId, QQLib.Encoded.Url.UrlEncode(name));

                using (FileStream output = new FileStream(fileName, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    int read = 0;
                    var req = Http.Get(path);
                    req.AddHeader("Referer", referer);

                    using (Stream responeStream = req.RealTimeGo().RequestStream)
                    {
                        while ((read = responeStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, read);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //throw (new Exception("Get VerificationCodeImage error!"));
            }
            return fileName;
        }

        public static string GetPhotoPath(ref CookieContainer cookie, string studentId)
        {
            string result = string.Empty;
            try
            {
                AjaxCommand.Send.ContextCommandParams sendData = new AjaxCommand.Send.ContextCommandParams() { @params = new AjaxCommand.Send.GetStudentPhoto_SendData(studentId) };
                string json = JsonConvert.SerializeObject(sendData, Formatting.Indented);

                var req = Http.Post(url.GetPhotoUrl).Body(json);
                req.AddHeader("Referer", url.GetPhotoUrl);
                req.AddHeader("_ccrf.token", Csrf.GetCsrfToken());
                string html = req.RealTimeGo().RequestString;

                Photo_ReceiveData receiveStudentData = JsonConvert.DeserializeObject<Photo_ReceiveData>(html);
                if (receiveStudentData.map != null)
                {
                    result = receiveStudentData.map.path;
                }
            }
            catch (Exception e)
            {
                result = string.Empty;
            }
            finally
            {

            }
            return result;
        }
    }
    class Photo_ReceiveData
    {
        public string javaClass { get; set; }
        public PhotoObject map { get; set; }
    }

    class PhotoObject
    {
        public string path { get; set; }
    }
}
