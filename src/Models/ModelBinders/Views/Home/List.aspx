<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Model.PersonViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List</h2>
    <table>
        <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Birthdate</th>
        </tr>
        <% foreach (var item in Model) { %>
        <tr>
            <td><%= Html.Encode(item.FirstName) %></td>
            <td><%= Html.Encode(item.LastName) %></td>
            <td><%= Html.Encode(String.Format("{0:g}", item.Birthdate)) %></td>
        </tr>
        <% } %>
    </table>
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>
