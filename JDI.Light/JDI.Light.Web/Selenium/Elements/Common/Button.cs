﻿using System;
using JDI.Core.Interfaces.Common;
using JDI.Web.Selenium.Base;
using JDI.Web.Selenium.Elements.Base;
using OpenQA.Selenium;

namespace JDI.Web.Selenium.Elements.Common
{
    public class Button : ClickableText, IButton
    {
        public Button() : this(null) { }
        public Button(By byLocator = null, IWebElement webElement = null, WebBaseElement element = null)
            : base(byLocator, webElement, element:element) { }

        protected new Func<WebBaseElement, string> GetTextFunc =
           el => el.WebAvatar.FindImmediately(() => el.WebElement.GetAttribute("value"), "");
    }
}
