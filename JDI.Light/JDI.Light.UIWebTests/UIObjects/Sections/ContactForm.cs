﻿using System.Collections.Generic;
using JDI.Core.Attributes;
using JDI.Core.Interfaces.Common;
using JDI.UIWebTests.Entities;
using JDI.Web.Attributes;
using JDI.Web.Selenium.Elements.Common;
using JDI.Web.Selenium.Elements.Composite;
using JDI.Web.Settings;
using OpenQA.Selenium;

namespace JDI.UIWebTests.UIObjects.Sections
{
    public class ContactForm : Form<Contact>
    {
        [FindBy(Css = "input#Name")]
        [Name("FirstName")]
        public ITextField NameField;

        [FindBy(Css = "input#LastName")]
        [Name("LastName")]
        public ITextField LastNameField;

        [FindBy(Css = "textarea#Description")]
        [Name("Description")]
        public ITextArea DescriptionField;

        [FindBy(XPath = "//button[@type='submit' and contains(., 'Submit')]")]
        public IButton SubmitButton;

        [FindBy(XPath = ".//a[@class='ui-slider-handle ui-state-default ui-corner-all' and position()=1]")]
        public Link FirstRoller;

        [FindBy(XPath = ".//a[@class='ui-slider-handle ui-state-default ui-corner-all' and position()=2]")]
        public Link SecondRoller;

        private IJavaScriptExecutor javaScriptExecutor;

        public List<string> GetFormValue()
        {
            List<string> fields = new List<string>();
            fields.Add(NameField.GetText);
            fields.Add(LastNameField.GetText);
            fields.Add(DescriptionField.GetText);
            return fields;
        }

        public void FillForm(Contact contact)
        {
            NameField.NewInput(contact.FirstName);
            LastNameField.NewInput(contact.LastName);
            DescriptionField.NewInput(contact.Description);
        }

        private IJavaScriptExecutor GetJSExecutor()
        {
            if (javaScriptExecutor == null)
            {
                javaScriptExecutor = WebSettings.JSExecutor;
            }
            return javaScriptExecutor;
        }

        //TO_DO
        /*
        public void SetLeftRollerPosition(int position)
        {
            JSLoader jsLoader = new JSLoader();
            string[][] keyWords = { { "LEFT_POS", String.valueOf(position) } };
            getJSExecutor().executeScript(jsLoader.getJSFromFile("JavaScript/rollerLeft.js", keyWords));
            FirstRoller.Click();
        }

        public void setRightRollerPosition(int position)
        {
            JSLoader jsLoader = new JSLoader();
            string[][] keyWords = { { "RIGHT_POS", String.valueOf(position) } };
            getJSExecutor().executeScript(jsLoader.getJSFromFile("JavaScript/rollerRight.js", keyWords));

            SecondRoller.Click();
        }
        */
    }
}
