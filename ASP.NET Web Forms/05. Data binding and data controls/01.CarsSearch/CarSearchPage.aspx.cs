using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _01.CarsSearch
{
    public partial class CarSearchPage : System.Web.UI.Page
    {
        private IList<Producer> producers = PopulateProducers();
        private IList<Extra> extras = PopulateExtras();
        private IList<string> engines = PopulateEngines();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.ProducersDropDown.DataSource = this.producers;
                this.ProducersDropDown.DataBind();

                this.ModelsDropDown.DataSource = this.producers[0].Models;
                this.ModelsDropDown.DataBind();

                this.ExtrasCheckBox.DataSource = this.extras;
                this.ExtrasCheckBox.DataBind();

                this.EnginesRadioButton.DataSource = this.engines;
                this.EnginesRadioButton.DataBind();
                this.EnginesRadioButton.SelectedIndex = 0;
            }
        }

        protected void OnProducerSelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dropdown = sender as DropDownList;
            if (dropdown == null)
            {
                return;
            }

            var selectedProducer = this.producers[dropdown.SelectedIndex];
            this.ModelsDropDown.DataSource = selectedProducer.Models;
            this.ModelsDropDown.DataBind();
        }

        protected void OnSearchButtonClicked(object sender, EventArgs e)
        {
            var producer = this.ProducersDropDown.SelectedValue;
            var model = this.ModelsDropDown.SelectedValue;
            var extras = this.ExtrasCheckBox.Items
                                     .Cast<ListItem>()
                                     .Where(x => x.Selected)
                                     .Select(x => x.Text);
            var engine = this.EnginesRadioButton.SelectedValue;

            this.Result.Controls.Add(new HtmlGenericControl()
            {
                TagName = "p",
                InnerText = "Producer: " + producer,
            });

            this.Result.Controls.Add(new HtmlGenericControl()
            {
                TagName = "p",
                InnerText = "Model: " + model,
            });

            this.Result.Controls.Add(new HtmlGenericControl()
            {
                TagName = "p",
                InnerText = "Extras: " + (extras.Any() ? string.Join(", ", extras) : "no extras"),
            });

            this.Result.Controls.Add(new HtmlGenericControl()
            {
                TagName = "p",
                InnerText = "Engine: " + engine,
            });

            this.Result.Visible = true;
        }



        private static IList<Producer> PopulateProducers()
        {
            var producers = new List<Producer>();
            var bmw = new Producer("BMW");
            bmw.Models.Add("X5");
            bmw.Models.Add("524");

            var skoda = new Producer("Skoda");
            skoda.Models.Add("Octavia");
            skoda.Models.Add("Superb");

            var toyota = new Producer("Toyota");
            toyota.Models.Add("Corolla");
            toyota.Models.Add("Avensis");

            producers.Add(bmw);
            producers.Add(skoda);
            producers.Add(toyota);

            return producers;
        }

        private static IList<Extra> PopulateExtras()
        {
            var extras = new List<Extra>();

            extras.Add(new Extra("Navigation"));
            extras.Add(new Extra("Dimmed windows"));
            extras.Add(new Extra("Climatronic"));
            extras.Add(new Extra("Seat heaters"));

            return extras;
        }

        private static IList<string> PopulateEngines()
        {
            var engineTypes = new List<string>()
            {
                "All",
                "Petrol",
                "Diesel",
                "Gas"
            };

            return engineTypes;
        }
    }
}