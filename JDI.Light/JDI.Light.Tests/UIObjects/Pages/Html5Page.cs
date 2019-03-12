﻿using JDI.Light.Attributes;
using JDI.Light.Elements.Common;
using JDI.Light.Elements.Composite;
using JDI.Light.Tests.Tests.Common;

namespace JDI.Light.Tests.UIObjects.Pages
{
    public class Html5Page : WebPage
    {
        [FindBy(Css = "#ice-cream")]
        public Button IceCream;

        [FindBy(Css = "#ice-cream-flavors > option:nth-child(1)")]
        public Button Chocolate;

    }
}