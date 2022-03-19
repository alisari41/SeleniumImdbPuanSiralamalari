using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumImbdPuanSiralamalari
{
    class Program
    {
        static void Main(string[] args)
        {//Nuget Paketini kurarken Tarayıcı(chrome) sürümüne dikkat et sonra build et

            IWebDriver driver = new ChromeDriver();//Hangi tarayıcı üzerinden işlem yapacağımı belirtiyorum.
            driver.Navigate().GoToUrl("http://www.imdb.com/chart/top");

            ReadOnlyCollection<IWebElement> baslik = driver.FindElements(By.XPath("//*[@id=\"main\"]/div/span/div/div/div/table/tbody/tr/td/a"));
            // Siteye gidip Xpath'ini kopyalıyoruz main yazan yerlere \ \ işareti koyuyoruz sonrasında [numara] yazan yerleri siliyoruz
            // Silmemizin nedeni tamamını çekmek istiyorum

            ReadOnlyCollection<IWebElement> resim = driver.FindElements(By.XPath("//*[@id=\"main\"]/div/span/div/div/div/table/tbody/tr/td/a/img"));

            ReadOnlyCollection<IWebElement> reyting = driver.FindElements(By.XPath("//*[@id=\"main\"]/div/span/div/div/div/table/tbody/tr/td/strong"));


            for (int i = 0; i < baslik.Count; i++)
            {
                var t = baslik[i].Text;
                var re = resim[i].GetAttribute("src");// src denmesinin sebebi resimin texti yok sadece src="....." olduğu için text dersek boş döner
                var ra = reyting[i].Text;
                Console.WriteLine(t + "\n\t" + re + "\n\t" + ra);
            }
        }
    }
}
