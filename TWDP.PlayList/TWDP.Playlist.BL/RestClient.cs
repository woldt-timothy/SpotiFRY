using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using TWDP.Playlist.BL;

namespace TWDP.PlayList.UI
{
    //Basic Authentication (RFC2617)
        public enum httpVerb
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public enum authenticationType
        {
            Basic,
            NTLM
        }

        public enum autheticationTechnique
        {
            RollYourOwn,
            NetworkCredential
        }

        public class RestClient
        {
            public string endPoint { get; set; }
            public httpVerb httpMethod { get; set; }
            public authenticationType authType { get; set; }
            public autheticationTechnique authTech { get; set; }
            public string userName { get; set; }
            public string userPassword { get; set; }


            public RestClient(string v)
            {
                endPoint = string.Empty;
                httpMethod = httpVerb.GET;
            }

        public RestClient()
        {
        }

        public string makeRequest()
            {
                string strResponseValue = string.Empty;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = "GET";

                String authHeaer = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(userName + ":" + userPassword));
                request.Headers.Add("Authorization", "Basic" + " " + authHeaer);

                HttpWebResponse response = null;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();


                    //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (var s = new StreamReader(responseStream))
                            {

                            

                            strResponseValue = s.ReadToEnd();

                          

                            User oerr = JsonConvert.DeserializeObject<User>(strResponseValue);

                            
                                if (oerr.Password == this.userPassword)
                                {
                                    System.Diagnostics.Debug.WriteLine("Good Password");
                                }
                            else
                            {
                                throw new BadPassWordException("Invalid User Input");
                            }
                      
                         
                              
                            
                                
                            

                          

                           
                            
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //finally
                //{
                //    if (response != null)
                //    {
                //        ((IDisposable)response).Dispose();
                //    }
                //}

                return strResponseValue;
            }

        }

    public class BadPassWordException : Exception
    {
        public BadPassWordException(string message)
           : base(message)
        {
        }
    }




}

