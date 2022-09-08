using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class FirstTest
{
    static void Test_1()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://testing.todorvachev.com");
        Thread.Sleep(3000);
        driver.Quit();
        Console.WriteLine("Test 1 ends");
    }

    static void Test_2()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://testing.todorvachev.com/selectors/name/");
        IWebElement element = driver.FindElement(By.Name("myName"));
        if (element.Displayed)
        {
            GreenMsg("Yes, I can see the element.");
        }
        else
        {
            RedMsg("Error, something went wrong. I should see element.");
        }
        driver.Quit();
    }

    static void Test_3()
    {
        string URL = "http://testing.todorvachev.com/selectors/id/";
        string ID = "testImage";
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(URL);
        IWebElement element = driver.FindElement(By.Id(ID));
        if (element.Displayed)
        {
            GreenMsg("Yes, I can see the element.");
        }
        else
        {
            RedMsg("Error, something went wrong. I should see element.");
        }
        driver.Quit();
    }

    static void Test_4()
    {
        TestMSg(System.Reflection.MethodBase.GetCurrentMethod().Name);
        string URL = "http://testing.todorvachev.com/selectors/class-name/";
        string NAME = "testClass";
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(URL);
        IWebElement element = driver.FindElement(By.ClassName(NAME));
        if (element.Displayed)
        {
            GreenMsg("Yes, I can see the element.\nElement text: " + element.Text);

        }
        else
        {
            RedMsg("Error, something went wrong. I should see element.");
        }
        driver.Quit();
    }

    static void Test_5()
    {
        TestMSg(System.Reflection.MethodBase.GetCurrentMethod().Name);

        string URL = "http://testing.todorvachev.com/css-path/";
        string cssPath = "#post-108 > div > figure > img";
        string xPathFull = "/ html / body / div / div[2] / div / article / div / figure / img";
        String xPathPArtial = "//*[@id='post-108']/div/figure/img";
        //*[@id="post-108"]/header/h1
        String xPath = xPathPArtial;
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(URL);

        IWebElement elementCssPath = driver.FindElement(By.CssSelector(cssPath));
        IWebElement elementXPath = driver.FindElement(By.XPath(xPath));

        if (elementCssPath.Displayed)
        {
            GreenMsg("Yes, I can see the elementCssPath.\nElement text: " + elementCssPath.Text);

        }
        else
        {
            RedMsg("Error, something went wrong. I should see elementCssPath.");
        }

        if (elementXPath.Displayed)
        {
            GreenMsg("Yes, I can see the elementXPath.\nElement text: " + elementXPath.Text);

        }
        else
        {
            RedMsg("Error, something went wrong. I should see elementXPath.");
        }
        driver.Quit();
    }

    static void Test_6()
    {
        TestMSg(System.Reflection.MethodBase.GetCurrentMethod().Name);

        string URL = "http://testing.todorvachev.com/css-path/";
        string cssPath = "#post-108 > div > figure > img";
        String xPathPArtial = "//*[@id='post-108']/div/fie/img";
        String xPath = xPathPArtial;
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(URL);

        try
        {
            IWebElement elementCssPath = driver.FindElement(By.CssSelector(cssPath));
            IWebElement elementXPath = driver.FindElement(By.XPath(xPath));
        }
        catch (NoSuchElementException e)
        {
            RedMsg("I cannot find element via specified selector!\n" + e.Message);
        }

        driver.Quit();
    }

    static void Test_InputField()
    {
        TestMSg(System.Reflection.MethodBase.GetCurrentMethod().Name);
        string URL = "https://testing.todorvachev.com/text-input-field/";
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(URL);
        try
        {
            IWebElement textBox = driver.FindElement(By.Name("username"));
            textBox.SendKeys("Test text");
            Thread.Sleep(3000);

            GreenMsg(textBox.GetAttribute("value"));

            textBox.Clear();
            Thread.Sleep(3000);

        }
        catch (NoSuchElementException e)
        {
            RedMsg("I cannot find element via specified selector!\n" + e.Message);
        }

        driver.Quit();
    }

    static void Test_CheckBox()
    {
        TestMSg(System.Reflection.MethodBase.GetCurrentMethod().Name);
        string URL = "https://testing.todorvachev.com/check-button-test-3/";
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(URL);
        try
        {
            IWebElement BikeCheckBox = driver.FindElement(By.CssSelector("#post-33 > div > p:nth-child(8) > input[type=checkbox]:nth-child(1)"));
            IWebElement CarCheckBox = driver.FindElement(By.CssSelector("#post-33>div>p:nth-child(8)>input[type=checkbox]:nth-child(3)"));
            string msg = BikeCheckBox.GetAttribute("checked") == "true" ? "is checked" : "is not checked";
            WhMsg(msg);
            Thread.Sleep(3000);
        }
        catch (NoSuchElementException e)
        {
            RedMsg("I cannot find element via specified selector!\n" + e.Message);
        }
        driver.Quit();
    }

    static void Test_RadioButtons()
    {
        TestMSg(System.Reflection.MethodBase.GetCurrentMethod().Name);
        string URL = "https://testing.todorvachev.com/radio-button-test/";
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(URL);
        try
        {
            IWebElement radioButton = driver.FindElement(By.CssSelector("#post-10 > div > form > p:nth-child(6) > input[type=radio]:nth-child(3)"));
            radioButton.Click();
            string msg = radioButton.GetAttribute("checked") == "true" ? "is checked" : "is not checked";
            WhMsg(msg);
            Thread.Sleep(3000);
        }
        catch (NoSuchElementException e)
        {
            RedMsg("I cannot find element via specified selector!\n" + e.Message);
        }
        driver.Quit();
    }

    static void Test_DropDown()
    {
        TestMSg(System.Reflection.MethodBase.GetCurrentMethod().Name);
        string URL = "https://testing.todorvachev.com/drop-down-menu-test/";
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(URL);
        try
        {
            IWebElement dropDownMenu = driver.FindElement(By.CssSelector("#post-6 > div > p:nth-child(6) > select"));
            WhMsg(dropDownMenu.GetAttribute("value"));
            IWebElement menuElement = driver.FindElement(By.CssSelector("#post-6 > div > p:nth-child(6) > select > option:nth-child(2)"));
            menuElement.Click();
            WhMsg(dropDownMenu.GetAttribute("value"));
            Thread.Sleep(3000);

        }
        catch (NoSuchElementException e)
        {
            RedMsg("I cannot find element via specified selector!\n" + e.Message);
        }
        driver.Quit();
    }



    static void Test_AlertBox()
    {
        TestMSg(System.Reflection.MethodBase.GetCurrentMethod().Name);
        string URL = "https://testing.todorvachev.com/alert-box/";
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(URL);
        try
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(3000);

        }
        catch (NoSuchElementException e)
        {
            RedMsg("I cannot find element via specified selector!\n" + e.Message);
        }
        driver.Quit();
    }

    private static void RedMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }
    private static void GreenMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void WhMsg(string msg)
    {
        Console.WriteLine(msg);
    }

    private static void TestMSg(String msg)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void Main()
    {
        Test_AlertBox();
    }
}





