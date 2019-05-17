<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RabbitPopulation.aspx.cs" Inherits="Labs_rabbitsapi.RabbitPopulation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Rabbit Population</h1>
    <h2>Please enter the population ceiling</h2>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <hr />
    <asp:Label ID="Label1" runat="server" Text="Results : "></asp:Label>
    <hr />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
</asp:Content>
