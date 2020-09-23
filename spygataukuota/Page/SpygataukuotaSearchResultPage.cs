using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace spygataukuota.Page
{
    public class SpygataukuotaSearchResultPage : BasePage
    {

        private IWebElement FilterTextWithProductCount => Driver.FindElement(By.CssSelector(".fs4.pb10"));
        private IWebElement FilterCriteria => Driver.FindElement(By.Id("sortGoodsBy"));
        private IList<IWebElement> IconsHolder => Driver.FindElements(By.XPath("//div[contains(@class,'vv icons-holder')]"));
        private IList<IWebElement> Prices => Driver.FindElements(By.XPath("//div[contains(@class,'grid_12 omega tar')]"));
        private IWebElement GridIcon => Driver.FindElement(By.CssSelector("#middle_blocks > li > div.pagination.grid_48.alpha.omega.mb5.bb2 > div.grid_36.omega.mb4 > a"));
        private IWebElement FilterDesc => Driver.FindElement(By.CssSelector("#sortGoodsBy > option:nth-child(3)"));
        public SpygataukuotaSearchResultPage(IWebDriver webdriver) : base(webdriver)
        {

        }

        public SpygataukuotaSearchResultPage NavigateToPage(string PageAddress)
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public SpygataukuotaSearchResultPage CkeckSearchText(string searchText)
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(FilterCriteria));
            Assert.AreEqual($"Ieškojote: {searchText}. Rasta prekių: {CountIcons()}", FilterTextWithProductCount.Text, $"Tikimasi kad bus , o buvo {FilterTextWithProductCount.Text}");
            return this;
        }
        private int CountIcons()
        {
            int iconNumber = IconsHolder.Count;
            return iconNumber;
        }

        public SpygataukuotaSearchResultPage SelectItem(int itemNumber)
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(IconsHolder[itemNumber]));
            IconsHolder[itemNumber].Click();
            return this;
        }
        public SpygataukuotaSearchResultPage CheckSortingByPriceDesc()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(GridIcon));
            GridIcon.Click();
            FilterCriteria.Click();
            FilterDesc.Click();
            List<int> original = new List<int>();
            List<int> sorted = new List<int>();
            string price;
            int priceInNumers;

            for (int i = 0; i < Prices.Count; i++)
            {
                price = Prices[i].Text;
                price = price.Replace("€", "");
                priceInNumers = Convert.ToInt32(price);
                original.Add(priceInNumers);
                sorted.Add(priceInNumers);
            }
            sorted.Sort((a, b) => b.CompareTo(a)); // descending sort
            Assert.AreEqual(true, TwoListCompare(original, sorted), "Turejo buti surusiuota des bet taip nenutiko");
            return this;
        }
        private bool TwoListCompare(List<int> original, List<int> sorted)
        {
            bool twoListCompare = false;
            for (int i = 0; i < original.Count; i++)
            {
                if (original[i] != sorted[i])
                {
                    twoListCompare = false;
                    break;
                }
                else
                {
                    twoListCompare = true;
                }
            }
            return twoListCompare;
        }
    }
}
