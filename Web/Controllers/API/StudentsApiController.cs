using Academy.Models.Domain;
using Academy.Models.Requests;
using Academy.Services;
using Academy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Academy.Web.Controllers.API
{
    [RoutePrefix("api/students")]
    public class StudentsApiController : ApiController
    {
        StudentsService studentService = new StudentsService();

        [Route, HttpPost]
        public HttpResponseMessage Post(StudentAddRequest model)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            int response;
            //if (HttpContext.Current.User.Identity.IsAuthenticated)
            //    model.ModifiedBy = HttpContext.Current.User.Identity.Name;
            //else
            //    model.ModifiedBy = "Anonymous";

            response = studentService.Insert(model);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            Students response = new Students();
            response = studentService.SelectById(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route, HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                List<Students> resp = new List<Students>();
                resp = studentService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route, HttpPut]
        public HttpResponseMessage Put(StudentUpdateRequest model)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            //if (HttpContext.Current.User.Identity.IsAuthenticated)
            //    model.ModifiedBy = HttpContext.Current.User.Identity.Name;
            //else
            //    model.ModifiedBy = "Anonymous";

            studentService.Update(model);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated");
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            studentService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}