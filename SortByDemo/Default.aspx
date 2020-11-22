<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SortByDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Default</title>
    <style>
        .btnone {
            font-size: 9pt;
            color: black;
            font-family: 宋体, Arial;
            text-align: center;
            padding:6px 12px;
        }

        .data-div table {
            width: 100%;
            border-collapse: collapse;
            margin: 10px auto;
        }

            .data-div table thead tr {
                background-color: #3f69f3;
            }

            .data-div table thead th,
            .data-div table tbody td {
                border: 1px solid #ccc;
                padding: 10px;
            }

        .inputKeyBox {
            width: 98%;
            padding: 6px 12px;
        }
        .b-color {
            color:#f00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%">
                <tr>

                    <td valign="middle" align="left">
                        <asp:TextBox runat="server" ID="keyBox" CssClass="inputKeyBox" Text="name asc"></asp:TextBox>
                    </td>
                </tr>
                <tr>

                    <td valign="middle" align="left">
                        <asp:Button ID="bt_paixu" runat="server" CssClass="btnone" Text="排序" OnClick="bt_paixu_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="dataUpdatePanel" runat="server">
            <ContentTemplate>
                <div class="data-div">
                    <table>
                        <thead class="dghead">
                            <tr>
                                <th>姓名</th>
                                <th>性别</th>
                                <th>年龄</th>
                            </tr>
                        </thead>
                        <tbody>

                            <% foreach (TestData row in dataList)
                                { %>
                            <tr>
                                <td><%=row.name %></td>
                                <td><%=row.sex %></td>
                                <td><%=row.age %></td>
                            </tr>

                            <%} %>
                        </tbody>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div>
            <p>按<b class="b-color">姓名升序</b>排序：name asc </p>
            <p>按<b class="b-color">姓名降序</b>排序：name desc </p>
            <p>按<b class="b-color">姓名降序，性别升序</b>排序：name desc,sex </p>
            <p>按<b class="b-color">姓名升序，性别降序</b>排序：name,sex desc </p>
            <p>按<b class="b-color">年龄升序，性别升序</b>排序：age,sex </p>
            <p>按<b class="b-color">年龄升序，性别降序</b>排序：age,sex desc </p>
            <p>按<b class="b-color">年龄降序，性别降序</b>排序：age desc,sex desc </p>

        </div>

    </form>
</body>
</html>
