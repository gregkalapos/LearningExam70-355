using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using WebApiServerSample.Models;
using Microsoft.Data.OData;

namespace WebApiServerSample.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using WebApiServerSample.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<StockDeal>("StockDeals");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class StockDealsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/StockDeals
        public IHttpActionResult GetStockDeals(ODataQueryOptions<StockDeal> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<StockDeal>>(stockDeals);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/StockDeals(5)
        public IHttpActionResult GetStockDeal([FromODataUri] string key, ODataQueryOptions<StockDeal> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<StockDeal>(stockDeal);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/StockDeals(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<StockDeal> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(stockDeal);

            // TODO: Save the patched entity.

            // return Updated(stockDeal);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/StockDeals
        public IHttpActionResult Post(StockDeal stockDeal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(stockDeal);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/StockDeals(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<StockDeal> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(stockDeal);

            // TODO: Save the patched entity.

            // return Updated(stockDeal);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/StockDeals(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
