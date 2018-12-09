﻿using JDI.Light.Tests.Entities;
using JDI.Light.Tests.UIObjects;
using JDI.Light.Utils;
using NUnit.Framework;

namespace JDI.Light.Tests.Tests
{
    [SetUpFixture]
    public class TestBase
    {
        [OneTimeSetUp]
        protected void SetUp()
        {
            JDI.Init();
            JDI.GetLatestDriver = false;
            JDI.DriverVersion = "2.41";
            JDI.Logger.Info("Init test run...");
            JDI.Timeouts.WaitElementSec = 40;
            WinProcUtils.KillAllRunWebDrivers();
            JDI.InitSite(typeof(TestSite));
            TestSite.HomePage.Open();
            TestSite.LoginForm.Submit(User.DefaultUser);
            JDI.Logger.Info("Run test...");
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            WinProcUtils.KillAllRunWebDrivers();
        }
    }
}