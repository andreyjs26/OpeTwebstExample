<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Serial">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Width="302px" Height="26px"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Height="45px" Width="150px" />
                <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PartId">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Width="211px"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle BackColor="#339966" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Height="45px" Width="150px" />
                <ItemStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Country">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Width="211px"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Height="45px" Width="150px" />
                <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" />
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />

        
    </asp:GridView>
</asp:Content>

