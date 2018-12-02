﻿using System;
using System.Collections.Generic;
using JDI.Light.Elements.Base;
using JDI.Light.Elements.Common;
using JDI.Light.Elements.Complex;
using JDI.Light.Interfaces.Common;
using JDI.Light.Interfaces.Complex;
using JDI.Light.Utils;
using OpenQA.Selenium;

namespace JDI.Light.Elements.Composite
{
    public class Search : TextField, ISearch
    {
        private readonly TextList _suggestions;

        protected Action<Search, string, int> ChooseSuggestionIndexAction = (s, text, selectIndex) =>
        {
            s.SearchField.Input(text);
            s.Suggestions.TextElements[selectIndex].Click();
        };

        protected Action<Search, string> FindAction = (s, text) =>
        {
            s.SearchField.NewInput(text);
            s.SearchButton.Click();
        };

        protected Func<Search, string, IList<string>> GetSuggestionsAction = (s, text) =>
        {
            s.SearchField.Input(text);
            return s.Suggestions.Texts;
        };

        protected Clickable Select;

        public Search() : this(null)
        {
        }

        public Search(By byLocator = null, By selectLocator = null, By suggestionsListLocator = null) : base(byLocator)
        {
            Select = new Clickable(selectLocator);
            _suggestions = new TextList(suggestionsListLocator);
        }

        private TextList Suggestions
        {
            get
            {
                if (_suggestions != null)
                    return _suggestions;
                throw JDI.Assert.Exception(
                    "Suggestions list locator not specified for search. Use accordance constructor");
            }
        }

        private ITextField SearchField
        {
            get
            {
                var fields = this.GetFields(typeof(ITextField));
                switch (fields.Count)
                {
                    case 0:
                        throw JDI.Assert.Exception($"Can't find any buttons on form '{ToString()}'.");
                    case 1:
                        return (ITextField) fields[0].GetValue(this);
                    default:
                        throw JDI.Assert.Exception(
                            $"Form '{ToString()}' have more than 1 button. Use submit(entity, buttonName) for this case instead");
                }
            }
        }

        protected IButton SearchButton
        {
            get
            {
                var fields = this.GetFields(typeof(IButton));
                switch (fields.Count)
                {
                    case 0:
                        throw JDI.Assert.Exception($"Can't find any buttons on form '{ToString()}'.");
                    case 1:
                        return (IButton) fields[0].GetValue(this);
                    default:
                        throw JDI.Assert.Exception(
                            $"Form '{ToString()}' have more than 1 button. Use submit(entity, buttonName) for this case instead");
                }
            }
        }

        public void Find(string text)
        {
            Invoker.DoAction($"Search text '{text}'", s => FindAction(this, text));
        }

        public void ChooseSuggestion(string text, int selectIndex)
        {
            Invoker.DoAction($"Search for text '{text}' and choose suggestion '{selectIndex}'",
                s => ChooseSuggestionIndexAction(this, text, selectIndex));
        }

        public IList<string> GetSuggestions(string text)
        {
            return Invoker.DoActionResultWithResult($"Get all suggestions for input '{text}'",
                s => GetSuggestionsAction(this, text));
        }
    }
}