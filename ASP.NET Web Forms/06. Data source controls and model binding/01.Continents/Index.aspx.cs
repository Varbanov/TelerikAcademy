
using Continents.Data;
using Continents.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.Continents
{
    public partial class Index : System.Web.UI.Page
    {

        private ContinentsDbContext db;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.db = new ContinentsDbContext();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Get_Data(object sender, Microsoft.AspNet.EntityDataSource.EntityDataSourceContextCreatingEventArgs e)
        {
            //var db = new ContinentsDbContext();
            var context = (db as IObjectContextAdapter).ObjectContext;
            e.Context = context;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Continent> ContinentListBox_GetData()
        {
            return this.db.Continents;
        }

        protected void ContinentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedContinentId = int.Parse((sender as ListBox).SelectedValue);
            this.CountriesGridView.DataSource = this.db.Countries.Where(x => x.ContinentId == selectedContinentId).OrderBy(x => x.Name).ToList();
            this.CountriesGridView.DataBind();
        }

        protected void CountriesGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCountryId = (int)(sender as GridView).SelectedValue;
            this.TownsListView.DataSource = this.db.Towns.Where(x => x.CountryId == selectedCountryId).OrderBy(x => x.Name).ToList();
            this.TownsListView.DataBind();


        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void CountriesGridView_UpdateItem(int Id)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Country> CountriesGridView_GetData()
        {
            return null;
        }

        protected void CountriesGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            CountriesGridView.EditIndex = e.NewEditIndex;
            CountriesGridView.DataBind();

        }




    }
}