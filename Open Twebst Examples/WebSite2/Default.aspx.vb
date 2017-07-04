
Partial Class _Default
    Inherits Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        'On Windows 64 bit use the command line below to launch the script as a 32 bit process:
        ' %windir%\SysWOW64\wscript.exe TwebstScript.vbs


        Dim core As Object
        Dim browser As Object
        core = CreateObject("OpenTwebst.Core")
        browser = core.StartBrowser("https://onehp-idp.external.hp.com/idp/startSSO.ping?PartnerSpId=siteminder&TargetResource=https://es-int-dh.austin.hp.com/ui-obligation-1.1/main/ObligationViewer.jsp")

        Call browser.FindElement("select", "name=pfidpadapterid").Select("Email and Computer password")
        Call browser.FindElement("input submit", "uiname=Continue log on with selected credential").Click()
        Call browser.FindElement("form", "id=Login").Click()
        Call browser.FindElement("input text", "id=username").InputText("angel-andrey.jaen-solis@hp.com")
        Call browser.FindElement("input password", "id=password").InputText("ajs2603931!")
        Call browser.FindElement("input submit", "uiname=Log on").Click()
        Call browser.FindElement("a", "uiname=List Search").Click()
        Call browser.FindElement("button", "id=bulkInputButton").Click()
        Call browser.FindElement("button", "id=loadData").Click()
        Call browser.FindElement("button", "id=submit, index=1").Click()



    End Sub
End Class