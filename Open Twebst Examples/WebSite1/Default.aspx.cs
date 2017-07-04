using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;



using mshtml;
using Core = OpenTwebstLib.core;
using ICore = OpenTwebstLib.ICore;
using IBrowser = OpenTwebstLib.IBrowser;
using IElement = OpenTwebstLib.IElement;
using SHDocVw;

public partial class _Default : Page
{

    public string test = "";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string text = "";
        text = "USE929N4Z6 " + "484184-B21 " + "US";

        getWarranty(text,1);
      //OpenTwebst();
       // ExplorerDocumentacion();
       // open2();
      //  open3();




    }

    public List<string> getWarranty(string text, int total)
    {


        string end = "";
        string start = "";
        string sla = "";
        string master = "";


        string endc = "";
        string startc = "";
        string slac = "";
        string masterc = "";


        List<String> listaResultado = new List<string>();



        InternetExplorer browser = new InternetExplorer();

        browser.Navigate("https://es-int-dh.austin.hp.com/ui-obligation-1.1/main/ObligationViewer.jsp#tabs-quickSearch");

        browser.Visible = true;



        while (browser.Busy == true || browser.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE)
        {
            Thread.Sleep(1000);
        }



        Thread.Sleep(2000);
        browser.Navigate("https://es-int-dh.austin.hp.com/ui-obligation-1.1/main/ObligationViewer.jsp#tabs-quickSearch");
        while (browser.Busy == true || browser.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE)
        {
            Thread.Sleep(1000);
        }


        if (browser.LocationURL != "https://es-int-dh.austin.hp.com/ui-obligation-1.1/main/ObligationViewer.jsp#tabs-quickSearch")
        {
            HTMLDocument login = new HTMLDocument();
            login = (HTMLDocument)browser.Document;




            Thread.Sleep(2000);
            IHTMLElementCollection selects = login.getElementsByName("pfidpadapterid");


            foreach (HTMLSelectElement select in selects)
            {
                // Thread.Sleep(2000);
                select.selectedIndex = 1;
            }




            Thread.Sleep(2000);

            IHTMLElementCollection buttons = login.getElementsByTagName("input");
            foreach (IHTMLElement button in buttons)
            {
                button.click();
            }

            Thread.Sleep(2000);
            HTMLInputTextElement username = (HTMLInputTextElement)login.getElementById("username");
            username.value = "angel-andrey.jaen-solis@hp.com";

            Thread.Sleep(2000);
            HTMLInputTextElement password = (HTMLInputTextElement)login.getElementById("password");
            password.value = "ajs2603931!";

            Thread.Sleep(2000);
            IHTMLElementCollection logons = login.getElementsByTagName("input");
            foreach (IHTMLElement logon in logons)
            {
                logon.click();
            }

            Thread.Sleep(3000);
            while (browser.Busy == true || browser.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE)
            {
                Thread.Sleep(1000);
            }
            browser.Navigate("https://es-int-dh.austin.hp.com/ui-obligation-1.1/main/ObligationViewer.jsp#tabs-quickSearch");

        }










        Thread.Sleep(2000);
        HTMLDocument myDoc = new HTMLDocument();

        myDoc = (HTMLDocument)browser.Document;




        //HTMLInputButtonElement refresh = (HTMLInputButtonElement)myDoc.getElementById("refresh");
        //refresh.click();






        HTMLInputButtonElement bulkInputButton = (HTMLInputButtonElement)myDoc.getElementById("bulkInputButton");
        bulkInputButton.click();

        HTMLInputTextElement inputcvs = (HTMLInputTextElement)myDoc.getElementById("inputcvs");
        inputcvs.value = text;

        HTMLInputButtonElement loaddata = (HTMLInputButtonElement)myDoc.getElementById("loadData");
        loaddata.click();


        while (browser.Busy == true || browser.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE)
        {
            Thread.Sleep(1000);
        }

        HTMLInputButtonElement submit = (HTMLInputButtonElement)myDoc.getElementById("submit");
        submit.click();

        while (browser.Busy == true || browser.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE)
        {
            Thread.Sleep(1000);
        }

        Thread.Sleep(10000);





        HTMLDocument document = new HTMLDocument();
        document = (HTMLDocument)browser.Document;










        string acordionTable = "";
        string obligationTop = "";


        for (int cou = 0; cou < total; cou++)
        {
            start = "";
            end = "";
            sla = "";
            master = "";



            if (total > 0)
            {
                acordionTable = "obligationTop_" + cou.ToString() + "-obligation" + (cou + 1).ToString() + "Grid";
                obligationTop = "obligationTop_" + cou.ToString() + "-obligation" + (cou + 1).ToString() + "-header0Grid";
            }
            else
            {
                acordionTable = "accordion-obligation1Grid";
                obligationTop = "accordion-obligation1-header0Grid";
            }


            HTMLTable elem = (HTMLTable)document.getElementById(obligationTop);
            int i = 0;
            foreach (HTMLTableSection tbody in elem.tBodies)
            {



                foreach (HTMLTableRow row in elem.rows)
                {

                    if (i == 0)
                    {
                        i++;
                        continue;
                    }

                    foreach (HTMLTableCell cell in row.cells)
                    {
                        if (start == "")
                        {
                            start = cell.innerText;

                        }
                        else
                        {
                            end = cell.innerText;
                            break;
                        }


                    }

                    if (start != "" && end != "")
                    {
                        break;
                    }

                }
            }




            int y = 0;
            int lastOfferNow = -1;
            IHTMLElementCollection a = document.getElementsByTagName("a");
            foreach (IHTMLElement element in a)
            {

                if (element.innerHTML != null)
                {

                    if (element.innerHTML.Contains("Offer -"))
                    {
                        if (y == 0)
                        {
                            y++;
                            continue;
                        }


                        lastOfferNow++;
                        if (lastOfferNow == cou)
                        {

                            string slaComplete = element.innerHTML;
                            int first = 0;



                            for (int x = 0; x <= slaComplete.Length; x++)
                            {
                                if ((slaComplete[x] == '-') && (first == 0))
                                {
                                    first = x + 1;
                                    break;
                                }

                            }
                            sla = slaComplete.Substring(first, 9);
                            break;


                        }



                    }
                }

            }









            HTMLTable tableSuport = (HTMLTable)document.getElementById(acordionTable);
            int z = 0;
            foreach (HTMLTableSection tbody in tableSuport.tBodies)
            {



                foreach (HTMLTableRow row in tableSuport.rows)
                {

                    if (z == 0)
                    {
                        z++;
                        continue;
                    }

                    foreach (HTMLTableCell cell in row.cells)
                    {
                        master = cell.innerText;
                        break;

                    }

                    if (master != "")
                    {
                        break;
                    }

                }
            }



            //List<Warranty> waranties = new List<Warranty>
            //{

            //new Warranty() { startDate = start, endDate= end, sla=sla, masterCode= master }
            // };

            //if (waranties != null)
            //{
            //    for (int h = 0; h < waranties.Count; h++)
            //    {
            //        listaResultado.Add(waranties[h].startDate);
            //        listaResultado.Add(waranties[h].endDate);
            //        listaResultado.Add(waranties[h].sla);
            //        listaResultado.Add(waranties[h].masterCode);
            //    }

            //}

        }






        return listaResultado;




        //List<Carepack> carepacks = new List<Carepack>
        // {
        //  new Carepack() { startDate = startc, endDate= endc, sla=slac, masterCode= masterc }

        // };
        //if (carepacks != null)
        //{
        //    for (int h = 0; h < carepacks.Count; h++)
        //    {
        //        listaResultado.Add(carepacks[h].startDate);
        //        listaResultado.Add(carepacks[h].endDate);
        //        listaResultado.Add(carepacks[h].sla);
        //        listaResultado.Add(carepacks[h].masterCode);
        //    }

        //}
        //return listaResultado;


    }
    public void open2()
    {
        // Create the Core object.
        ICore core = new Core();

        // Use hardware events to perform actions on HTML controls because of coolness factor.
        // By default HTML events are used.
        //core.useHardwareInputEvents = true;

        // Start a new Internet Explorer browser and create a Browser object for it.
        //IBrowser browser = core.StartBrowser("http://doc.codecentrix.com/Lnkplayground.htm");




        IBrowser browser = core.StartBrowser("https://es-int-dh.austin.hp.com/webclient/WebClient/Main.do");


        if (browser.url != "https://es-int-dh.austin.hp.com/webclient/WebClient/Main.do")
        {
            IElement elem1 = browser.FindElement("select", "name=pfidpadapterid");

            elem1.Select("Email and Computer password");

            elem1.FindElement("input submit", "uiname=Continue log on with selected credential");
            elem1.Click();


            //elem1 = browser.FindElement("form", "id=Login");
            //elem1.Click();

            elem1 = browser.FindElement("input text", "id=username");
            elem1.InputText("angel-andrey.jaen-solis@hp.com");

            elem1 = browser.FindElement("input password", "id=password");
            elem1.InputText("ajs2603931!");

            elem1 = browser.FindElement("input submit", "uiname=Log on");
            elem1.Click();

        }


        IElement elem = browser.FindElement("a", "uiname=Entitlement Search");
        elem.Click();

         elem = browser.FindElement("input text", "name=SerialNumber");
         elem.InputText("USE929N4Z6");

        elem=browser.FindElement("input text", "name=ProductID");
        elem.InputText("484184-B21");

        elem=browser.FindElement("input text", "name=ISOCountryCd");
        elem.InputText("US");

       elem= browser.FindElement("input button", "name=B1");
       elem.Click();


       elem = browser.FindElement("tr", "id=contract");
      
       test = browser.url;
       
    
    }

    public void open3()
    {
        InternetExplorer browser = new InternetExplorer();
        browser.Navigate(test);
        browser.Visible = true;
    }


    public void ExplorerDocumentacion()
    {
        string text = "";
        text = "USE929N4Z6 " + "484184-B21 " + "US";

        InternetExplorer browser = new InternetExplorer();
        browser.Navigate("https://es-int-dh.austin.hp.com/ui-obligation-1.1/main/ObligationViewer.jsp#tabs-quickSearch");

        browser.Visible = true;


        
       while (browser.Busy==true || browser.ReadyState!= tagREADYSTATE.READYSTATE_COMPLETE)

       {
           Thread.Sleep(1000);
       }


       Thread.Sleep(2000);
       browser.Navigate("https://es-int-dh.austin.hp.com/ui-obligation-1.1/main/ObligationViewer.jsp#tabs-quickSearch");
       while (browser.Busy == true || browser.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE)
       {
           Thread.Sleep(1000);
       }


       if (browser.LocationURL != "https://es-int-dh.austin.hp.com/ui-obligation-1.1/main/ObligationViewer.jsp#tabs-quickSearch")
        {
            HTMLDocument login = new HTMLDocumentClass();
            login = (HTMLDocument)browser.Document;




            Thread.Sleep(2000);
            IHTMLElementCollection selects = login.getElementsByName("pfidpadapterid");
            

            foreach (HTMLSelectElement select in selects)
            {
               // Thread.Sleep(2000);
                select.selectedIndex = 1;
            }




            Thread.Sleep(2000);
            
            IHTMLElementCollection buttons = login.getElementsByTagName("input");
            foreach( IHTMLElement button in buttons)
            {
            button.click();
            }




            //HTMLFormElement form = (HTMLFormElement)login.getElementById("Login");
            //form.click();


            Thread.Sleep(2000);
            HTMLInputTextElement username = (HTMLInputTextElement)login.getElementById("username");
            username.value = "angel-andrey.jaen-solis@hp.com";

            Thread.Sleep(2000);
            HTMLInputTextElement password = (HTMLInputTextElement)login.getElementById("password");
            password.value="ajs2603931!";

            Thread.Sleep(2000);
            IHTMLElementCollection logons = login.getElementsByTagName("input");
            foreach (IHTMLElement logon in logons)
            {
                logon.click();
            }
            
            
           

          }

        
         Thread.Sleep(2000);
            HTMLDocument myDoc = new HTMLDocumentClass();

            myDoc = (HTMLDocument)browser.Document;


        
            HTMLInputButtonElement bulkInputButton = (HTMLInputButtonElement)myDoc.getElementById("bulkInputButton");
            bulkInputButton.click();

            HTMLInputTextElement inputcvs = (HTMLInputTextElement)myDoc.getElementById("inputcvs");
            inputcvs.value = text;

            HTMLInputButtonElement loaddata = (HTMLInputButtonElement)myDoc.getElementById("loadData");
            loaddata.click();


            while (browser.Busy == true || browser.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE)
            {
                Thread.Sleep(1000);
            }

            HTMLInputButtonElement submit = (HTMLInputButtonElement)myDoc.getElementById("submit");
            submit.click();

            while (browser.Busy == true || browser.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE)
            {
                Thread.Sleep(1000);
            }

            Thread.Sleep(5000);

            HTMLDocument document = new HTMLDocumentClass();
            document = (HTMLDocument)browser.Document;

            HTMLTable  elem = (HTMLTable)document.getElementById("accordion-obligation0-header0-280-290-lineitemGrid");
            int i = 0;
            foreach (HTMLTableSection tbody in elem.tBodies)
            {



                foreach (HTMLTableRow row in elem.rows)
                {

                    if (i == 0)
                    {
                        i++;
                        continue;
                    }

                    foreach (HTMLTableCell cell in row.cells)
                    {
                        string aux = cell.innerText;
                    }

                }
            }
       

           
            

    }


    public void OpenTwebst()
    {

       

        // Create the Core object.
        ICore core = new Core();

        // Use hardware events to perform actions on HTML controls because of coolness factor.
        // By default HTML events are used.
        //core.useHardwareInputEvents = true;

        // Start a new Internet Explorer browser and create a Browser object for it.
        //IBrowser browser = core.StartBrowser("http://doc.codecentrix.com/Lnkplayground.htm");




        IBrowser browser = core.StartBrowser("https://onehp-idp.external.hp.com/idp/startSSO.ping?PartnerSpId=siteminder&TargetResource=https://es-int-dh.austin.hp.com/ui-obligation-1.1/main/ObligationViewer.jsp");


        IElement elem = browser.FindElement("select", "name=pfidpadapterid");

        if (browser.url != "https://es-int-dh.austin.hp.com/ui-obligation-1.1/main/ObligationViewer.jsp")
        {

            elem.Select("Email and Computer password");

            elem.FindElement("input submit", "uiname=Continue log on with selected credential");
            elem.Click();


            elem = browser.FindElement("form", "id=Login");
            elem.Click();

            elem = browser.FindElement("input text", "id=username");
            elem.InputText("angel-andrey.jaen-solis@hp.com");

            elem = browser.FindElement("input password", "id=password");
            elem.InputText("ajs2603931!");

            elem = browser.FindElement("input submit", "uiname=Log on");
            elem.Click();

        }
        else
        {



            elem = browser.FindElement("a", "uiname=List Search");
            elem.Click();

            elem = browser.FindElement("button", "id=bulkInputButton");
            elem.Click();

            string text = "";
            text = "USE929N4Z6 " + "484184-B21 " + "US";


            elem = browser.FindElement("textarea", "id=inputcvs");
            elem.InputText(text);


            elem = browser.FindElement("button", "id=loadData");
            elem.Click();

            elem = browser.FindElement("button", "id=submit, index=1");
            elem.Click();


            Thread.Sleep(6000);


             elem= browser.FindElement("span", "class=ui-icon ui-icon-triangle-1-s");
             elem.Click();


            elem = browser.FindElement("a", "uiname=Offers Related To Package Offer: H7J34AC");
            elem.Click();

            elem=browser.FindElement("table", "id=obligationTop_0-obligation0-header0Grid");
            elem.Click();

            
            elem = browser.FindElement("div", "id=obligationTop_0");
            elem.Click();

            var text2="";
            
            var tr=   elem.FindChildrenElements("tbody","");

      

         for (int i = 0; i < tr.length; i++)

         {
             text2 += tr[i].nativeElement.innerText+"\n";
         }

           
           // text="";
            //foreach (string element in elem)
            //{

            //}


        }
    
    }

}