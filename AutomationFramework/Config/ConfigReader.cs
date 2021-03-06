﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace AutomationFramework.Config
{
    public class ConfigReader
    {

        public static void SetFrameworkSettings()
        {

            XPathItem aut;
            XPathItem testtype;
            XPathItem islog;
            XPathItem isreport;
            XPathItem buildname;
            XPathItem logpath;

            string strFilename=Environment.CurrentDirectory.ToString() + "\\Config\\GlobalConfig.xml";

            FileStream stream = new FileStream(strFilename, FileMode.Open);

            XPathDocument document = new XPathDocument(stream);

            XPathNavigator navigator=document.CreateNavigator();

            //Get XML Details & pass it in XPathItem type variables
            aut = navigator.SelectSingleNode("AutoFramework/RunSettings/AUT");
            buildname = navigator.SelectSingleNode("AutoFramework/RunSettings/BuildName");
            testtype = navigator.SelectSingleNode("AutoFramework/RunSettings/TestType");
            islog = navigator.SelectSingleNode("AutoFramework/RunSettings/IsLog");
            isreport = navigator.SelectSingleNode("AutoFramework/RunSettings/IsReport");
            logpath = navigator.SelectSingleNode("AutoFramework/RunSettings/LogPath");


            Settings.AUT = aut.Value.ToString();
            //Settings.AUT = "http://demowebshop.tricentis.com/";
            Settings.BuildName = buildname.Value.ToString();
            Settings.TestType = testtype.Value.ToString();
            Settings.IsLog = islog.Value.ToString();
            Settings.IsReporting = isreport.Value.ToString();
            Settings.LogPath = logpath.Value.ToString();

        }

    }
}
