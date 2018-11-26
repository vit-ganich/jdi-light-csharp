﻿using JDI.Light.Interfaces.Base;

namespace JDI.Light.Interfaces.Common
{
    public interface IText : IHasValue, IBaseUIElement
    {
        /**
     * return: Get WebElement’s text
     */
        //TODO[JDIAction]
        string GetText { get; }

        /**
         * param: text Specify expected text
         * return: Wait while WebElement’s text contains expected text. Returns WebElement’s text
         */
        //TODO[JDIAction]
        string WaitText(string text);

        /**
         * @param regEx Specify expected regular expression Text
         * @return Wait while WebElement’s text matches regEx. Returns WebElement’s text
         */
        //TODO[JDIAction]
        string WaitMatchText(string regEx);
    }
}