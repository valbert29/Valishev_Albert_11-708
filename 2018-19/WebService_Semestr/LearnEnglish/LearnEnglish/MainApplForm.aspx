<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainApplForm.aspx.cs" Inherits="LearnEnglish.MainApplForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="CSSForLearn.css"/>
</head>
<body>
    <form runat="server" class="mainDIV" >
        <div>
            <table class="QuestTXT">
                <tr id="TopLbl">
                    <td>
                        <asp:Label ID="WordLBL" runat="server" text="SELECT THE TRANSLATION WHICH YOU THINK IS RIGHT!">
                            </asp:Label>
                    </td>
                </tr>
                <tr id="ChangingLbl">
                    <td>
                        <asp:Label ID="Word" runat="server" text="Press START to begin!">
                            </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button id="StartBtn" CssClass="StartBut" runat="server" text="START" OnClick="Next">
                            </asp:Button>
                    </td>
                </tr>
            </table>
            <table class="answers">
                <tr>
                    <td>
                        <asp:Button CssClass="btn" ID="btnTR" runat="server"  text="Here will be word. But soon..." OnClick="btnDiv_Click">
                            </asp:Button>
                    </td>
                    <td>
                        <asp:Button CssClass="btn" ID="btnTL" runat="server"  text="Here will be word. But soon..." OnClick="btnDiv_Click">
                            </asp:Button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button CssClass="btn" ID="btnDL" runat="server"  text="Here will be word. But soon..." OnClick="btnDiv_Click">
                            </asp:Button>
                    </td>
                    <td>
                        <asp:Button CssClass="btn" ID="btnDR" runat="server"  text="Here will be word. But soon..." OnClick="btnDiv_Click">
                            </asp:Button>
                    </td>
                </tr>
                <tr>
                    <asp:Label runat="server" Text="" ID="ResLBL">
                    </asp:Label>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
