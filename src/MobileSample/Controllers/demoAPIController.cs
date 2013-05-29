using MobileSample.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MobileSample.Controllers
{
    public class demoAPIController : ApiController
    {
        private Database1Entities db = new Database1Entities();

        // GET api/demoAPI
        public IEnumerable<WebAPI> GetWebAPI()
        {
            return db.WebAPI.AsEnumerable();
        }

        // GET api/demoAPI/5
        public WebAPI GetWebAPI(int id)
        {
            WebAPI webapi = db.WebAPI.Find(id);
            if (webapi == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return webapi;
        }

        // PUT api/demoAPI/5
        public HttpResponseMessage PutWebAPI(int id, WebAPI webapi)
        {
            if (ModelState.IsValid && id == webapi.Id)
            {
                db.Entry(webapi).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/demoAPI
        public HttpResponseMessage PostWebAPI(WebAPI webapi)
        {
            if (ModelState.IsValid)
            {
                db.WebAPI.Add(webapi);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, webapi);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = webapi.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/demoAPI/5
        public HttpResponseMessage DeleteWebAPI(int id)
        {
            WebAPI webapi = db.WebAPI.Find(id);
            if (webapi == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.WebAPI.Remove(webapi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, webapi);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}