
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
        protected void Page_Load(object sender, EventArgs e)
        {
            this.db = new ContinentsDbContext();
        }

        protected void Get_Data(object sender, Microsoft.AspNet.EntityDataSource.EntityDataSourceContextCreatingEventArgs e)
        {
                //var db = new ContinentsDbContext();
                this.db.Database.Initialize(false);
                var context = (db as IObjectContextAdapter).ObjectContext;
                e.Context = context;
        }

        protected void TownsButtonInsert_Click(object sender, EventArgs e)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void TownsListView_UpdateItem(int Id)
        {
            //Town town = db.Towns.Find(Id);
            //// Load the item here, e.g. item = MyDataLayer.Find(id);
            //if (town == null)
            //{
            //    // The item wasn't found
            //    ModelState.AddModelError("", String.Format("Town with id {0} was not found", Id));
            //    return;
            //}
            //TryUpdateModel(town);
            //if (ModelState.IsValid)
            //{
            //    // Save changes here, e.g. MyDataLayer.SaveChanges();
            //    db.SaveChanges();
            //}
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void TownsListView_DeleteItem(int Id)
        {

        }

        public void TownsListView_InsertItem()
        {
            //var town = new Town();
            //TryUpdateModel(town);
            //if (ModelState.IsValid)
            //{
            //    // Save changes here
            //    db.Towns.Add(town);
            //    db.SaveChanges();
            //}
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Town> TownsListView_GetData()
        {
            return this.db.Towns.OrderBy(t => t.Id);
        }






    }
}