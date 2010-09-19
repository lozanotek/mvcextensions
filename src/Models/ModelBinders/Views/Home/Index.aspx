<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<PersonViewModel>>" %>

<%@ Import Namespace="Model" %>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
  Model Binder Demo
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
  <%=Html.ActionLink("Create new person", "create") %>
  
  <%
    personGrid.DataSource = Model;
    personGrid.DataBind(); 
  %>
  <form runat="server">
    <asp:GridView runat="server" ID="personGrid" />
  </form>
</asp:Content>
