<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Model.PersonViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
  <% using (Html.BeginForm())
     {%>
  <fieldset>
    <p>
      <label for="FirstName">
        FirstName:</label>
      <%= Html.TextBox("FirstName") %>
      <%= Html.ValidationMessage("FirstName", "*") %>
    </p>
    <p>
      <label for="LastName">
        LastName:</label>
      <%= Html.TextBox("LastName") %>
      <%= Html.ValidationMessage("LastName", "*") %>
    </p>
        <p>
      <label for="LastName">
        Birthdate:</label>
        <input type="text" maxlength="2" size="2" id="month" name="month" style="width:20px;" /> /
        <input type="text" maxlength="2" size="2" id="day" name="day" style="width:20px;" /> /
        <input type="text" maxlength="4" size="4" id="year" name="year" style="width:50px;" />
    </p>

    <p>
      <input type="submit" value="Create" />
    </p>
  </fieldset>
  <% } %>
  <div>
    <%=Html.ActionLink("Back to List", "Index") %>
  </div>
</asp:Content>
