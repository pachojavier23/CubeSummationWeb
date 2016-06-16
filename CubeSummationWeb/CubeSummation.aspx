<%@ Page Title="" Language="C#" MasterPageFile="~/Cube.Master" AutoEventWireup="true" CodeBehind="CubeSummation.aspx.cs" Inherits="CubeSummationWeb.CubeSummation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel runat="server">
            <div>
                <asp:Table runat="server" Width="360px">

                    <asp:TableRow>
                        <asp:TableHeaderCell Text="Input"/>
                        <asp:TableHeaderCell Text="Output"/>
                    </asp:TableRow>

                </asp:Table>
            </div>
            <div>
                <asp:TextBox runat="server" ID="textAreaInput" TextMode="MultiLine" Height="200px" Width="180px"></asp:TextBox>
                <asp:TextBox runat="server" ID="textAreaOutput" TextMode="MultiLine" Height="200px" Width="180px" Enabled="false"></asp:TextBox>

            </div>
        </asp:Panel>
        <asp:Panel runat="server">
            
            <asp:Button runat="server" Text="Ejecutar"/>
        </asp:Panel>
    </div>
</asp:Content>
