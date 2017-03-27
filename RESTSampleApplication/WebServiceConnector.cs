using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace RESTSampleApplication
{
    class WebServiceConnector
    {
        /// <summary>
        /// Initializes Connection to webservice
        /// </summary>
        /// <param name="endpointClient">SOAP or REST Endpoint</param>
        public static void InitializeWebService(RESTWebService.DefaultEndpoint endpointClient)
        {
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);

            //Endpoint login through SOAP Client
            endpointClient.Login
                (
                    Properties.Settings.Default.Username,       // Username
                    Properties.Settings.Default.Password,       // Password
                    Properties.Settings.Default.CompanyName,    // Company name
                    Properties.Settings.Default.Branch,         // Branch (if any),
                    null                                        //locale (localization)
                );
        }
        
        /// <summary>
        /// This is for checking if Website that will be accessing has an SSL Certificate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="cert"></param>
        /// <param name="chain"></param>
        /// <param name="policyErrors"></param>
        /// <returns></returns>
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        {
            //For simplicity, this callback always returns true
            //In a real integration application, you must check
            //an SSL certificate here
            return true;
        }
    }
}
