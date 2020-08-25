﻿using AutomationFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT_UnitTestProject
{
    public class HookInitialize:TestInitializeHook
    {

        public HookInitialize():base(BrowserType.Chrome)
        {

            InitializeSettings();
            NavigateSite();

        }


    }
}
