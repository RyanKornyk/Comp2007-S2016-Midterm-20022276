using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements that are required to connect to EF DB
using COMP2007_S2016_MidTerm.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;


namespace COMP2007_S2016_MidTerm
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate the todo grid
            if (!IsPostBack)
            {
                Session["SortColumn"] = "todoID"; // default sort column
                Session["SortDirection"] = "ASC";
                // Get the To Do data
                this.GetTodo();
            }
        }
        /**
         * <summary>
         * This method gets the ToDo data from the DB
         * </summary>
         * 
         * @method GetToDo
         * @returns {void}
         */
        protected void GetTodo()
        {
            // connect to EF
            using (TodoConnection db = new TodoConnection())
            {
                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                // query the Todo Table using EF and LINQ
                var ToDo = (from allTodo in db.Todos
                                select allTodo);

                // bind the result to the GridView
                TodoGridView.DataSource = ToDo.AsQueryable().OrderBy(SortString).ToList();
                TodoGridView.DataBind();
            }
        }
    }
}