﻿using NUnit.Framework;
using static JDI.Light.Tests.UIObjects.TestSite;

namespace JDI.Light.Tests.Tests.Common
{
    [TestFixture]
    public class LabelsTests : TestBase
    {
        [SetUp]
        public void SetUp()
        {
            MetalsColorsPage.Open();
            JDI.Logger.Info("Navigating to Metals and Colors page.");
            MetalsColorsPage.CheckTitle();
            JDI.Logger.Info("Setup method finished");
        }

        [Test]
        public void CheckCalculate()
        {
            MetalsColorsPage.CalculateButton.Click();
            JDI.Assert.Contains(MetalsColorsPage.CalculateText.Value, "Summary: 3");
        }
    }
}