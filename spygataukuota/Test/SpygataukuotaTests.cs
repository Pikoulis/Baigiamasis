using NUnit.Framework;
using spygataukuota.Text;
using System.Threading;

namespace spygataukuota.Test
{
    class SpygataukuotaTests : BaseTest
    {
        [Test, Order(1)]
        public static void CookieAgreementTextTest()
        {
            string cookieAgreementText = AllTexts.CookieText;
            home.NavigateToPage()
                .CheckCookieAgreementText(cookieAgreementText)
                .AgreeWithCookie();
        }
        [TestCase("Meow", TestName = "AddToBasketAndFillTheForm")]
        public static void AddToBasketAndFillTheForm(string searchString)
        {
            home.NavigateToPage()
                .AddToBasket(searchString);
            search.CkeckSearchText(searchString)
                .SelectItem(1);
            product.ToCart();
            shipp.ButtonBuyPress();
            form.FillForm();
        }
        [Test]
        public static void FacebookLinkTest()
        {
            home.NavigateToPage()
                .FacebookIconClick();
            fbHome.NavigateToMeniuAbout()
                .NavigateToWesiteAndCloseTab();
        }
        [Test]
        public static void GetDirections()
        {
            home.NavigateToPage()
                .ClickContacts();
            contacts.InitiateGooglePage();
            google.CheckTootalKm(AllTexts.Address);
        }

        [TestCase("Meow", TestName = "FilterByDescPriceCheck")]
        public static void FilterByPriceCheck(string searchString)
        {
            home.NavigateToPage()
                .AddToBasket(searchString);
            search.CkeckSearchText(searchString)
                .CheckSortingByPriceDesc();
        }
        [TestCase("joxije1600@a6mail.net", TestName = "successful recovery mail sending ")]
        [TestCase("joxije1601@a6mail.net", TestName = "Unsuccessful recovery mail sending")]
        public static void ForgotPassWord(string mail)
        {
            home.NavigateToPage()
                .InitiateForgotPasswordForm();
            recovery.EnterRecoveryMailAndSend(mail)
                 .CheckSuccessMessage();
        }
    }
}
