using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


int maxAmount = 110;

ChromeOptions options = new ChromeOptions();
ChromeDriver driver;


options.AddArguments(@"user-data-dir=C:\Users\barte\AppData\Local\Google\Chrome\User Data");
options.AddArgument("--profile-directory=" + "Profile 3");

var chromeDriverDirectory = @"C:\Users\barte\.nuget\packages\selenium.webdriver.chromedriver\116.0.5845.9600\driver\win32\chromedriver.exe";
driver = new ChromeDriver(chromeDriverDirectory, options);
driver.Manage().Window.Maximize();
WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


while (true)
{
    driver.Navigate().GoToUrl($"https://www.u7buyut.com/sell-coins-player-trade?plat=pc");
    Thread.Sleep(100);

    IReadOnlyCollection<IWebElement> web = wait.Until(i => i.FindElements(By.ClassName("item-sellBtn")));
    IReadOnlyCollection<IWebElement> webPrice = wait.Until(i => i.FindElements(By.ClassName("marketPrice")));
   
    if (web.Count > 0)
    {
        string amountcut = webPrice.First().Text.Substring(webPrice.First().Text.Length - 2);
        int amount = Convert.ToInt32(amountcut);
        if(amount > maxAmount)
        {
            web.First().Click();
            Thread.Sleep(200);
            IReadOnlyCollection<IWebElement> web2 = wait.Until(i => i.FindElements(By.ClassName("buyNowBtn")));
            web2.First().Click();
            Thread.Sleep(100);
            #region MyRegion
            Console.Beep(370, 500);
            Console.Beep(370, 500);
            Console.Beep(370, 500);
            #endregion

            break;
        }
        
    }

    Thread.Sleep(1000);
}

