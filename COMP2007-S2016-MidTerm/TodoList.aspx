<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_MidTerm.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Todo List</h1>
                <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover"
                    ID="TodoGridView" AutoGenerateColumns="true" DataKeyNames="todoID" PagerStyle-CssClass="pagination-ys">
                    <Columns>
                        <asp:BoundField DataField="todoID" HeaderText="ToDo ID" Visible="true" SortExpression="todoID" />
                        <asp:BoundField DataField="todoName" HeaderText="ToDo Name" Visible="true" SortExpression="todoName" />
                        <asp:BoundField DataField="todoNotes" HeaderText="Notes" Visible="true" SortExpression="todoNotes" />
                        <asp:CommandField  HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete" ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
