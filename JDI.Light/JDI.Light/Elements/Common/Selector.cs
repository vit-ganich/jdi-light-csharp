﻿using System;
using System.Linq;
using JDI.Light.Elements.Base;
using JDI.Light.Exceptions;
using OpenQA.Selenium;

namespace JDI.Light.Elements.Common
{
    public class Selector : UIElement
    {
        public By ItemLocator { get; set; }

        private readonly Action<Selector, string> _selectElementAction = (selector, item) =>
        {
            var els = selector.WebElement.FindElements(selector.ItemLocator);
            var itemsList = els.FirstOrDefault(e => e.Text.Equals(item));
            if (itemsList != null)
            {
                itemsList.Click();
            }
            else
            {
                throw new ElementNotFoundException($"Can't find element '{item}' to select. ");
            }
        };

        private readonly Action<Selector, int> _selectByIndex = (selector, index) =>
        {
            var els = selector.WebElement.FindElements(selector.ItemLocator);
            try
            {
                var el = els[index];
                el.Click();
            }
            catch (Exception e)
            {
                throw new ElementNotFoundException($"Can't find element with index - '{index}' to select. " + e.Message);
            }
        };

        private readonly Func<IWebElement, string> _getSelected = (selector) => selector.Text;

        public Selector(By byLocator) : base(byLocator)
        {
        }

        public void Select(string value, Selector elem)
        {
            Invoker.DoAction($"Select item '{string.Join(" -> ", value)}'",
                () => _selectElementAction.Invoke(elem, value));
        }

        public void Select(int index, Selector elem)
        {
            Invoker.DoAction($"Select item with index - '{string.Join(" -> ", index)}'",
                () => _selectByIndex.Invoke(elem, index));
        }

        public void Select(string[] values, Selector elem)
        {
            foreach (var value in values)
            {
                Invoker.DoAction($"Select item '{string.Join(" -> ", value)}'",
                    () => _selectElementAction.Invoke(elem, value));
            }
        }

        public void Select(int[] indexes, Selector elem)
        {
            foreach (var index in indexes)
            {
                 Invoker.DoAction($"Select item with index - '{string.Join(" -> ", index)}'",
                () => _selectByIndex.Invoke(elem, index));
            }
        }

        public string GetSelected(IWebElement elem)
        {
            return Invoker.DoActionWithResult("Get value", () => _getSelected.Invoke(elem));
        }

        public int GetSelectedIndex( Selector elem)
        {
            var els = elem.WebElement.FindElements(elem.ItemLocator);
            for (int i = 0; i < els.Count; i++)
            {
                if (els[i].GetAttribute("class") == "selected") return i;
            }
            return -1;
        }
    }
}